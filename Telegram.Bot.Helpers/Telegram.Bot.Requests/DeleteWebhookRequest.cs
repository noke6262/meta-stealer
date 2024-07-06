using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class DeleteWebhookRequest : ParameterlessRequest<bool>
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
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
