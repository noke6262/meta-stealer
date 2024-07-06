using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.InlineQueryResults;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class AnswerInlineQueryRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private int? nullable_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private object object_4;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string InlineQueryId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<InlineQueryResultBase> Results
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<InlineQueryResultBase>)object_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int? CacheTime
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool IsPersonal
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
	public string NextOffset
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
	public string SwitchPmText
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string SwitchPmParameter
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

	public AnswerInlineQueryRequest(string inlineQueryId, IEnumerable<InlineQueryResultBase> results)
		: base("answerInlineQuery")
	{
		object_0 = inlineQueryId;
		object_1 = results;
	}
}
