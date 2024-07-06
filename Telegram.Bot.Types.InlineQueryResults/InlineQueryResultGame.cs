using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineQueryResultGame : InlineQueryResultBase
{
    [CompilerGenerated]
    private object object_2;

    [JsonProperty("game_short_name", Required = Required.Always)]
    public string GameShortName
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

    private InlineQueryResultGame()
        : base(InlineQueryResultType.Game)
    {
    }

    public InlineQueryResultGame(string id, string gameShortName)
        : base(InlineQueryResultType.Game, id)
    {
        GameShortName = gameShortName;
    }
}
