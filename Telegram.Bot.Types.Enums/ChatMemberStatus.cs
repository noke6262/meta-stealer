using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum ChatMemberStatus
{
    [EnumMember(Value = "creator")]
    Creator,
    [EnumMember(Value = "administrator")]
    Administrator,
    [EnumMember(Value = "member")]
    Member,
    [EnumMember(Value = "left")]
    Left,
    [EnumMember(Value = "kicked")]
    Kicked,
    [EnumMember(Value = "restricted")]
    Restricted
}
