using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP.Modules.CompanyConstant
{
    public partial class ADWorkingShiftsGridControl : VinaGridControl
    {
        #region Private variables
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private string WorkingShiftName = String.Empty;
        private string WorkingShiftFromTime = String.Empty;
        private string WorkingShiftToTime = String.Empty;
        private string WorkingShiftTimeKeepInTo = String.Empty;
        #endregion

        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.WorkingShiftsList;
            this.DataSource = bds;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((CompanyConstantModule)Screen.Module).RemoveSelectedItemFromWorkingShiftList();
            }
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();

            repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            foreach (GridColumn columnedit in gridView.Columns)
            {
                columnedit.OptionsColumn.AllowEdit = true;
            }

            // repositoryItemDateEdit
            repositoryItemDateEdit.AutoHeight = false;
            repositoryItemDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.EditFormat.FormatString = "HH:mm:ss";
            repositoryItemDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "HH:mm:ss";
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Name = "repositoryItemDateEdit1";

            GridColumn column = gridView.Columns["ADWorkingShiftName"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["ADWorkingShiftDesc"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["ADWorkingShiftFromTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftToTime"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftBreakTimeBetweenFrom"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftBreakTimeBetweenTo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftTimeKeepInFrom"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftTimeKeepInTo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftTimeKeepOutFrom"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftTimeKeepOutTo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = repositoryItemDateEdit;
            }

            column = gridView.Columns["ADWorkingShiftNight"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["ADWorkingShiftWorkingTime"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;

            column = gridView.Columns["FK_ADWorkingShiftGroupID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEdit.DisplayMember = "ADWorkingShiftGroupName";
                repositoryItemLookUpEdit.ValueMember = "ADWorkingShiftGroupID";
                repositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEdit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                repositoryItemLookUpEdit.NullText = string.Empty;
                repositoryItemLookUpEdit.Columns.Add(new LookUpColumnInfo("ADWorkingShiftGroupName", "Nhóm ca"));
                repositoryItemLookUpEdit.QueryPopUp += new CancelEventHandler(repositoryItemLookUpEdit2_QueryPopUp);
                column.ColumnEdit = repositoryItemLookUpEdit;
            }

            //column = gridView.Columns["ADWorkingShiftAllowance"];
            //if (column != null)
            //{
            //    column.OptionsColumn.AllowEdit = true;
            //}

            gridView.InvalidRowException += new InvalidRowExceptionEventHandler(GridView_InvalidRowException);
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(gridView_CustomColumnDisplayText);
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);

            return gridView;
        }

        private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "FK_ADWorkingShiftGroupID")
            {
                if (e.Value != null)
                {
                    int id = int.Parse(e.Value.ToString());
                    ADWorkingShiftGroupsController controller = new ADWorkingShiftGroupsController();
                    ADWorkingShiftGroupsInfo objWorkingShiftGroupsInfo = (ADWorkingShiftGroupsInfo)controller.GetObjectByID(id);
                    if (objWorkingShiftGroupsInfo != null)
                    {
                        e.DisplayText = objWorkingShiftGroupsInfo.ADWorkingShiftGroupName;
                    }
                }
            }
        }

        private void repositoryItemLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            ADWorkingShiftGroupsController controller = new ADWorkingShiftGroupsController();
            List<ADWorkingShiftGroupsInfo> list = (List<ADWorkingShiftGroupsInfo>)controller.GetListFromDataSet(controller.GetAllObjects());
            if (list != null && list.Count > 0)
            {
                list.Insert(0, new ADWorkingShiftGroupsInfo());
                lookUpEdit.Properties.DataSource = list;
            }
        }

        protected void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        protected override void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            base.GridView_ValidateRow(sender, e);
            ColumnView view = sender as ColumnView;
            GridColumn columnWorkingShiftName = view.Columns["ADWorkingShiftName"];
            GridColumn columnWorkingShiftFromTime = view.Columns["ADWorkingShiftFromTime"];
            GridColumn columnWorkingShiftToTime = view.Columns["ADWorkingShiftToTime"];
            GridColumn columnWorkingShiftTimeKeepInTo = view.Columns["ADWorkingShiftTimeKeepInTo"];
            GridColumn columnWorkingShiftTimeKeepInFrom = view.Columns["ADWorkingShiftTimeKeepInFrom"];
            GridColumn columnWorkingShiftTimeKeepOutFrom = view.Columns["ADWorkingShiftTimeKeepOutFrom"];
            GridColumn columnWorkingShiftTimeKeepOutTo = view.Columns["ADWorkingShiftTimeKeepOutTo"];

            //Get the value of columns

            string workingShiftName = view.GetRowCellValue(e.RowHandle, columnWorkingShiftName).ToString();
            string workingShiftFromTime = view.GetRowCellValue(e.RowHandle, columnWorkingShiftFromTime).ToString();
            string workingShiftToTime = view.GetRowCellValue(e.RowHandle, columnWorkingShiftToTime).ToString();
            string workingShiftTimeKeepInTo = view.GetRowCellValue(e.RowHandle, columnWorkingShiftTimeKeepInTo).ToString();
            string workingShiftTimeKeepInFrom = view.GetRowCellValue(e.RowHandle, columnWorkingShiftTimeKeepInFrom).ToString();
            string workingShiftTimeKeepOutFrom = view.GetRowCellValue(e.RowHandle, columnWorkingShiftTimeKeepOutFrom).ToString();
            string workingShiftTimeKeepOutTo = view.GetRowCellValue(e.RowHandle, columnWorkingShiftTimeKeepOutTo).ToString();

            if (string.IsNullOrEmpty(workingShiftName))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftName, "Tên ca làm việc không thể rỗng");
            }

            if (string.IsNullOrEmpty(workingShiftFromTime))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftFromTime, "Thời gian từ không thể rỗng");
            }

            if (string.IsNullOrEmpty(workingShiftToTime))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftToTime, "Thời gian đến không thể rỗng");
            }

            if (string.IsNullOrEmpty(workingShiftTimeKeepInTo))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftTimeKeepInTo, "Giờ chấm công vào đến không thể rỗng");
            }
            if (string.IsNullOrEmpty(workingShiftTimeKeepInFrom))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftTimeKeepInFrom, "Giờ chấm công vào từ không thể rỗng");
            }
            if (string.IsNullOrEmpty(workingShiftTimeKeepOutFrom))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftTimeKeepOutFrom, "Giờ chấm công ra từ không thể rỗng");
            }
            if (string.IsNullOrEmpty(workingShiftTimeKeepOutTo))
            {
                e.Valid = false;
                view.SetColumnError(columnWorkingShiftTimeKeepOutTo, "Giờ chấm công ra đến không thể rỗng");
            }
        }
    }
}
