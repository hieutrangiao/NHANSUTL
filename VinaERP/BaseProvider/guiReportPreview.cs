using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars;
using System.Drawing.Printing;
using DevExpress.XtraPrinting.Native;

namespace VinaERP
{
    public partial class guiReportPreview : VinaERPScreen
    {
        public XtraReport Report { get; private set; }

        private PrinterSettings PrinterSettings;

        public guiReportPreview(XtraReport report, bool allowPrint = true)
        {
            InitializeComponent();

            Report = report;

            SetAllowPrint(true);
        }

        private void SetAllowPrint(bool allowPrint)
        {
            if (allowPrint)
            {
                fld_btnActionPrint.Visibility = BarItemVisibility.Always;
            }
            else
            {
                fld_btnActionPrint.Visibility = BarItemVisibility.Never;
            }
        }

        private void guiReportPreview_Load(object sender, EventArgs e)
        {
            fld_docViewControl.PrintingSystem = Report.PrintingSystem;
            Report.CreateDocument();
        }
    }
}