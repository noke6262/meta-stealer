using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class DeleteStickerFromSetRequest : RequestBase<bool>
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Sticker
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	public DeleteStickerFromSetRequest(string sticker)
		: base("deleteStickerFromSet")
	{
		object_0 = sticker;
	}
}
