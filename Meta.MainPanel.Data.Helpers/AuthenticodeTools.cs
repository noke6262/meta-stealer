using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Meta.MainPanel.Data.Helpers;

internal static class AuthenticodeTools
{
    [DllImport("Wintrust.dll")]
    private static extern uint WinVerifyTrust(IntPtr hWnd, IntPtr pgActionID, IntPtr pWinTrustData);

    private static uint smethod_0(object fileName)
    {
        Guid structure = new Guid("{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}");
        uint num = 0u;
        using WINTRUST_FILE_INFO fileInfo = new WINTRUST_FILE_INFO((string)fileName, Guid.Empty);
        using UnmanagedPointer unmanagedPointer = new UnmanagedPointer(Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid))), AllocMethod.HGlobal);
        using UnmanagedPointer unmanagedPointer2 = new UnmanagedPointer(Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WINTRUST_DATA))), AllocMethod.HGlobal);
        WINTRUST_DATA structure2 = new WINTRUST_DATA(fileInfo);
        IntPtr intPtr = unmanagedPointer;
        IntPtr intPtr2 = unmanagedPointer2;
        Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
        Marshal.StructureToPtr(structure2, intPtr2, fDeleteOld: true);
        return WinVerifyTrust(IntPtr.Zero, intPtr, intPtr2);
    }

    public static bool IsTrusted(string fileName, bool extraCheck, string expectedName = null, string serialNumber = null)
    {
        bool result = false;
        uint num = 1u;
        bool flag = string.IsNullOrWhiteSpace(expectedName) && string.IsNullOrWhiteSpace(serialNumber);
        try
        {
            using X509Certificate2 certificate = new X509Certificate2(fileName);
            X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
            x509Certificate2Collection.Import(fileName);
            if (!flag)
            {
                X509Certificate2Enumerator enumerator = x509Certificate2Collection.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    X509Certificate2 current = enumerator.Current;
                    if (IsSelfSigned(current))
                    {
                        break;
                    }
                    if ((string.IsNullOrWhiteSpace(expectedName) || current.GetNameInfo(X509NameType.SimpleName, forIssuer: false) == expectedName) && (string.IsNullOrWhiteSpace(serialNumber) || current.GetSerialNumberString().ToUpper() == serialNumber.ToUpper()))
                    {
                        flag = true;
                    }
                }
            }
            X509Chain x509Chain = new X509Chain();
            x509Chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            if (!(fileName == Application.ExecutablePath))
            {
                x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
            }
            else
            {
                x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            }
            x509Chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
            x509Chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
            x509Chain.ChainPolicy.ExtraStore.AddRange(x509Certificate2Collection);
            result = x509Chain.Build(certificate);
            num = ((fileName == Application.ExecutablePath) ? ((WinTrust.VerifyEmbeddedSignature(fileName) != WinVerifyTrustResult.SubjectCertificateRevoked && WinTrust.VerifyEmbeddedSignature(fileName) != 0) ? 1u : 0u) : ((WinTrust.VerifyEmbeddedSignature(fileName) != 0) ? 1u : 0u));
        }
        catch (Exception)
        {
        }
        if (num == 0 && flag)
        {
            if (!extraCheck)
            {
                return true;
            }
            return result;
        }
        return false;
    }

    public static bool IsSelfSigned(X509Certificate2 cert)
    {
        return cert.SubjectName.RawData.SequenceEqual(cert.IssuerName.RawData);
    }

    public static X509Certificate2Collection FindCerts(string serialNumber)
    {
        X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
        X509FindType findType = X509FindType.FindBySerialNumber;
        using (X509Store x509Store = new X509Store(StoreLocation.LocalMachine))
        {
            x509Store.Open(OpenFlags.OpenExistingOnly);
            x509Certificate2Collection.AddRange(x509Store.Certificates.Find(findType, serialNumber, validOnly: true));
        }
        using X509Store x509Store2 = new X509Store(StoreLocation.CurrentUser);
        x509Store2.Open(OpenFlags.OpenExistingOnly);
        x509Certificate2Collection.AddRange(x509Store2.Certificates.Find(findType, serialNumber, validOnly: true));
        return x509Certificate2Collection;
    }
}
