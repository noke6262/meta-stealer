using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class AnswerShippingQueryRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object object_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string ShippingQueryId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool Ok
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<ShippingOption> ShippingOptions
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<ShippingOption>)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string ErrorMessage
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

	private AnswerShippingQueryRequest()
		: base("answerShippingQuery")
	{
	}

	public AnswerShippingQueryRequest(string shippingQueryId, string errorMessage)
		: this()
	{
		object_0 = shippingQueryId;
		ErrorMessage = errorMessage;
	}

	public AnswerShippingQueryRequest(string shippingQueryId, IEnumerable<ShippingOption> shippingOptions)
		: this(shippingQueryId, (string)null)
	{
		intptr_0 = (IntPtr)1;
		ShippingOptions = shippingOptions;
	}
}
