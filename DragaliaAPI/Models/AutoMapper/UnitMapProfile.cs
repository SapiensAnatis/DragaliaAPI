﻿using AutoMapper;
using DragaliaAPI.Database.Entities;
using DragaliaAPI.Models.Generated;

namespace DragaliaAPI.Models.AutoMapper;

public class UnitMapProfile : Profile
{
    public UnitMapProfile()
    {
        this.CreateMap<DbPlayerDragonData, DragonList>()
            .ForMember(x => x.status_plus_count, opts => opts.Ignore());

        this.CreateMap<DbPlayerCharaData, CharaList>()
            .ForMember(x => x.status_plus_count, opts => opts.Ignore());

        this.CreateMap<DbPlayerDragonReliability, DragonReliabilityList>()
            .ForMember(
                nameof(DragonReliabilityList.reliability_level),
                o => o.MapFrom(src => src.Level)
            )
            .ForMember(
                nameof(DragonReliabilityList.reliability_total_exp),
                o => o.MapFrom(src => src.Exp)
            );

        this.CreateMap<DbAbilityCrest, AbilityCrestList>()
            .ForMember(x => x.ability_1_level, opts => opts.Ignore())
            .ForMember(x => x.ability_2_level, opts => opts.Ignore());

        this.CreateMap<DbAbilityCrest, GameAbilityCrest>()
            // TODO: add actual mapping for this
            .ForMember(x => x.ability_1_level, opts => opts.MapFrom(x => 0))
            .ForMember(x => x.ability_2_level, opts => opts.MapFrom(x => 0));

        this.CreateMap<DbWeaponBody, WeaponBodyList>()
            .ForMember(x => x.ability_1_level, opts => opts.Ignore())
            .ForMember(x => x.ability_2_levell, opts => opts.Ignore())
            .ForMember(x => x.skill_no, opts => opts.Ignore())
            .ForMember(x => x.skill_level, opts => opts.Ignore());

        this.CreateMap<DbWeaponBody, GameWeaponBody>()
            // TODO: add actual mapping for this
            .ForMember(x => x.skill_no, opts => opts.MapFrom(x => 0))
            .ForMember(x => x.skill_level, opts => opts.MapFrom(x => 0))
            .ForMember(x => x.ability_1_level, opts => opts.MapFrom(x => 0))
            .ForMember(x => x.ability_2_level, opts => opts.MapFrom(x => 0));

        this.CreateMap<DbDetailedPartyUnit, PartyUnitList>()
            .ForMember(x => x.weapon_skin_data, opts => opts.Ignore())
            .ForMember(x => x.edit_skill_1_chara_data, opts => opts.Ignore())
            .ForMember(x => x.edit_skill_2_chara_data, opts => opts.Ignore())
            .ForMember(x => x.game_weapon_passive_ability_list, opts => opts.Ignore())
            .ForMember(x => x.talisman_data, opts => opts.Ignore());

        this.CreateMap<DbParty, PartyList>()
            .ForMember(nameof(PartyList.party_setting_list), opts => opts.MapFrom(x => x.Units))
            .ReverseMap()
            .ForMember(x => x.Units, opts => opts.MapFrom(x => x.party_setting_list));

        this.CreateMap<DbPartyUnit, PartySettingList>()
            .ForMember(
                x => x.equip_crest_slot_type_1_crest_id_1,
                opts => opts.MapFrom(x => x.EquipCrestSlotType1CrestId1)
            )
            .ForMember(nameof(PartySettingList.equip_weapon_key_id), opts => opts.Ignore())
            .ForMember(nameof(PartySettingList.equip_amulet_key_id), opts => opts.Ignore())
            .ForMember(nameof(PartySettingList.equip_amulet_2_key_id), opts => opts.Ignore())
            .ForMember(nameof(PartySettingList.equip_skin_weapon_id), opts => opts.Ignore())
            .ReverseMap();

        this.SourceMemberNamingConvention = new PascalCaseNamingConvention();
        this.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
    }
}
