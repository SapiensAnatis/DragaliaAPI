﻿using DragaliaAPI.Models.Components;
using DragaliaAPI.Models.Responses.Base;
using MessagePack;

namespace DragaliaAPI.Models.Responses;

public record CharaBuildupManaResponse(CharBuildupManaUpdateDataList data)
    : BaseResponse<CharBuildupManaUpdateDataList>;

[MessagePackObject(true)]
public class CharBuildupManaUpdateDataList : UpdateDataList
{
    public PartyPowerData party_power_data { get; set; } = null!;
    public MissionNoticeData mission_notice { get; set; } = null!;
}
