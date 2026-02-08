using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace IDAT.Properties;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager resourceManager = new ResourceManager("IDAT.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap msgbox_error
	{
		get
		{
			object obj = ResourceManager.GetObject("msgbox_error", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap msgbox_fail
	{
		get
		{
			object obj = ResourceManager.GetObject("msgbox_fail", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap msgbox_information
	{
		get
		{
			object obj = ResourceManager.GetObject("msgbox_information", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap msgbox_question
	{
		get
		{
			object obj = ResourceManager.GetObject("msgbox_question", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap msgbox_question1
	{
		get
		{
			object obj = ResourceManager.GetObject("msgbox_question1", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap msgbox_warning
	{
		get
		{
			object obj = ResourceManager.GetObject("msgbox_warning", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal Resources()
	{
	}
}
