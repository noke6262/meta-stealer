using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.Passport;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PassportData
{
    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [JsonProperty("data", Required = Required.Always)]
    public EncryptedPassportElement[] Data
    {
        [CompilerGenerated]
        get
        {
            return (EncryptedPassportElement[])object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("credentials", Required = Required.Always)]
    public EncryptedCredentials Credentials
    {
        [CompilerGenerated]
        get
        {
            return (EncryptedCredentials)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }
}
