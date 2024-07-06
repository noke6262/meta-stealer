using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Requests;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetUpdatesRequest : RequestBase<Update[]>
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Offset
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Limit
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Timeout
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_2;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<UpdateType> AllowedUpdates
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<UpdateType>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public GetUpdatesRequest()
		: base("getUpdates")
	{
	}
}
