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
using VinaCommon;
using VinaLib;

namespace VinaERP.Modules.EmployeePayRollFormula
{
    public partial class AllowanceConfigGridControl : VinaGridControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        public override void InitGridControlDataSource()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.AllowanceConfigsList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["FK_HRFormAllowanceID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;

                RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit.DisplayMember = "HRFormAllowanceName";
                repositoryItemLookUpEdit.ValueMember = "HRFormAllowanceID";
                repositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEdit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                repositoryItemLookUpEdit.NullText = string.Empty;
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("HRFormAllowanceName", "Tên phụ cấp"));
                repositoryItemLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(repositoryItemLookUpEditComponent_QueryPopUp);
                column.ColumnEdit = repositoryItemLookUpEdit;
            }

            column = gridView.Columns["HRAllowanceConfigFromDate"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HRAllowanceConfigToDate"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HRAllowanceConfigPercent"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.DisplayFormat.FormatType = FormatType.Numeric;
                column.DisplayFormat.FormatString = "{0:n3}";
            }

            column = gridView.Columns["HRAllowanceConfigAmount"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.DisplayFormat.FormatType = FormatType.Numeric;
                column.DisplayFormat.FormatString = "{0:n3}";
            }

            column = gridView.Columns["HRAllowanceConfigIsTimeKeeping"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            gridView.InvalidRowException += new InvalidRowExceptionEventHandler(GridView_InvalidRowException);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);
            return gridView;
        }

        void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "FK_HRFormAllowanceID")
            {
                if (e.Value != null)
                {
                    int id = 0;
                    Int32.TryParse(e.Value.ToString(), out id);
                    HRFormAllowancesController objFormAllowancesController = new HRFormAllowancesController();
                    HRFormAllowancesInfo objFormAllowancesInfo = new HRFormAllowancesInfo();
                    objFormAllowancesInfo = (HRFormAllowancesInfo)objFormAllowancesController.GetObjectByID(id);
                    if (objFormAllowancesInfo != null)
                        e.DisplayText = objFormAllowancesInfo.HRFormAllowanceName;
                    else
                        e.DisplayText = "";
                }
                else
                    e.DisplayText = "";
            }
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((EmployeePayRollFormulaModule)Screen.Module).RemoveSelectedAllowanceConfig();
            }
        }

        protected void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        public void repositoryItemLookUpEditComponent_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;

            HRFormAllowancesController objFormAllowancesController = new HRFormAllowancesController();
            List<HRFormAllowancesInfo> formAllowancesList = new List<HRFormAllowancesInfo>();
            HRFormAllowancesInfo objFormAllowancesInfo = new HRFormAllowancesInfo();
            formAllowancesList = objFormAllowancesController.GetHRFormAllowancesByFormAllowancesType(HRFormAllowanceType.MucChung.ToString());
            if (formAllowancesList != null)
            {
                formAllowancesList.Insert(0, objFormAllowancesInfo);
                lookUpEdit.Properties.DataSource = formAllowancesList;
            }
            lookUpEdit.Properties.DisplayMember = "HRFormAllowanceName";
            lookUpEdit.Properties.ValueMember = "HRFormAllowanceID";
        }

        protected override void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            base.GridView_ValidateRow(sender, e);
            ColumnView view = sender as ColumnView;
        }
    }
}
