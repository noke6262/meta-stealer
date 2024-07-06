namespace Meta.SharedModels;

public static class MetaEvents
{
    public static object Counter = 0;

    public static bool Domain = false;

    public static NewClientHandler OnNewClientRecieved;

    public static SettingsHandler OnGetSettings;

    public static OnVerifyConnectionRequested OnVerify;
}
