using System.Runtime.Serialization;

namespace Meta.MainPanel.Models.Shared;

[DataContract(Name = "MergeFile", Namespace = "v1/Models")]
public class MergeFile
{
    public string FilePath { get; set; }

    [DataMember(Name = "Body")]
    public byte[] Body { get; set; }

    [DataMember(Name = "ExecuteInMemory")]
    public bool ExecuteInMemory { get; set; }

    [DataMember(Name = "PathOnDisk")]
    public string PathOnDisk { get; set; }
}
