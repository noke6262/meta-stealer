using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot8", Namespace = "exampleNs")]
[ProtoContract(Name = "Autofill")]
public struct Autofill
{
    [DataMember(Name = "Field1")]
    [ProtoMember(1, Name = "Name")]
    public string Name { get; set; }

    [DataMember(Name = "Field2")]
    [ProtoMember(2, Name = "Value")]
    public string Value { get; set; }
}
