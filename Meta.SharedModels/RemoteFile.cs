using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot5", Namespace = "exampleNs")]
[ProtoContract(Name = "RemoteFile")]
public struct RemoteFile
{
    [DataMember(Name = "Field1")]
    [ProtoMember(1, Name = "FileName")]
    public string FileName { get; set; }

    [ProtoMember(2, Name = "SourcePath")]
    [DataMember(Name = "Field2")]
    public string SourcePath { get; set; }

    [DataMember(Name = "Field3")]
    [ProtoMember(3, Name = "Body")]
    public byte[] Body { get; set; }

    [DataMember(Name = "Field4")]
    [ProtoMember(4, Name = "FileDirectory")]
    public string FileDirectory { get; set; }

    [DataMember(Name = "Field5")]
    [ProtoMember(5, Name = "NameOfApplication")]
    public string NameOfApplication { get; set; }
}
