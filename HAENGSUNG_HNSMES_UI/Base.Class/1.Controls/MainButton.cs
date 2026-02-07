using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAENGSUNG_HNSMES_UI.Base.Class.Controls
{
    public interface IMainButtons
    {
        void PerformClick();
        bool IsUse { get; set; }
    }

    public class RibbonMainButton : DevExpress.XtraBars.BarButtonItem, IMainButtons
    {
        public bool IsUse
        {
            get
            {
                return this.Enabled;
            }
            set
            {
                this.Enabled = value;
                if (Program.frmM != null)
                {
                    if (Program.frmM.ActiveMdiChild != null)
                    {
                        Forms.BASE.Form baseFrm = Program.frmM.ActiveMdiChild as Forms.BASE.Form;
                        if (this.Equals(Program.frmM.btnDelete) || this.Equals(Program.frmM.btnDelete1))
                            baseFrm.IsButtonDeleteEnable = value;

                        if (this.Equals(Program.frmM.btnNew) || this.Equals(Program.frmM.btnNew1))
                            baseFrm.IsButtonNewEnable = value;

                        if (this.Equals(Program.frmM.btnEdit) || this.Equals(Program.frmM.btnEdit1))
                            baseFrm.IsButtonEditEnable = value;

                        if (this.Equals(Program.frmM.btnSave) || this.Equals(Program.frmM.btnSave1))
                            baseFrm.IsButtonSaveEnable = value;

                        if (this.Equals(Program.frmM.btnInit) || this.Equals(Program.frmM.btnInit1))
                            baseFrm.IsButtonInitEnable = value;

                        if (this.Equals(Program.frmM.btnRefresh) || this.Equals(Program.frmM.btnRefresh1))
                            baseFrm.IsButtonRefreshEnable = value;

                        if (this.Equals(Program.frmM.btnStop) || this.Equals(Program.frmM.btnStop1))
                            baseFrm.IsButtonStopEnable = value;

                        if (this.Equals(Program.frmM.btnPrint) || this.Equals(Program.frmM.btnPrint1))
                            baseFrm.IsButtonPrintEnable = value;
                    }
                }
            }
        }

        void IMainButtons.PerformClick()
        {
            this.PerformClick();
        }
    }

    public class NormalMainButton : DevExpress.XtraEditors.SimpleButton, IMainButtons
    {
        public bool IsUse
        {
            get
            {
                return this.Enabled;
            }
            set
            {
                this.Enabled = value;
                if (Program.frmM != null)
                {
                    if (Program.frmM.ActiveMdiChild != null)
                    {
                        Forms.BASE.Form baseFrm = Program.frmM.ActiveMdiChild as Forms.BASE.Form;
                        if (this.Equals(Program.frmM.btnDelete) || this.Equals(Program.frmM.btnDelete1))
                            baseFrm.IsButtonDeleteEnable = value;

                        if (this.Equals(Program.frmM.btnNew) || this.Equals(Program.frmM.btnNew1))
                            baseFrm.IsButtonNewEnable = value;

                        if (this.Equals(Program.frmM.btnEdit) || this.Equals(Program.frmM.btnEdit1))
                            baseFrm.IsButtonEditEnable = value;

                        if (this.Equals(Program.frmM.btnSave) || this.Equals(Program.frmM.btnSave1))
                            baseFrm.IsButtonSaveEnable = value;

                        if (this.Equals(Program.frmM.btnInit) || this.Equals(Program.frmM.btnInit1))
                            baseFrm.IsButtonInitEnable = value;

                        if (this.Equals(Program.frmM.btnRefresh) || this.Equals(Program.frmM.btnRefresh1))
                            baseFrm.IsButtonRefreshEnable = value;

                        if (this.Equals(Program.frmM.btnStop) || this.Equals(Program.frmM.btnStop1))
                            baseFrm.IsButtonStopEnable = value;

                        if (this.Equals(Program.frmM.btnPrint) || this.Equals(Program.frmM.btnPrint1))
                            baseFrm.IsButtonPrintEnable = value;

                    }
                }
            }
        }

        void IMainButtons.PerformClick()
        {
            this.PerformClick();
        }
    }
}
