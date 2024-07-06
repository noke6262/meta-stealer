using IPLocator;
using System.IO;

namespace Meta.MainPanel.Data.Helpers;

public static class IpLocator
{
    public static Component IPv4Locator;

    public static Component IPv6Locator;

    static IpLocator()
    {
        Load();
    }

    public static void Load()
    {
        try
        {
            IPv4Locator = new Component
            {
                IPDatabasePath = Directory.GetCurrentDirectory() + "\\IpDb\\IpDb.bin",
                MapFileName = Directory.GetCurrentDirectory() + "\\IpDb\\IpDb.bin",
                UseMemoryMappedFile = true
            };
            IPv4Locator.LoadBIN();
        }
        catch
        {
        }
        try
        {
            IPv6Locator = new Component
            {
                IPDatabasePath = Directory.GetCurrentDirectory() + "\\IpDb\\Ipv6Db.bin",
                MapFileName = Directory.GetCurrentDirectory() + "\\IpDb\\Ipv6Db.bin",
                UseMemoryMappedFile = true
            };
            IPv6Locator.LoadBIN();
        }
        catch
        {
        }
    }
}
