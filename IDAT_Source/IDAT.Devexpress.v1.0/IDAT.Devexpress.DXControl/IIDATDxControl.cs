using DevExpress.XtraGrid;

namespace IDAT.Devexpress.DXControl;

public interface IIDATDxControl
{
	GridControl BindGridControl { get; set; }

	string BindColumnName { get; set; }

	EditModes BindEditMode { get; set; }

	bool BindPK { get; set; }

	bool ValidationCheck { get; set; }

	bool IsUseIDATFrameWorkControl { get; set; }
}
