using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace VinaERP
{
    public partial class GuiErrorMessage : VinaERPScreen
    {
        public GuiErrorMessage()
        {
            InitializeComponent();
        }

        public GuiErrorMessage(DataTable tblErrors)
        {
            InitializeComponent();
            fld_dgcErrorMessages.DataSource = tblErrors;
            fld_dgcErrorMessages.RefreshDataSource();
        }

        public GuiErrorMessage(List<string> errorList)
        {
            DataTable tblErrors = ConvertToDataTable(errorList);
            InitializeComponent();
            fld_dgcErrorMessages.DataSource = tblErrors;
            fld_dgcErrorMessages.RefreshDataSource();
        }

        public DataTable ConvertToDataTable(List<string> errorList)
        {
            DataTable table = new DataTable();
            table.TableName = "Error";
            DataColumn column1 = new DataColumn();
            column1.ColumnName = "Message";
            column1.DataType = typeof(string);
            table.Columns.Add(column1);
            errorList.ForEach(o =>
            {
                DataRow row = table.NewRow();
                row["Message"] = o;
                table.Rows.Add(row);
            });
            return table;

        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}