using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace IDAT_Common.Serial;

public class ConfigXML
{
	private string _configFileName = "";

	private XmlDocument _xmlDoc = new XmlDocument();

	public string ConfigFileName
	{
		get
		{
			return _configFileName;
		}
		set
		{
			_configFileName = value;
		}
	}

	public XmlDocument XmlDoc
	{
		get
		{
			return _xmlDoc;
		}
		set
		{
			_xmlDoc = value;
		}
	}

	public ConfigXML(string fileName)
	{
		try
		{
			_configFileName = fileName;
			_xmlDoc.Load(AppPath() + _configFileName);
		}
		catch
		{
			MessageBox.Show("The file not found");
		}
	}

	public ConfigXML(string fileName, bool bCreate)
	{
		try
		{
			_configFileName = fileName;
			if (bCreate)
			{
				if (File.Exists(AppPath() + fileName))
				{
					File.Delete(AppPath() + fileName);
				}
				XmlWriterSettings settings = new XmlWriterSettings
				{
					Indent = true,
					IndentChars = ""
				};
				XmlWriter xmlWriter = null;
				xmlWriter = XmlWriter.Create(AppPath() + fileName, settings);
				xmlWriter.WriteStartElement("configuration");
				xmlWriter.WriteEndElement();
				xmlWriter.Flush();
				xmlWriter.Close();
				_xmlDoc.Load(AppPath() + _configFileName);
			}
			else
			{
				_xmlDoc.Load(AppPath() + _configFileName);
			}
		}
		catch
		{
			MessageBox.Show("The file not found");
		}
	}

	public string AppPath()
	{
		string text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\";
		if (text.StartsWith("file:\\"))
		{
			text = text.Substring(6);
		}
		return text;
	}

	public void CreateAppSetting(string settingName, string settingValue)
	{
		XmlNode appSettingNode = GetAppSettingNode(settingName, createIfNotFound: true);
		_xmlDoc.Save(_configFileName);
	}

	public XmlNode GetAppSettingNode(string settingName, bool createIfNotFound)
	{
		try
		{
			XmlNode documentElement = _xmlDoc.DocumentElement;
			XmlNode xmlNode = null;
			foreach (XmlNode item in documentElement)
			{
				if (item.Attributes["key"].Value == settingName)
				{
					xmlNode = item;
					break;
				}
				if (xmlNode == null && createIfNotFound)
				{
					xmlNode = AddAppSetting(settingName, null);
				}
			}
			return xmlNode;
		}
		catch
		{
			MessageBox.Show("The configure file doesn't work correclty.");
			return null;
		}
	}

	public XmlNode AddAppSetting(string settingName, string settingValue)
	{
		XmlNode documentElement = _xmlDoc.DocumentElement;
		XmlAttribute xmlAttribute = _xmlDoc.CreateAttribute("key");
		xmlAttribute.Value = settingName;
		XmlAttribute xmlAttribute2 = _xmlDoc.CreateAttribute("value");
		if (settingName == null)
		{
			xmlAttribute2.Value = string.Empty;
		}
		else
		{
			xmlAttribute2.Value = settingValue;
		}
		XmlNode xmlNode = _xmlDoc.CreateElement("add");
		xmlNode.Attributes.Append(xmlAttribute);
		xmlNode.Attributes.Append(xmlAttribute2);
		documentElement.AppendChild(xmlNode);
		return xmlNode;
	}

	public string GetAppSetting(string settingName)
	{
		XmlNode appSettingNode = GetAppSettingNode(settingName, createIfNotFound: false);
		if (appSettingNode == null)
		{
			return string.Empty;
		}
		return appSettingNode.Attributes["value"].Value;
	}

	public void SetAppSetting(string settingName, string settingValue, bool createIfNotExist)
	{
		try
		{
			XmlNode appSettingNode = GetAppSettingNode(settingName, createIfNotExist);
			if (appSettingNode != null)
			{
				appSettingNode.Attributes["value"].Value = settingValue;
				_xmlDoc.Save(_configFileName);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public XmlNodeList GetNodeList(string Name)
	{
		return _xmlDoc.GetElementsByTagName(Name);
	}
}
