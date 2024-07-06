using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot14", Namespace = "exampleNs")]
public enum HardwareType : uint
{
    [EnumMember]
    Field1,
    [EnumMember]
    Field2
}
