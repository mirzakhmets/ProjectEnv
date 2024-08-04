// Decompiled with JetBrains decompiler
// Type: ProjectEnv.Properties.Settings
// Assembly: ProjectEnv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0D679241-47E7-42FF-9AF5-F373CF8A326D
// Assembly location: C:\ProjectEnv\ProjectEnv.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

#nullable disable
namespace ProjectEnv.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
