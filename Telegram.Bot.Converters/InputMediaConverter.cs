using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class InputMediaConverter : InputFileConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(InputMedia) == objectType;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        InputMedia inputMedia = (InputMedia)value;
        switch (inputMedia.FileType)
        {
            case FileType.Id:
            case FileType.Url:
                base.WriteJson(writer, value, serializer);
                break;
            default:
                throw new NotSupportedException("File Type not supported");
            case FileType.Stream:
                writer.WriteValue("attach://" + inputMedia.FileName);
                break;
        }
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        string text = JToken.ReadFrom(reader).Value<string>();
        if (text == null || !text.StartsWith("attach://"))
        {
            return new InputMedia(text);
        }
        return new InputMedia(Stream.Null, text.Substring(9));
    }
}
