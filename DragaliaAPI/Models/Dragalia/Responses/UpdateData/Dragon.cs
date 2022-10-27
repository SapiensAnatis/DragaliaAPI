﻿using DragaliaAPI.Models.Database.Savefile;
using DragaliaAPI.Models.Dragalia.MessagePackFormatters;
using MessagePack;

namespace DragaliaAPI.Models.Dragalia.Responses.UpdateData;

[MessagePackObject(true)]
public record Dragon(
    ulong dragon_key_id,
    int dragon_id,
    int level,
    int hp_plus_count,
    int attack_plus_count,
    int exp,
    [property: MessagePackFormatter(typeof(BoolToIntFormatter))] bool is_lock,
    [property: MessagePackFormatter(typeof(BoolToIntFormatter))] bool is_new,
    [property: MessagePackFormatter(typeof(DateTimeOffsetToUnixIntFormatter))]
        DateTimeOffset get_time,
    int skill_1_level,
    int ability_1_level,
    int ability_2_level,
    int limit_break_count
);

public static class DragonFactory
{
    public static Dragon Create(DbPlayerDragonData dbEntry)
    {
        return new Dragon(
            dragon_key_id: (ulong)dbEntry.DragonKeyId,
            dragon_id: (int)dbEntry.DragonId,
            level: dbEntry.Level,
            hp_plus_count: dbEntry.HpPlusCount,
            attack_plus_count: dbEntry.AttackPlusCount,
            exp: (int)dbEntry.Exp,
            is_lock: dbEntry.IsLocked,
            is_new: dbEntry.IsNew,
            get_time: dbEntry.GetTime,
            skill_1_level: dbEntry.FirstSkillLevel,
            ability_1_level: dbEntry.FirstAbilityLevel,
            ability_2_level: dbEntry.SecondAbilityLevel,
            limit_break_count: dbEntry.LimitBreakCount
        );
    }
}
