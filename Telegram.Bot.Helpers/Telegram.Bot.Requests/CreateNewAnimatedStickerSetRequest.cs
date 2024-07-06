using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class CreateNewAnimatedStickerSetRequest : FileRequestBase<bool>
{
	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private readonly object object_2;

	[CompilerGenerated]
	private readonly object object_3;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_4;

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
	public string Name
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Title
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InputFileStream TgsSticker
	{
		[CompilerGenerated]
		get
		{
			return (InputFileStream)object_2;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Emojis
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool ContainsMasks
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
	public MaskPosition MaskPosition
	{
		[CompilerGenerated]
		get
		{
			return (MaskPosition)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	public CreateNewAnimatedStickerSetRequest(long userId, string name, string title, InputFileStream tgsSticker, string emojis)
		: base("createNewStickerSet")
	{
		long_0 = userId;
		object_0 = name;
		object_1 = title;
		object_2 = tgsSticker;
		object_3 = emojis;
	}

	public override HttpContent ToHttpContent()
	{
		if (TgsSticker != null)
		{
			return ToMultipartFormDataContent("tgs_sticker", TgsSticker);
		}
		return base.ToHttpContent();
	}
}
