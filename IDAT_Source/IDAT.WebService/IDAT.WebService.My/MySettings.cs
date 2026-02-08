using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace IDAT.WebService.My;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
[CompilerGenerated]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());

	public static MySettings Default => defaultInstance;

	[DefaultSettingValue("http://100.100.100.173:8807/semp_mrv/IDAT_WebSvr.asmx")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	[SpecialSetting(SpecialSetting.WebServiceUrl)]
	public string IDAT_WebService_IDAT_WebSvr_IDAT_WebSvr => Conversions.ToString(this["IDAT_WebService_IDAT_WebSvr_IDAT_WebSvr"]);

	[DebuggerNonUserCode]
	public MySettings()
	{
	}
}
