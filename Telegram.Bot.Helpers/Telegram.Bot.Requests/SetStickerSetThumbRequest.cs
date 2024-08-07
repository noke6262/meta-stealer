using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetStickerSetThumbRequest : FileRequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private object object_1;

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
	public long UserId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InputOnlineFile Thumb
	{
		[CompilerGenerated]
		get
		{
			return (InputOnlineFile)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public SetStickerSetThumbRequest(string name, long userId, InputOnlineFile thumb = null)
		: base("setStickerSetThumb")
	{
		object_0 = name;
		long_0 = userId;
		Thumb = thumb;
	}

	public override HttpContent ToHttpContent()
	{
		InputOnlineFile thumb = Thumb;
		if (thumb != null && thumb.FileType == FileType.Stream)
		{
			return ToMultipartFormDataContent("thumb", Thumb);
		}
		return base.ToHttpContent();
	}
}
