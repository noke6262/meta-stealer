using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InputTextMessageContent : InputMessageContentBase
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private ParseMode parseMode_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [JsonProperty("message_text", Required = Required.Always)]
    public string MessageText
    {
        [CompilerGenerated]
        get
        {
            return (string)object_0;
        }
        [CompilerGenerated]
        private set
        {
            object_0 = value;
        }
    }

    [JsonProperty("parse_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ParseMode ParseMode
    {
        [CompilerGenerated]
        get
        {
            return parseMode_0;
        }
        [CompilerGenerated]
        set
        {
            parseMode_0 = value;
        }
    }

    [JsonProperty("entities", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public MessageEntity[] Entities
    {
        [CompilerGenerated]
        get
        {
            return (MessageEntity[])object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    [JsonProperty("disable_web_page_preview", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DisableWebPagePreview
    {
        [CompilerGenerated]
        get
        {
            return (byte)(nint)intptr_0 != 0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)(value ? 1 : 0);
        }
    }

    private InputTextMessageContent()
    {
    }

    public InputTextMessageContent(string messageText)
    {
        MessageText = messageText;
    }
}
