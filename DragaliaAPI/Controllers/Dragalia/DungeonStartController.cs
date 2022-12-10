﻿using System.Linq;
using AutoMapper;
using DragaliaAPI.Database;
using DragaliaAPI.Database.Entities;
using DragaliaAPI.Database.Repositories;
using DragaliaAPI.Models;
using DragaliaAPI.Models.Generated;
using DragaliaAPI.Models.Nintendo;
using DragaliaAPI.Services;
using DragaliaAPI.Shared.Definitions;
using DragaliaAPI.Shared.Definitions.Enums;
using DragaliaAPI.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DragaliaAPI.Controllers.Dragalia;

[ApiController]
[Route("dungeon_start")]
[Consumes("application/octet-stream")]
[Produces("application/octet-stream")]
public class DungeonStartController : DragaliaControllerBase
{
    private readonly IPartyRepository partyRepository;
    private readonly IUserDataRepository userDataRepository;
    private readonly IUnitRepository unitRepository;
    private readonly IQuestRepository questRepository;
    private readonly IDungeonService dungeonService;
    private readonly IUpdateDataService updateDataService;
    private readonly IQuestDataService questDataService;
    private readonly IEnemyListDataService enemyListDataService;
    private readonly IMapper mapper;

    private static class StubData
    {
        private static readonly IEnumerable<AtgenParamBonus> EmptyWeaponBonus = Enumerable
            .Range(1, 9)
            .Select(
                x =>
                    new AtgenParamBonus()
                    {
                        weapon_type = x,
                        hp = 0,
                        attack = 0
                    }
            );

        private static readonly IEnumerable<AtgenElementBonus> EmptyElementBonus = Enumerable
            .Range(1, 5)
            .Select(
                x =>
                    new AtgenElementBonus()
                    {
                        elemental_type = x,
                        hp = 0,
                        attack = 0
                    }
            )
            .Append(
                new AtgenElementBonus()
                {
                    elemental_type = 99,
                    hp = 0,
                    attack = 0
                }
            );

        private static readonly IEnumerable<AtgenDragonBonus> EmptyDragonBonus = Enumerable
            .Range(1, 5)
            .Select(
                x =>
                    new AtgenDragonBonus()
                    {
                        elemental_type = x,
                        hp = 0,
                        attack = 0
                    }
            )
            .Append(
                new AtgenDragonBonus()
                {
                    elemental_type = 99,
                    hp = 0,
                    attack = 0
                }
            );

        public static readonly FortBonusList EmptyBonusList =
            new()
            {
                param_bonus = EmptyWeaponBonus,
                param_bonus_by_weapon = EmptyWeaponBonus,
                element_bonus = EmptyElementBonus,
                chara_bonus_by_album = EmptyElementBonus,
                all_bonus = new() { hp = 0, attack = 0 },
                dragon_bonus = EmptyDragonBonus,
                dragon_bonus_by_album = EmptyElementBonus,
                dragon_time_bonus = new() { dragon_time_bonus = 0 }
            };
    }

    public DungeonStartController(
        IPartyRepository partyRepository,
        IUserDataRepository userDataRepository,
        IUnitRepository unitRepository,
        IQuestRepository questRepository,
        IDungeonService dungeonService,
        IUpdateDataService updateDataService,
        IQuestDataService questDataService,
        IEnemyListDataService enemyListDataService,
        IMapper mapper
    )
    {
        this.partyRepository = partyRepository;
        this.userDataRepository = userDataRepository;
        this.unitRepository = unitRepository;
        this.questRepository = questRepository;
        this.dungeonService = dungeonService;
        this.updateDataService = updateDataService;
        this.questDataService = questDataService;
        this.enemyListDataService = enemyListDataService;
        this.mapper = mapper;
    }

    [HttpPost("start")]
    public async Task<DragaliaResult> Start(DungeonStartStartRequest request)
    {
        DbQuest? quest = await this.questRepository
            .GetQuests(this.DeviceAccountId)
            .SingleOrDefaultAsync(x => x.QuestId == request.quest_id);

        if (quest?.State != 3)
            await this.questRepository.UpdateQuestState(this.DeviceAccountId, request.quest_id, 2);

        UpdateDataList updateData = this.updateDataService.GetUpdateDataList(this.DeviceAccountId);

        int partyNo = request.party_no_list.ElementAt(0);

        DbParty party = await this.partyRepository
            .GetParties(this.DeviceAccountId)
            .Where(x => x.PartyNo == request.party_no_list.ElementAt(0))
            .Include(x => x.Units)
            .SingleAsync();

        // Would love to do a fancy async LINQ trick instead of basic for loop, but this needs to be
        // performed one-by-one due to the DbContext not accepting multithreaded access
        List<DbDetailedPartyUnit> detailedPartyUnits = new();
        foreach (DbPartyUnit p in party.Units.Where(x => x.CharaId != Charas.Empty))
            detailedPartyUnits.Add(await this.unitRepository.BuildDetailedPartyUnit(p));

        // TODO: add this to the base controller via middleware
        long viewerId = await this.userDataRepository
            .GetUserData(this.DeviceAccountId)
            .Select(x => x.ViewerId)
            .SingleAsync();

        IEnumerable<DataQuestAreaInfo> areaInfo = this.questDataService.GetMapData(
            request.quest_id
        );

        IEnumerable<int> enemyList = this.enemyListDataService
            .GetData(areaInfo.ElementAt(0))
            .Enemies;

        string dungeonKey = await this.dungeonService.StartDungeon(
            new DungeonSession()
            {
                DungeonId = request.quest_id,
                Party = party.Units.Select(mapper.Map<PartySettingList>),
                AreaInfo = areaInfo
            }
        );

        var areaInfoList = areaInfo.Select(this.mapper.Map<AreaInfoList>);
        var partyUnitList = detailedPartyUnits.Select(mapper.Map<PartyUnitList>);

        DungeonStartStartData response =
            new()
            {
                ingame_data = new()
                {
                    viewer_id = (ulong)viewerId,
                    dungeon_key = dungeonKey,
                    dungeon_type = 1,
                    play_type = 1,
                    quest_id = request.quest_id,
                    is_host = true,
                    continue_limit = 3,
                    reborn_limit = 3,
                    start_time = DateTime.UtcNow,
                    party_info = new()
                    {
                        party_unit_list = partyUnitList,
                        fort_bonus_list = StubData.EmptyBonusList,
                        event_boost = new() { effect_value = 0, event_effect = 0 },
                        event_passive_grow_list = new List<AtgenEventPassiveUpList>(),
                    },
                    area_info_list = areaInfoList,
                    use_stone = 50,
                    is_fever_time = false,
                    repeat_state = 0,
                    is_use_event_chara_ability = false,
                    event_ability_chara_list = new List<EventAbilityCharaList>(),
                    is_bot_tutorial = false,
                    is_receivable_carry_bonus = false,
                    first_clear_viewer_id_list = new List<ulong>(),
                    multi_disconnect_type = 0,
                },
                ingame_quest_data = new()
                {
                    quest_id = request.quest_id,
                    play_count = quest?.PlayCount ?? 0,
                    is_mission_clear_1 = quest?.IsMissionClear1 ?? false,
                    is_mission_clear_2 = quest?.IsMissionClear2 ?? false,
                    is_mission_clear_3 = quest?.IsMissionClear3 ?? false,
                },
                odds_info = new()
                {
                    area_index = 0,
                    reaction_obj_count = 1,
                    drop_obj = new List<AtgenDropObj>()
                    {
                        new()
                        {
                            drop_list = new List<AtgenDropList>()
                            {
                                new()
                                {
                                    type = 13,
                                    id = 1001,
                                    quantity = 4000,
                                    place = 0
                                }
                            },
                            obj_id = 1,
                            obj_type = 2,
                            is_rare = false,
                        }
                    },
                    enemy = new List<AtgenEnemy>()
                    {
                        new()
                        {
                            param_id = 100010106,
                            is_pop = true,
                            is_rare = false,
                            piece = 0,
                            enemy_drop_list = new List<EnemyDropList>()
                            {
                                new()
                                {
                                    drop_list = new List<AtgenDropList>(),
                                    coin = 1,
                                    mana = 2,
                                }
                            },
                            enemy_idx = 0,
                        }
                    },
                    grade = new List<AtgenGrade>()
                },
                update_data_list = updateData
            };

        return this.Ok(response);
    }
}
