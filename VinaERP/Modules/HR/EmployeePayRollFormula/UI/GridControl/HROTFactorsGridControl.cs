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
    public partial class HROTFactorsGridControl : VinaGridControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        public override void InitGridControlDataSource()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.OTFactorsList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            // repositoryItemDateEdit
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.EditFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Name = "repositoryItemDateEdit1";

            GridColumn column = gridView.Columns["HROTFactorValue"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["HROTFactorFromTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["HROTFactorType"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["FK_ADOTFactorID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit.DisplayMember = "ADOTFactorName";
                repositoryItemLookUpEdit.ValueMember = "ADOTFactorID";
                repositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEdit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                repositoryItemLookUpEdit.NullText = string.Empty;
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("ADOTFactorName", "Tên"));
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("ADOTFactorType", "Loại"));
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("ADOTFactorValue", "Hệ sô"));
                repositoryItemLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(repositoryItemLookUpEdit_QueryPopUp2);
                column.ColumnEdit = repositoryItemLookUpEdit;
            }

            column = gridView.Columns["HROTFactorToTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }
            gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(GridView_FocusedRowChanged);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);
            return gridView;
        }

        private void GridView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (e.KeyCode == Keys.Delete)
            {
                ((EmployeePayRollFormulaModule)Screen.Module).RemoveSelectedFactor();
            }
        }

        protected void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                GridView gridView = (GridView)MainView;
                HROTFactorsInfo objOTFactorsInfo = (HROTFactorsInfo)gridView.GetRow(e.FocusedRowHandle);
                if (String.IsNullOrEmpty(objOTFactorsInfo.HROTFactorType))
                {
                    objOTFactorsInfo.HROTFactorType = OTFactorType.WorkingDay.ToString();
                }
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
            if (entity.OTFactorsList.CurrentIndex >= 0)
            {
                if (e.Column.FieldName == "FK_ADOTFactorID")
                {
                    ((EmployeePayRollFormulaModule)entity.Module).UpdateHROTFactor();
                }
            }
        }

        void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "FK_ADOTFactorID")
            {
                if (e.Value != null)
                {
                    int matchCodeID = int.Parse(e.Value.ToString());
                    ADOTFactorsController objOTFactorsController = new ADOTFactorsController();
                    ADOTFactorsInfo objOTFactorsInfo = (ADOTFactorsInfo)objOTFactorsController.GetObjectByID(matchCodeID);
                    if (objOTFactorsInfo != null)
                        e.DisplayText = objOTFactorsInfo.ADOTFactorName;
                    else
                        e.DisplayText = "";
                }
                else
                    e.DisplayText = "";
            }
        }

        void repositoryItemLookUpEdit_QueryPopUp2(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            ADOTFactorsController objOTFactorsController = new ADOTFactorsController();
            List<ADOTFactorsInfo> list = (List<ADOTFactorsInfo>)objOTFactorsController.GetListFromDataSet(objOTFactorsController.GetAllObjects());
            List<ADOTFactorsInfo> finalList = new List<ADOTFactorsInfo>();
            finalList.Add(new ADOTFactorsInfo());
            finalList.AddRange(list);
            lookUpEdit.Properties.DataSource = finalList;
            lookUpEdit.Properties.DisplayMember = "ADOTFactorName";
            lookUpEdit.Properties.ValueMember = "ADOTFactorID";
        }
    }
}
