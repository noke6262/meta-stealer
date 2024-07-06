using ProtoBuf;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Meta.SharedModels;

[ProtoContract(Name = "LoginPair")]
[DataContract(Name = "FieldRoot12", Namespace = "exampleNs")]
public struct LoginPair
{
    [ProtoMember(1, Name = "Host")]
    [DataMember(Name = "Field1")]
    public string Host { get; set; }

    [ProtoMember(2, Name = "Login")]
    [DataMember(Name = "Field2")]
    public string Login { get; set; }

    [ProtoMember(3, Name = "Password")]
    [DataMember(Name = "Field3")]
    public string Password { get; set; }

    public string FormatedString(string Format)
    {
        Regex regex = new Regex("{(\\w*)}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        MatchEvaluator evaluator = Evaluator;
        return regex.Replace(Format, evaluator);
    }

    private string Evaluator(Match match)
    {
        string empty = string.Empty;
        try
        {
            if (match.Groups.Count > 1)
            {
                string value = match.Groups[1].Value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    return empty;
                }
                PropertyInfo[] properties = GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(DataMemberAttribute), inherit: true);
                    if (customAttributes == null || customAttributes.Length == 0)
                    {
                        continue;
                    }
                    object[] array = customAttributes;
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (((DataMemberAttribute)array[j]).Name == value || propertyInfo.Name == value)
                        {
                            return propertyInfo.GetValue(this).ToString();
                        }
                    }
                }
            }
        }
        catch
        {
        }
        return empty;
    }
}
