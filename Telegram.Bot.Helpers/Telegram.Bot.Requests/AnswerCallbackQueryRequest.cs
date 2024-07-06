using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class AnswerCallbackQueryRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string CallbackQueryId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Text
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool ShowAlert
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Url
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int CacheTime
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

	public AnswerCallbackQueryRequest(string callbackQueryId)
		: base("answerCallbackQuery")
	{
		object_0 = callbackQueryId;
	}
}
