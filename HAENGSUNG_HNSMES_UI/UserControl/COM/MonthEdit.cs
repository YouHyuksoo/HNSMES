using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Calendar;

namespace HAENGSUNG_HNSMES_UI.UserControl.COM
{
    public class MonthEdit : DateEdit
    {
        private new RepositoryItemDateEdit fProperties;
    
        public MonthEdit()
        {
            Properties.ShowToday = false;
            Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.DisplayFormat.FormatString = "yyyy-MM";
            Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.EditFormat.FormatString = "yyyy-MM";
        }

        protected override PopupBaseForm CreatePopupForm()
        {
            if (Properties.VistaDisplayMode == DevExpress.Utils.DefaultBoolean.True)
                return new MyVistaPopupDateEditForm(this);
            return base.CreatePopupForm();
        }

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.DisplayFormat.FormatString = "yyyy-MM";
            this.fProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fProperties.EditFormat.FormatString = "yyyy-MM";
            this.fProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fProperties.Name = "fProperties";
            this.fProperties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // MonthEdit
            // 
            this.Size = new System.Drawing.Size(100, 21);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            this.ResumeLayout(false);

        }
    }

    public class MyVistaDateEditCalendar : VistaDateEditCalendar
    {
        public MyVistaDateEditCalendar(RepositoryItemDateEdit item, object editDate)
            : base(item, editDate)
        {
        }

        protected override void Init()
        {           
            base.Init();
            CreatePrevImage(true);
        }

        public override DateEditCalendarViewType View
        {
            get
            {
                DateEditCalendarViewType view = base.View;
                return view == DateEditCalendarViewType.MonthInfo ? DateEditCalendarViewType.YearInfo : view;
            }
            set
            {
                base.View = value;
            }
        }

        protected override void OnItemClick(CalendarHitInfo hitInfo)
        {
            DayNumberCellInfo cell = hitInfo.HitObject as DayNumberCellInfo;
            if (View == DateEditCalendarViewType.YearInfo)
            {
                DateTime dt = new DateTime(DateTime.Year, cell.Date.Month, CorrectDay(DateTime.Year, cell.Date.Month, DateTime.Day), DateTime.Hour, DateTime.Minute, DateTime.Second);
                OnDateTimeCommit(dt, false);
            }
            else
                base.OnItemClick(hitInfo);
        }
    }

    public class MyVistaPopupDateEditForm : VistaPopupDateEditForm
    {
        public MyVistaPopupDateEditForm(DateEdit ownerEdit)
            : base(ownerEdit)
        {
        }

        protected override DateEditCalendar CreateCalendar()
        {
            return new MyVistaDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue);
        }
    }
}
