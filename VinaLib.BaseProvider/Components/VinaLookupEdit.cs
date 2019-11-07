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
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace VinaLib.BaseProvider
{
    public partial class VinaLookupEdit : DevExpress.XtraEditors.LookUpEdit, IVinaControl
    {
        public VinaLookupEdit()
        {
            InitializeComponent();
            this.Size = new Size(150, 20);
        }
        [Browsable(true)]
        [Category("Vina")]
        public string VinaDataSource { get; set; }

        [Category("Vina")]
        public string VinaDataMember { get; set; }

        [Category("Vina")]
        public string VinaPropertyName { get; set; }

        [Category("Vina")]
        public bool VinaAllowDummy { get; set; }

        [Category("Vina")]
        public bool VinaAutoGenarateDataSoure { get; set; }

        public VinaScreen Screen { get; set; }

        protected SortedList LookupTables;

        protected SortedList<string, GELookupTablesInfo> LookupTableObjects;

        public virtual void InitializeControl()
        {
            try
            {
                this.LookupTables = ((IBaseModuleERP)this.Screen.Module).GetLookupTableCollection();
                this.LookupTableObjects = ((IBaseModuleERP)this.Screen.Module).GetLookupTableObjects();
                if (this.VinaAutoGenarateDataSoure)
                {
                    this.InitLookupEditColumns();
                    this.InitObjectDataToLookupEdit();
                }
                //this.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                this.Properties.SearchMode = SearchMode.AutoFilter;
                this.Properties.TextEditStyle = TextEditStyles.Standard;
                this.Properties.NullText = string.Empty;
                if (!string.IsNullOrEmpty(this.VinaDataSource) && !string.IsNullOrEmpty(this.VinaDataMember) && !this.VinaDataSource.Equals("ADConfigValues"))
                    this.Screen.BindingDataControl((Control)this);
            }
            catch (Exception ex)
            {
                //int num = (int)MessageBox.Show(ex.Message, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                int num = (int)MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        protected void InitLookupEditColumns()
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            string lookuptable = vinaDbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(this.VinaDataSource, this.VinaDataMember);

            GELookupColumnsController objLookupColumnsController = new GELookupColumnsController();
            List<GELookupColumnsInfo> lookupColumns = objLookupColumnsController.GetLookupColumnByLookupTableName(lookuptable);
            if (lookupColumns.Count() == 0)
                return;

            this.Properties.Columns.Clear();
            this.Properties.BestFitMode = BestFitMode.None;
            LookUpColumnInfo column = new LookUpColumnInfo();
            lookupColumns.ForEach(o =>
            {
                column = new LookUpColumnInfo();
                column.Caption = o.GELookupColumnCaption;
                column.FieldName = o.GELookupColumnFieldName;
                column.FormatType = string.IsNullOrWhiteSpace(o.GELookupColumnFormatType) ? FormatType.None : (FormatType)Enum.Parse(typeof(FormatType), o.GELookupColumnFormatType);
                column.FormatString = o.GELookupColumnFormatString;
                column.Width = o.GELookupColumnWidth;
                this.Properties.Columns.Add(column);
                this.Properties.PopupWidth += column.Width;
            });
        }

        protected virtual void InitObjectDataToLookupEdit()
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            if (string.IsNullOrEmpty(this.VinaDataMember))
                return;

            if (vinaDbUtil.IsForeignKey(this.VinaDataSource, this.VinaDataMember))
            {
                this.InitObjectDataFromLookupTable(vinaDbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(this.VinaDataSource, this.VinaDataMember));
                return;
            }

            string configValueGroup = this.VinaDataMember.Substring(2, this.VinaDataMember.Length - 2);
            if (configValueGroup.EndsWith("PaymentMethodType"))
                configValueGroup = "PaymentMethod";
            IEnumerable configValues = Enumerable.Empty<ADConfigValuesInfo>();

            if (!VinaUtil.ADConfigValueUtility.TryGetValue(configValueGroup, out configValues))
                return;

            this.Properties.ValueMember = "ADConfigKeyValue";
            this.Properties.DisplayMember = "ADConfigText";
            LookUpColumnInfo column = new LookUpColumnInfo();
            column.FieldName = "ADConfigText";
            column.Width = 100;
            this.Properties.Columns.Add(column);
            this.Properties.PopupWidth = column.Width;
            this.Properties.ShowHeader = false;
            this.Properties.DataSource = configValues;
        }

        protected bool InitObjectDataFromLookupTable(string strLookupTable)
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            if (this.LookupTables != null)
            {
                if (!this.LookupTables.ContainsKey((object)strLookupTable))
                {
                    GELookupTablesInfo objectByTableName = new GELookupTablesController().GetObjectByTableName(strLookupTable);
                    if (objectByTableName != null)
                    {
                        DataSet lookupTableData = ((IBaseModuleERP)this.Screen.Module).GetLookupTableData(strLookupTable);
                        this.LookupTables.Add((object)strLookupTable, (object)lookupTableData);
                        this.LookupTableObjects.Add(strLookupTable, objectByTableName);
                    }
                }
                if (this.LookupTables[(object)strLookupTable] != null)
                {
                    this.InitObjectDataFromLookupTable(((DataSet)this.LookupTables[(object)strLookupTable]).Tables[0], strLookupTable);
                    return true;
                }
            }
            return false;
        }

        protected void InitObjectDataFromLookupTable(DataTable dataSource, string tableName)
        {
            VinaDbUtil vinaDbUtil = new VinaDbUtil();
            DataTable dataTable = dataSource.Copy();
            bool flag1 = false;
            if (this.VinaAllowDummy && dataTable.Rows.Count > 0)
            {
                object obj = dataTable.Rows[0][this.Properties.ValueMember];
                if (obj is int)
                {
                    if (Convert.ToInt32(obj) > 0)
                    {
                        DataRow row = dataTable.NewRow();
                        row[this.Properties.ValueMember] = (object)0;
                        dataTable.Rows.InsertAt(row, 0);
                        flag1 = true;
                    }
                }
                else if (obj is string && !string.IsNullOrEmpty(obj.ToString()))
                {
                    DataRow row = dataTable.NewRow();
                    row[this.Properties.ValueMember] = (object)string.Empty;
                    dataTable.Rows.InsertAt(row, 0);
                    flag1 = true;
                }
            }
            this.Properties.DataSource = (object)dataTable;
            if (dataTable.Rows.Count <= 0)
                return;
            this.ItemIndex = 0;
        }
    }
}