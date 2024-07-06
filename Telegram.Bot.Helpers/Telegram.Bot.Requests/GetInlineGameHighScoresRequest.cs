using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetInlineGameHighScoresRequest : RequestBase<GameHighScore[]>, IInlineMessage
{
	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public long UserId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string InlineMessageId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	public GetInlineGameHighScoresRequest(long userId, string inlineMessageId)
		: base("getGameHighScores")
	{
		long_0 = userId;
		object_0 = inlineMessageId;
	}
}
