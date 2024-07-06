using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ApiResponse<TResult>
{
    [JsonProperty("ok", Required = Required.Always)]
    public bool Ok { get; set; }

    [JsonProperty("result", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public TResult Result { get; set; }

    [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("error_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int ErrorCode { get; set; }

    [JsonProperty("parameters", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ResponseParameters Parameters { get; set; }
}
