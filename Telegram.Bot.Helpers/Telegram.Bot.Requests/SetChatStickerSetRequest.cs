using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class SetChatStickerSetRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatId ChatId
	{
		[CompilerGenerated]
		get
		{
			return (ChatId)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string StickerSetName
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public SetChatStickerSetRequest(ChatId chatId, string stickerSetName)
		: base("setChatStickerSet")
	{
		ChatId = chatId;
		StickerSetName = stickerSetName;
	}
}
