using System;
using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

namespace IDAT.GZipEncoder;

public class GZipMessageEncodingElement : BindingElementExtensionElement
{
	public override Type BindingElementType => typeof(GZipMessageEncodingBindingElement);

	[ConfigurationProperty("innerMessageEncoding", DefaultValue = "textMessageEncoding")]
	public string InnerMessageEncoding
	{
		get
		{
			return (string)base["innerMessageEncoding"];
		}
		set
		{
			base["innerMessageEncoding"] = value;
		}
	}

	public override void ApplyConfiguration(BindingElement bindingElement)
	{
		GZipMessageEncodingBindingElement gZipMessageEncodingBindingElement = (GZipMessageEncodingBindingElement)bindingElement;
		PropertyInformationCollection properties = base.ElementInformation.Properties;
		if (properties["innerMessageEncoding"].ValueOrigin != PropertyValueOrigin.Default)
		{
			switch (InnerMessageEncoding)
			{
			case "textMessageEncoding":
				gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
				break;
			case "binaryMessageEncoding":
				gZipMessageEncodingBindingElement.InnerMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
				break;
			}
		}
	}

	protected override BindingElement CreateBindingElement()
	{
		GZipMessageEncodingBindingElement gZipMessageEncodingBindingElement = new GZipMessageEncodingBindingElement();
		ApplyConfiguration(gZipMessageEncodingBindingElement);
		return gZipMessageEncodingBindingElement;
	}
}
