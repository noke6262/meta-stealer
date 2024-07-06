using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[ProtoContract(Name = "CreditCard")]
[DataContract(Name = "FieldRoot11", Namespace = "exampleNs")]
public struct CreditCard
{
    [DataMember(Name = "Field1")]
    [ProtoMember(1, Name = "Holder")]
    public string Holder { get; set; }

    [DataMember(Name = "Field2")]
    [ProtoMember(2, Name = "ExpirationMonth")]
    public byte ExpirationMonth { get; set; }

    [ProtoMember(3, Name = "ExpirationYear")]
    [DataMember(Name = "Field3")]
    public short ExpirationYear { get; set; }

    [ProtoMember(4, Name = "CardNumber")]
    [DataMember(Name = "Field4")]
    public string CardNumber { get; set; }
}
