using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetChatPhotoRequest : FileRequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InputFileStream Photo
	{
		[CompilerGenerated]
		get
		{
			return (InputFileStream)object_1;
		}
	}

	public SetChatPhotoRequest(ChatId chatId, InputFileStream photo)
		: base("setChatPhoto")
	{
		object_0 = chatId;
		object_1 = photo;
	}

	public override HttpContent ToHttpContent()
	{
		if (Photo.FileType != 0)
		{
			return base.ToHttpContent();
		}
		return ToMultipartFormDataContent("photo", Photo);
	}
}
