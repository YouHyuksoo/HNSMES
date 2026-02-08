using System.Collections.Generic;

namespace IDAT_Common.Utility;

public class ScannerSettingInfomationCollection
{
	private List<ScannerSettingInfo> mScannerSettingInfoCollection = new List<ScannerSettingInfo>();

	public List<ScannerSettingInfo> ScannerSettingInfoCollection
	{
		get
		{
			return mScannerSettingInfoCollection;
		}
		set
		{
			mScannerSettingInfoCollection = value;
		}
	}
}
