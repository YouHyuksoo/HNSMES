using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;

namespace IDAT.Devexpress.DXControl;

public class MyVistaPopupDateEditForm : VistaPopupDateEditForm
{
	public MyVistaPopupDateEditForm(DateEdit ownerEdit)
		: base(ownerEdit)
	{
	}

	protected override DateEditCalendar CreateCalendar()
	{
		return new MyVistaDateEditCalendar(base.OwnerEdit.Properties, base.OwnerEdit.EditValue);
	}
}
