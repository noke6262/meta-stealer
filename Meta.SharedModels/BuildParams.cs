using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "BuildParams", Namespace = "v1/Models")]
public class BuildParams
{
    [DataMember(Name = "BuildType")]
    public BuildType BuildType { get; set; }

    [DataMember(Name = "Client")]
    public ClientData Client { get; set; }

    [DataMember(Name = "IP")]
    public string IP { get; set; }

    [DataMember(Name = "BuildID")]
    public string BuildID { get; set; }

    [DataMember(Name = "Message")]
    public string Message { get; set; }
}
