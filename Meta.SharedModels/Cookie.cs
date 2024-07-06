using ProtoBuf;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[DataContract(Name = "FieldRoot10", Namespace = "exampleNs")]
[ProtoContract(Name = "Cookie")]
public struct Cookie
{
    [DataMember(Name = "Field1")]
    [ProtoMember(1, Name = "Host")]
    public string Host { get; set; }

    [ProtoMember(2, Name = "Http")]
    [DataMember(Name = "Field2")]
    public bool Http { get; set; }

    [ProtoMember(3, Name = "Path")]
    [DataMember(Name = "Field3")]
    public string Path { get; set; }

    [ProtoMember(4, Name = "Secure")]
    [DataMember(Name = "Field4")]
    public bool Secure { get; set; }

    [ProtoMember(5, Name = "Expires")]
    [DataMember(Name = "Field5")]
    public long Expires { get; set; }

    [ProtoMember(6, Name = "Name")]
    [DataMember(Name = "Field6")]
    public string Name { get; set; }

    [DataMember(Name = "Field7")]
    [ProtoMember(7, Name = "Value")]
    public string Value { get; set; }

    public string ToText()
    {
        return string.Join("\t", Host, Http.ToString().ToUpper(), Path, Secure.ToString().ToUpper(), Expires.ToString(), Name, Value);
    }
}
