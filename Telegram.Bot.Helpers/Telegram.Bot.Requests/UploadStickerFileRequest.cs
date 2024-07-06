using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class UploadStickerFileRequest : FileRequestBase<File>
{
	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private readonly object object_0;

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
	public InputFileStream PngSticker
	{
		[CompilerGenerated]
		get
		{
			return (InputFileStream)object_0;
		}
	}

	public UploadStickerFileRequest(long userId, InputFileStream pngSticker)
		: base("uploadStickerFile")
	{
		long_0 = userId;
		object_0 = pngSticker;
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
