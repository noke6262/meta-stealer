using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetStickerSetRequest : RequestBase<StickerSet>
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Name
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	public GetStickerSetRequest(string name)
		: base("getStickerSet")
	{
		object_0 = name;
	}
}
