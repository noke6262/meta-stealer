using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[ProtoContract(Name = "AccountDetails")]
[DataContract(Name = "FieldRootAc", Namespace = "exampleNs")]
public class AccountDetails
{
    [ProtoMember(1, Name = "Id")]
    [DataMember(Name = "Field2")]
    public string Id { get; set; }

    [ProtoMember(2, Name = "Token")]
    [DataMember(Name = "Field3")]
    public string Token { get; set; }
}
