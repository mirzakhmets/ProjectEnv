// Decompiled with JetBrains decompiler
// Type: ProjectEnv.Properties.Resources
// Assembly: ProjectEnv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0D679241-47E7-42FF-9AF5-F373CF8A326D
// Assembly location: C:\ProjectEnv\ProjectEnv.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace ProjectEnv.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ProjectEnv.Properties.Resources.resourceMan == null)
          ProjectEnv.Properties.Resources.resourceMan = new ResourceManager("ProjectEnv.Properties.Resources", typeof (ProjectEnv.Properties.Resources).Assembly);
        return ProjectEnv.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ProjectEnv.Properties.Resources.resourceCulture;
      set => ProjectEnv.Properties.Resources.resourceCulture = value;
    }
  }
}
