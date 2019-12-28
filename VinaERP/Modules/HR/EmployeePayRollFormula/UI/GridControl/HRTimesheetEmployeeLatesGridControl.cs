using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaLib;

namespace VinaERP.Modules.EmployeePayRollFormula
{
    public partial class HRTimesheetEmployeeLatesGridControl : VinaGridControl
    {

        public override void InitGridControlDataSource()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.TimesheetEmployeeLatesList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            foreach (GridColumn col in gridView.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
            }
            gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);

        }

        void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "FK_HRTimesheetEmployeeLateConfigID")
            {
                if (e.Value != null)
                {
                    int matchCodeID = int.Parse(e.Value.ToString());
                    HRTimesheetEmployeeLateConfigsController objHRTimesheetEmployeeLateConfigsController = new HRTimesheetEmployeeLateConfigsController();
                    HRTimesheetEmployeeLateConfigsInfo objTimesheetEmployeeLateConfigsInfo = (HRTimesheetEmployeeLateConfigsInfo)objHRTimesheetEmployeeLateConfigsController.GetObjectByID(matchCodeID);
                    if (objTimesheetEmployeeLateConfigsInfo != null)
                        e.DisplayText = objTimesheetEmployeeLateConfigsInfo.HRTimesheetEmployeeLateConfigName;
                    else
                        e.DisplayText = "";
                }
                else
                    e.DisplayText = "";
            }
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["FK_HRTimesheetEmployeeLateConfigID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit.DisplayMember = "HRTimesheetEmployeeLateConfigName";
                repositoryItemLookUpEdit.ValueMember = "HRTimesheetEmployeeLateConfigID";
                repositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEdit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                repositoryItemLookUpEdit.NullText = string.Empty;
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("HRTimesheetEmployeeLateConfigName", "Tên"));
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("HRTimesheetEmployeeLateConfigTimeFrom", "Từ (Phút)"));
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("HRTimesheetEmployeeLateConfigTimeTo", "Đến (Phút)"));
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("HRTimesheetEmployeeLateConfigOTTime", "Thời gian bù (Phút)"));
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("HRTimesheetEmployeeLateConfigDeduct", "Số công khấu trừ"));
                repositoryItemLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(repositoryItemLookUpEdit_QueryPopUp2);
                column.ColumnEdit = repositoryItemLookUpEdit;
            }
            return gridView;
        }

        void repositoryItemLookUpEdit_QueryPopUp2(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;

            HRTimesheetEmployeeLateConfigsController objHRTimesheetEmployeeLateConfigsController = new HRTimesheetEmployeeLateConfigsController();
            List<HRTimesheetEmployeeLateConfigsInfo> list = (List<HRTimesheetEmployeeLateConfigsInfo>)objHRTimesheetEmployeeLateConfigsController.GetListFromDataSet(objHRTimesheetEmployeeLateConfigsController.GetAllObjects());
            List<HRTimesheetEmployeeLateConfigsInfo> finalList = new List<HRTimesheetEmployeeLateConfigsInfo>();
            finalList.Add(new HRTimesheetEmployeeLateConfigsInfo());
            finalList.AddRange(list);

            lookUpEdit.Properties.DataSource = finalList;

            lookUpEdit.Properties.DisplayMember = "HRTimesheetEmployeeLateConfigName";
            lookUpEdit.Properties.ValueMember = "HRTimesheetEmployeeLateConfigID";
        }


        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            GridView gridView = (GridView)sender;
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    ((EmployeePayRollFormulaModule)Screen.Module).RemoveSelectedTimesheetEmployeeLate();
                }
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);

            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;

            if (entity.TimesheetEmployeeLatesList.CurrentIndex >= 0)
            {
                if (e.Column.FieldName == "FK_HRTimesheetEmployeeLateConfigID")
                {
                    ((EmployeePayRollFormulaModule)entity.Module).UpdateTimesheetEmployeeLate();
                }
            }
        }
    }
}
