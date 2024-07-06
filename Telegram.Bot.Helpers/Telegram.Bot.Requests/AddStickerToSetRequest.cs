using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class AddStickerToSetRequest : FileRequestBase<bool>
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
	private object object_3;

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
	public InputOnlineFile PngSticker
	{
		[CompilerGenerated]
		get
		{
			return (InputOnlineFile)object_1;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Emojis
	{
		[CompilerGenerated]
		get
		{
			return (string)object_2;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MaskPosition MaskPosition
	{
		[CompilerGenerated]
		get
		{
			return (MaskPosition)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	public AddStickerToSetRequest(long userId, string name, InputOnlineFile pngSticker, string emojis)
		: base("addStickerToSet")
	{
		long_0 = userId;
		object_0 = name;
		object_1 = pngSticker;
		object_2 = emojis;
	}

	public override HttpContent ToHttpContent()
	{
		if (PngSticker.FileType != 0)
		{
			return base.ToHttpContent();
		}
		return ToMultipartFormDataContent("png_sticker", PngSticker);
	}
}
