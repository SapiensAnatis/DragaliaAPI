﻿using System.ComponentModel;
using DragaliaAPI.Models.Data;
using DragaliaAPI.Models.Database.Savefile;
using DragaliaAPI.Models.Dragalia.MessagePackFormatters;
using MessagePack;

namespace DragaliaAPI.Models.Dragalia.Responses.UpdateData;

// TODO: Change to CharaDTO to avoid confusion with Charas enum
[MessagePackObject(true)]
public record Chara(
    Charas chara_id,
    int exp,
    int level,
    int additional_max_level,
    int hp,
    int attack,
    int ex_ability_level,
    int ex_ability_2_level,
    int ability_1_level,
    int ability_2_level,
    int ability_3_level,
    [property: MessagePackFormatter(typeof(BoolToIntFormatter))] bool is_new,
    int skill_1_level,
    int skill_2_level,
    int burst_attack_level,
    int rarity,
    int limit_break_count,
    int hp_plus_count,
    int attack_plus_count,
    int combo_buildup_count,
    [property: MessagePackFormatter(typeof(BoolToIntFormatter))] bool is_unlock_edit_skill,
    int gettime,
    SortedSet<int> mana_circle_piece_id_list,
    [property: MessagePackFormatter(typeof(BoolToIntFormatter))] bool is_temporary,
    [property: MessagePackFormatter(typeof(BoolToIntFormatter))] bool list_view_flag
);

public static class CharaFactory
{
    public static Chara Create(DbPlayerCharaData dbEntry)
    {
        return new Chara(
            chara_id: dbEntry.CharaId,
            exp: dbEntry.Exp,
            level: dbEntry.Level,
            additional_max_level: dbEntry.AdditionalMaxLevel,
            hp: dbEntry.Hp,
            attack: dbEntry.Attack,
            ex_ability_level: dbEntry.FirstExAbilityLevel,
            ex_ability_2_level: dbEntry.SecondExAbilityLevel,
            ability_1_level: dbEntry.FirstAbilityLevel,
            ability_2_level: dbEntry.SecondAbilityLevel,
            ability_3_level: dbEntry.ThirdAbilityLevel,
            is_new: dbEntry.IsNew,
            skill_1_level: dbEntry.FirstSkillLevel,
            skill_2_level: dbEntry.SecondSkillLevel,
            burst_attack_level: dbEntry.BurstAttackLevel,
            rarity: dbEntry.Rarity,
            limit_break_count: dbEntry.LimitBreakCount,
            hp_plus_count: dbEntry.HpPlusCount,
            attack_plus_count: dbEntry.AttackPlusCount,
            combo_buildup_count: dbEntry.ComboBuildupCount,
            is_unlock_edit_skill: dbEntry.IsUnlockEditSkill,
            gettime: dbEntry.GetTime,
            mana_circle_piece_id_list: dbEntry.ManaNodesUnlocked,
            is_temporary: dbEntry.IsTemporary,
            list_view_flag: dbEntry.ListViewFlag
        );
    }
}
