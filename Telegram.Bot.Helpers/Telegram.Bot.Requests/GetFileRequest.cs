using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Telegram.Bot.Requests;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GetFileRequest : RequestBase<File>
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string FileId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
	}

	public GetFileRequest(string fileId)
		: base("getFile")
	{
		object_0 = fileId;
	}
}
