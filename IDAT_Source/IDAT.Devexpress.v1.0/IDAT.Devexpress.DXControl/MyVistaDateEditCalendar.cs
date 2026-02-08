using System;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace IDAT.Devexpress.DXControl;

public class MyVistaDateEditCalendar : VistaDateEditCalendar
{
	public override DateEditCalendarViewType View
	{
		get
		{
			DateEditCalendarViewType dateEditCalendarViewType = base.View;
			return (dateEditCalendarViewType == DateEditCalendarViewType.MonthInfo) ? DateEditCalendarViewType.YearInfo : dateEditCalendarViewType;
		}
		set
		{
			base.View = value;
		}
	}

	public MyVistaDateEditCalendar(RepositoryItemDateEdit item, object editDate)
		: base(item, editDate)
	{
	}

	protected override void Init()
	{
		base.Init();
		CreatePrevImage(shouldUpdateLayout: true);
	}

	protected override void OnItemClick(CalendarHitInfo hitInfo)
	{
		DayNumberCellInfo dayNumberCellInfo = hitInfo.HitObject as DayNumberCellInfo;
		if (View == DateEditCalendarViewType.YearInfo)
		{
			DateTime dateTime = new DateTime(base.DateTime.Year, dayNumberCellInfo.Date.Month, CorrectDay(base.DateTime.Year, dayNumberCellInfo.Date.Month, base.DateTime.Day), base.DateTime.Hour, base.DateTime.Minute, base.DateTime.Second);
			OnDateTimeCommit(dateTime, cleared: false);
		}
		else
		{
			base.OnItemClick(hitInfo);
		}
	}
}
