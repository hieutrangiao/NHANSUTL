using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace VinaERP.Report
{
    public partial class BaseReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BaseReport()
        {
            BeforePrint += new System.Drawing.Printing.PrintEventHandler(BaseReport_BeforePrint);
        }

        private void BaseReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            foreach (Band band in Bands)
            {
                SetTextTableCell(band);
            }
        }

        /// <summary>
        /// Set text for table cell 
        /// </summary>
        /// <param name="band">Given band in report</param>
        public void SetTextTableCell(Band band)
        {
            foreach (XRControl control in band)
            {
                if (control.GetType() == typeof(XRTable))
                {
                    XRTable table = (XRTable)control;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        foreach (XRTableCell tableCell in table.Rows[i].Cells)
                        {
                            if (tableCell.DataBindings.Count > 0)
                                tableCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(TableCell_BeforePrint);
                        }
                    }
                }
            }
        }

        private void TableCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell tableCell = (XRTableCell)sender;
            SetTextTableCell(tableCell);
        }

        /// <summary>
        /// Set text for table cell 
        /// </summary>
        /// <param name="tableCell">Given table cell</param>
        public virtual void SetTextTableCell(XRTableCell tableCell)
        {
            if (!string.IsNullOrEmpty(tableCell.Text))
            {
                XRBinding biding = tableCell.DataBindings[0];
                double cellValue = 0;
                if (double.TryParse(tableCell.Text, out cellValue))
                {
                    if (cellValue < 0)
                    {
                        if (tableCell.Text.StartsWith("-"))
                        {
                            tableCell.Text = tableCell.Text.Remove(0, 1);
                        }
                        tableCell.Text = string.Format("({0})", tableCell.Text);
                        tableCell.ForeColor = Color.Red;
                    }
                    else if (cellValue > 0)
                    {
                        tableCell.ForeColor = Color.Black;
                    }
                    else if (cellValue == 0)
                    {
                        //tableCell.Text = string.Empty;
                    }
                }
                else
                {
                    DateTime dateTime = DateTime.MaxValue;
                    if (DateTime.TryParse(tableCell.Text, out dateTime))
                    {
                        if (dateTime.Date == DateTime.MaxValue.Date)
                        {
                            tableCell.Text = string.Empty;
                        }
                    }
                }
            }
        }
    }
}
