using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot3", Namespace = "exampleNs")]
[ProtoContract(Name = "Hardware")]
public struct Hardware
{
    [ProtoMember(1, Name = "Caption")]
    [DataMember(Name = "Field1")]
    public string Caption { get; set; }

    [ProtoMember(2, Name = "Parameter")]
    [DataMember(Name = "Field2")]
    public string Parameter { get; set; }

    [ProtoMember(3, Name = "HardType")]
    [DataMember(Name = "Field3")]
    public HardwareType HardType { get; set; }

    public override string ToString()
    {
        return "Name: " + Caption + "," + ((HardType == HardwareType.Field1) ? (" " + Parameter + " Cores") : (" " + Parameter + " bytes"));
    }
}
