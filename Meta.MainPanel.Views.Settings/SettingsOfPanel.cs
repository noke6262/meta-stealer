using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Meta.MainPanel.Views.Settings;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
internal sealed class SettingsOfPanel : ApplicationSettingsBase
{
    private static object object_0 = (SettingsOfPanel)SettingsBase.Synchronized(new SettingsOfPanel());

    public static SettingsOfPanel Default => (SettingsOfPanel)object_0;

    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    [UserScopedSetting]
    public string ServerIP
    {
        get
        {
            return (string)this["ServerIP"];
        }
        set
        {
            this["ServerIP"] = value;
        }
    }

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string LogHeader
    {
        get
        {
            return (string)this["LogHeader"];
        }
        set
        {
            this["LogHeader"] = value;
        }
    }
}
