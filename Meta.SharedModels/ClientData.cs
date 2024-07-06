using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[ProtoContract(Name = "ClientData")]
[DataContract(Name = "ClientData", Namespace = "v1/Models")]
public struct ClientData
{
    [DataMember(Name = "Login")]
    [ProtoMember(2, Name = "Login")]
    public string Login { get; set; }

    [DataMember(Name = "Password")]
    [ProtoMember(3, Name = "Password")]
    public string Password { get; set; }
}
