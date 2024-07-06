using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot4", Namespace = "exampleNs")]
[ProtoContract(Name = "InstalledBrowserInfo")]
public struct InstalledBrowserInfo
{
    [ProtoMember(1, Name = "Name")]
    [DataMember(Name = "Field1")]
    public string Name { get; set; }

    [DataMember(Name = "Field2")]
    [ProtoMember(2, Name = "Version")]
    public string Version { get; set; }

    [DataMember(Name = "Field3")]
    [ProtoMember(3, Name = "Path")]
    public string Path { get; set; }
}
