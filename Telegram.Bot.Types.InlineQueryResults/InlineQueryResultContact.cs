using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultContact : InlineQueryResultBase, IInputMessageContentResult, IThumbnailInlineQueryResult, IThumbnailUrlInlineQueryResult
{
    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private IntPtr intptr_1;

    [CompilerGenerated]
    private object object_7;

    [JsonProperty("phone_number", Required = Required.Always)]
    public string PhoneNumber
    {
        [CompilerGenerated]
        get
        {
            return (string)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("first_name", Required = Required.Always)]
    public string FirstName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("last_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("vcard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Vcard
    {
        [CompilerGenerated]
        get
        {
            return (string)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    [JsonProperty("thumb_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ThumbUrl
    {
        [CompilerGenerated]
        get
        {
            return (string)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("thumb_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbWidth
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)value;
        }
    }

    [JsonProperty("thumb_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ThumbHeight
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_1;
        }
        [CompilerGenerated]
        set
        {
            intptr_1 = (IntPtr)value;
        }
    }

    [JsonProperty("input_message_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InputMessageContentBase InputMessageContent
    {
        [CompilerGenerated]
        get
        {
            return (InputMessageContentBase)object_7;
        }
        [CompilerGenerated]
        set
        {
            object_7 = value;
        }
    }

    private InlineQueryResultContact()
        : base(InlineQueryResultType.Contact)
    {
    }

    public InlineQueryResultContact(string id, string phoneNumber, string firstName)
        : base(InlineQueryResultType.Contact, id)
    {
        PhoneNumber = phoneNumber;
        FirstName = firstName;
    }
}
