﻿using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace DragaliaAPI.MessagePack;

public class TimeSpanUnixJsonConverter : JsonConverter<TimeSpan>
{
    static TimeSpanUnixJsonConverter()
    {
        Options = new();
        Options.Converters.Add(new DateTimeUnixJsonConverter());
    }

    public static JsonSerializerOptions Options { get; }

    public override TimeSpan Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new TimeSpan(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.TotalSeconds);
    }
}
