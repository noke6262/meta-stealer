using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "BuildType", Namespace = "v1/Models")]
public enum BuildType
{
    [EnumMember(Value = "0")]
    Exe,
    [EnumMember(Value = "1")]
    JS,
    [EnumMember(Value = "2")]
    VBS,
    [EnumMember(Value = "3")]
    Native
}
