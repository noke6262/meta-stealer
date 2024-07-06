using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InputContactMessageContent : InputMessageContentBase
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [JsonProperty("phone_number", Required = Required.Always)]
    public string PhoneNumber
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

    [JsonProperty("first_name", Required = Required.Always)]
    public string FirstName
    {
        [CompilerGenerated]
        get
        {
            return (string)object_1;
        }
        [CompilerGenerated]
        private set
        {
            object_1 = value;
        }
    }

    [JsonProperty("last_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string LastName
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

    [JsonProperty("vcard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Vcard
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

    private InputContactMessageContent()
    {
    }

    public InputContactMessageContent(string phoneNumber, string firstName)
    {
        PhoneNumber = phoneNumber;
        FirstName = firstName;
    }
}
