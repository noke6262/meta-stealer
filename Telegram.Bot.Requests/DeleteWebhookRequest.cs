using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class DeleteWebhookRequest : ParameterlessRequest<bool>
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [JsonProperty("drop_pending_updates", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool DropPendingUpdates
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

    public DeleteWebhookRequest()
        : base("deleteWebhook")
    {
    }
}
