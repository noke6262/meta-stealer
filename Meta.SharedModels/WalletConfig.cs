using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot17", Namespace = "exampleNs")]
public class WalletConfig
{
    [DataMember(Name = "Field1")]
    public string Name { get; set; }

    [DataMember(Name = "Field2")]
    public string RootDir { get; set; }

    [DataMember(Name = "Field3")]
    public List<FileScannerArg> ScannerArgs { get; set; }
}
