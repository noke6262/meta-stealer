using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot16", Namespace = "exampleNs")]
public class FileScannerArg
{
    [DataMember(Name = "Field1")]
    public string Directory { get; set; }

    [DataMember(Name = "Field2")]
    public string Pattern { get; set; }

    [DataMember(Name = "Field3")]
    public bool Recoursive { get; set; }
}
