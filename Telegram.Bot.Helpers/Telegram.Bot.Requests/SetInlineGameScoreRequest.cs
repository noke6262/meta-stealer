using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Requests.Abstractions;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetInlineGameScoreRequest : RequestBase<bool>, IInlineMessage
{
	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

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
	public int Score
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool Force
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_1 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool DisableEditMessage
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_2 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)(value ? 1 : 0);
		}
	}

	public SetInlineGameScoreRequest(long userId, int score, string inlineMessageId)
		: base("setGameScore")
	{
		long_0 = userId;
		intptr_0 = (IntPtr)score;
		object_0 = inlineMessageId;
	}
}
