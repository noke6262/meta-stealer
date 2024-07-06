using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class MessageEntityTypeConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        string value2 = ((MessageEntityType)value).smethod_1();
        writer.WriteValue(value2);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return JToken.ReadFrom(reader).Value<string>().smethod_0();
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(MessageEntityType) == objectType;
    }
}
