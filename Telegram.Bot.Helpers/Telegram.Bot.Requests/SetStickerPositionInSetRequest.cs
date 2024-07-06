using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetStickerPositionInSetRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Sticker
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Position
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
	}

	public SetStickerPositionInSetRequest(string sticker, int position)
		: base("setStickerPositionInSet")
	{
		object_0 = sticker;
		intptr_0 = (IntPtr)position;
	}
}
