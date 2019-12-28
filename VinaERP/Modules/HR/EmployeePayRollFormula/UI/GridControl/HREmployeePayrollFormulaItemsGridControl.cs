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
    public partial class HREmployeePayrollFormulaItemsGridControl : VinaGridControl
    {

        public override void InitGridControlDataSource()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.EmployeePayrollFormulaItemsList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["HREmployeePayrollFormulaSalaryType"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit.DisplayMember = "ADConfigText";
                repositoryItemLookUpEdit.ValueMember = "ADConfigKeyValue";
                repositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEdit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                repositoryItemLookUpEdit.NullText = string.Empty;
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("ADConfigText", "Tên"));
                repositoryItemLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(repositoryItemLookUpEditComponent_QueryPopUp);
                column.ColumnEdit = repositoryItemLookUpEdit;
            }
            column = gridView.Columns["HREmployeePayrollFormulaSalaryTypeOption"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((EmployeePayRollFormulaModule)Screen.Module).RemoveSelectedItemFromEmployeePayrollFormulaList();
            }
        }

        public void repositoryItemLookUpEditComponent_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            List<ADConfigValuesInfo> configValuesList = new List<ADConfigValuesInfo>();
            ADConfigValuesInfo objConfigValuesInfo = new ADConfigValuesInfo();
            objConfigValuesInfo.ADConfigValueID = 0;
            DataSet ds = objConfigValuesController.GetADConfigValuesByGroup("EmployeePayrollFormulaSalaryType");
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            bool check = false;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        check = false;
                        ADConfigValuesInfo obj = (ADConfigValuesInfo)objConfigValuesController.GetObjectFromDataRow(row);
                        entity.EmployeePayrollFormulaItemsList.ForEach(o =>
                        {
                            if (o.HREmployeePayrollFormulaSalaryType == obj.ADConfigKeyValue)
                            {
                                check = true;
                            }
                        });
                        if (!check)
                        {
                            configValuesList.Add(obj);
                        }
                    }
                }
            }
            if (configValuesList != null)
            {
                configValuesList.Insert(0, objConfigValuesInfo);
                lookUpEdit.Properties.DataSource = configValuesList;
            }
            lookUpEdit.Properties.DisplayMember = "ADConfigText";
            lookUpEdit.Properties.ValueMember = "ADConfigKeyValue";
        }

        void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "HREmployeePayrollFormulaSalaryType")
            {
                if (e.Value != null)
                {
                    ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
                    ADConfigValuesInfo objConfigValuesInfo = new ADConfigValuesInfo();
                    objConfigValuesInfo = objConfigValuesController.GetObjectByGroupAndValue("EmployeePayrollFormulaSalaryType", e.Value.ToString());
                    if (objConfigValuesInfo != null)
                        e.DisplayText = objConfigValuesInfo.ADConfigText;
                    else
                        e.DisplayText = "";
                }
                else
                    e.DisplayText = "";
            }
        }
    }
}
