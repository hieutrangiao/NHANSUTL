using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{ 
    public class VinaDbUtil : BaseBusinessController
    {
        private readonly string spGetAllTables = "GEDBUtil_SelectAllTables";
        private readonly string spGetTableByName = "GEDBUtil_SelectTableByName";
        private readonly string spGetTableColumns = "GEDBUtil_SelectTableColumns";
        private readonly string spGetColumnsByTableNameAndColumnNameBeginWith = "GEDBUtil_SelectColumnsByTableNameAndColumnNameBeginWith";
        private readonly string spGetNotAllowNullTableColumns = "GEDBUtil_SelectNotAllowNullTableColumns";
        private readonly string spGetTableHaveMCode = "GEDBUtil_SelectTableHaveMCode";
        private readonly string spGetMCodeColumnsFromTable = "GEDBUtil_SelectMCodeColumnsFromTable";
        private readonly string spGetTableKeyColumns = "GEDBUtil_SelectTableKeyColumns";
        private readonly string spGetTableForeignKeys = "GEDBUtil_SelectTableForeignKeys";
        private readonly string spGetTablePrimaryKeys = "GEDBUtil_SelectTablePrimaryKeys";
        private readonly string spGetTableForeignKey = "GEDBUtil_SelectTableForeignKey";
        private readonly string spGetTablePrimaryKey = "GEDBUtil_SelectTablePrimaryKey";
        private readonly string spGetTableUniqueContraint = "GEDBUtil_SelectTableUniqueConstraint";
        private readonly string spGetPrimaryTableAndColumnWhichForeignColumnReferenceTo = "GEDBUtil_SelectPrimaryTableAndColumnWhichForeignColumnReferenceTo";
        private readonly string spGetTableColumn = "GEDBUtil_SelectTableColumn";
        private readonly string spGetSaveStatusInSessionColumn = "GEDBUtil_SelectSaveStatusInSessionColumn";
        private readonly string spGetAllStoredProcedures = "GEDBUtil_SelectAllStoredProcedures";
        private readonly string spGetStoredProcedureByTableName = "GEDBUtil_SelectStoredProcedureByTableName";
        private readonly string spGetStoredProcedureByName = "GEDBUtil_SelectStoredProcedureByName";
        private readonly string spGetStoredProcedureTextByID = "GEDBUtil_SelectStoredProcedureTextByID";
        private readonly string spGetStoredProcedureTextByStoredProcedureName = "GEDBUtil_SelectStoredProcedureTextByStoredProcedureName";
        private readonly string spGetColumnDescriptionByTableNameAndColumnName = "GEDBUtil_SelectColumnDescriptionByTableNameAndColumnName";
        private readonly string spGetAllViews = "GEDBUtil_SelectAllViews";
        private readonly string spGetViewTextByViewName = "GEDBUtil_SelectViewTextByViewName";
        private readonly string spGetViewColumns = "GEDBUtil_SelectViewColumns";
        private readonly string spGetViewColumn = "GEDBUtil_SelectViewColumn";

        public VinaDbUtil()
        {
            this.dal = new DALBaseProvider();
        }

        public DataSet GetAllTables()
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> 'sysdiagrams'"));
        }

        public bool IsExistTable(string strTableName)
        {
            string strQuery = string.Format("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> 'sysdiagrams' AND TABLE_NAME = '{0}'", (object)strTableName);
            bool flag = false;
            DataSet dataSet = this.dal.GetDataSet(strQuery);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                flag = true;
            return flag;
        }

        public DataSet GetDataFromTableNameWithTableColumnLikeColumnValue(string strTableName, string strColumnName, string strColumnValue)
        {
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("SELECT * FROM [dbo].[{0}] WHERE [{1}] LIKE '%{2}%' AND [AAStatus] = 'Alive' ORDER BY [{1}]", (object)strTableName, (object)strColumnName, (object)strColumnValue)));
        }

        public DataSet GetTableColumns(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", (object)strTableName));
        }

        public DataColumnCollection GetDataColumnCollectionFromDataSet(DataSet ds)
        {
            DataTable dataTable = new DataTable();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)ds.Tables[0].Rows)
                    dataTable.Columns.Add(new DataColumn()
                    {
                        ColumnName = row["COLUMN_NAME"].ToString(),
                        AllowDBNull = row["IS_NULLABLE"].ToString() == "YES"
                    });
            }
            return dataTable.Columns;
        }

        public int GetTableColumnCount(string strTableName)
        {
            try
            {
                return this.GetTableColumns(strTableName).Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetTableColumnsByTableNameAndColumnBeginWith(string strTableName, string strColumnName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME LIKE '{1}%'", (object)strTableName, (object)strColumnName));
        }

        public DataSet GetNotAllowNullTableColumns(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND IS_NULLABLE = 'NO'", (object)strTableName));
        }

        public DataSet GetTableColumn(string strTableName, string strColumnName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", (object)strTableName, (object)strColumnName));
        }

        public bool ColumnIsExist(string strTableName, string strColumnName)
        {
            DataSet tableColumn = this.GetTableColumn(strTableName, strColumnName);
            return tableColumn.Tables.Count > 0 && tableColumn.Tables[0].Rows.Count > 0;
        }

        public string GetColumnDbType(string strTableName, string strColumnName)
        {
            string str = string.Empty;
            DataSet tableColumn = this.GetTableColumn(strTableName, strColumnName);
            if (tableColumn.Tables.Count > 0 && tableColumn.Tables[0].Rows.Count > 0)
            {
                str = tableColumn.Tables[0].Rows[0]["DATA_TYPE"].ToString();
                if (str == "varchar" || str == "nvarchar" || str == "varbinary")
                    str = str + "(" + tableColumn.Tables[0].Rows[0]["CHARACTER_MAXIMUM_LENGTH"].ToString() + ")";
            }
            return str;
        }

        public int GetColumnCharacterMaximumLength(string strTableName, string strColumnName)
        {
            int num = 0;
            DataSet tableColumn = this.GetTableColumn(strTableName, strColumnName);
            if (tableColumn.Tables.Count > 0 && tableColumn.Tables[0].Rows.Count > 0)
            {
                string str = tableColumn.Tables[0].Rows[0]["DATA_TYPE"].ToString();
                if (str == "varchar" || str == "nvarchar")
                    num = Convert.ToInt32(tableColumn.Tables[0].Rows[0]["CHARACTER_MAXIMUM_LENGTH"]);
            }
            tableColumn.Dispose();
            return num;
        }

        public string GetColumnDataType(string strTableName, string strColumnName)
        {
            string empty = string.Empty;
            DataSet tableColumn = this.GetTableColumn(strTableName, strColumnName);
            if (tableColumn.Tables.Count > 0 && tableColumn.Tables[0].Rows.Count > 0)
                empty = tableColumn.Tables[0].Rows[0]["DATA_TYPE"].ToString();
            return empty;
        }

        public bool ColumnIsAllowNull(string strTableName, string strColumnName)
        {
            if (!SqlDatabaseHelper.NotNullTableColumns.ContainsKey(strTableName))
            {
                DataColumnCollection collectionFromDataSet = this.GetDataColumnCollectionFromDataSet(this.GetNotAllowNullTableColumns(strTableName));
                SqlDatabaseHelper.NotNullTableColumns.Add(strTableName, collectionFromDataSet);
            }
            if (SqlDatabaseHelper.NotNullTableColumns[strTableName].Contains(strColumnName))
                return SqlDatabaseHelper.NotNullTableColumns[strTableName][strColumnName].AllowDBNull;
            return true;
        }

        public Type GetCSharpVariableType(string strTableName, string strColumnName)
        {
            switch (this.GetColumnDataType(strTableName, strColumnName))
            {
                case "varchar":
                    return typeof(string);
                case "nvarchar":
                    return typeof(string);
                case "text":
                    return typeof(string);
                case "ntext":
                    return typeof(string);
                case "int":
                    return typeof(int);
                case "float":
                    return typeof(double);
                case "real":
                    return typeof(double);
                case "decimal":
                    return typeof(Decimal);
                case "datetime":
                    return typeof(DateTime);
                case "bit":
                    return typeof(bool);
                case "image":
                    return typeof(byte[]);
                case "varbinary":
                    return typeof(byte[]);
                default:
                    return typeof(string);
            }
        }

        public DataSet GetTablesHaveMCode()
        {
            return this.dal.GetDataSet(string.Format("SELECT DISTINCT(TABLE_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = '%MatchCode%' AND TABLE_NAME <> 'ADMatchCodes'"));
        }

        public DataSet GetMCodeColumnsFromTable(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME LIKE '%MatchCode%'", (object)strTableName));
        }

        public DataSet GetTableKeyColumns(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '{0}'", (object)strTableName));
        }

        public DataSet GetTableForeignKeys(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'", (object)strTableName));
        }

        public DataSet GetTablePrimaryKeys(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'", (object)strTableName));
        }

        public string GetTablePrimaryColumn(string strTableName)
        {
            string empty = string.Empty;
            if (SqlDatabaseHelper.PrimaryColumnsList[(object)strTableName] != null)
            {
                empty = SqlDatabaseHelper.PrimaryColumnsList[(object)strTableName].ToString();
            }
            else
            {
                DataSet tablePrimaryKeys = this.GetTablePrimaryKeys(strTableName);
                if (tablePrimaryKeys.Tables.Count > 0 && tablePrimaryKeys.Tables[0].Rows.Count > 0)
                    empty = tablePrimaryKeys.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            }
            return empty;
        }

        public string GetNameColumnOfTable(string strTableName)
        {
            string tablePrimaryColumn = this.GetTablePrimaryColumn(strTableName);
            if (!string.IsNullOrEmpty(tablePrimaryColumn))
                return tablePrimaryColumn.Substring(0, tablePrimaryColumn.Length - 2) + "Name";
            return string.Empty;
        }

        public string GetTableIDStringColumn(string strTableName)
        {
            string tablePrimaryColumn = this.GetTablePrimaryColumn(strTableName);
            if (!string.IsNullOrEmpty(tablePrimaryColumn))
                return tablePrimaryColumn + "String";
            return string.Empty;
        }

        public string GetSaveStatusInSessionColumn(string strTableName)
        {
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME LIKE '%SaveStatusInSession'", (object)strTableName));
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                return dataSet.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            return string.Empty;
        }

        public DataSet GetTableForeignKey(string strTableName, string strColumnName)
        {
            return this.dal.GetDataSet(string.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'", (object)strTableName, (object)strColumnName));
        }

        public DataSet GetTablePrimaryKey(string strTableName, string strColumnName)
        {
            return this.dal.GetDataSet(string.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'", (object)strTableName, (object)strColumnName));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strColumnName"></param>
        /// <returns></returns>
        public bool IsForeignKey(string strTableName, string strColumnName)
        {
            return strColumnName.Contains("FK_") || this.GetPrimaryTableWhichForeignColumnReferenceTo(strTableName, strColumnName) != string.Empty;
        }

        public bool IsPrimaryKey(string strTableName, string strColumnName)
        {
            return this.GetTablePrimaryColumn(strTableName) == strColumnName;
        }

        public DataSet GetTableUniqueConstraint(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT ccu.* FROM INFORMATION_ SCHEMA.CONSTRAINT_COLUMN_USAGE ccu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE ccu.TABLE_NAME = '{0}' AND ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.TABLE_NAME = ccu.TABLE_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'", (object)strTableName));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strForeignTableName"></param>
        /// <param name="strForeignColumnName"></param>
        /// <returns></returns>
        public string GetPrimaryTableWhichForeignColumnReferenceTo(string strForeignTableName, string strForeignColumnName)
        {
            if (!SqlDatabaseHelper.ForeignTableColumns.ContainsKey(strForeignTableName))
            {
                DataSet dataSet = this.dal.GetDataSet("GEDBUtil_GetPrimaryColumnsByForeignTableName", (object)strForeignTableName);
                DataTable dataTable = new DataTable();
                if (dataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = row["ForeignColumnName"].ToString();
                        column.ExtendedProperties.Add((object)"PrimaryTableName", (object)row["PrimaryTableName"].ToString());
                        column.ExtendedProperties.Add((object)"PrimaryColumnName", (object)row["PrimaryColumnName"].ToString());
                        if (dataTable.Columns.IndexOf(column.ColumnName) < 0)
                            dataTable.Columns.Add(column);
                    }
                }
                SqlDatabaseHelper.ForeignTableColumns.Add(strForeignTableName, dataTable.Columns);
            }
            string empty = string.Empty;
            if (SqlDatabaseHelper.ForeignTableColumns[strForeignTableName].Contains(strForeignColumnName))
                empty = SqlDatabaseHelper.ForeignTableColumns[strForeignTableName][strForeignColumnName].ExtendedProperties[(object)"PrimaryTableName"].ToString();
            return empty;
        }

        public string GetPrimaryColumnWhichForeignColumnReferenceTo(string strForeignTableName, string strForeignColumnName)
        {
            string empty = string.Empty;
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT tc.TABLE_NAME, ccu.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ") + string.Format("WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = rc.CONSTRAINT_NAME AND rc.UNIQUE_CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY' ", (object)strForeignTableName, (object)strForeignColumnName) + string.Format("AND ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND ccu.TABLE_NAME = tc.TABLE_NAME"));
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                empty = dataSet.Tables[0].Rows[0][1].ToString();
            return empty;
        }

        public DataSet ExecuteQuery(string strQuery)
        {
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(strQuery));
        }

        public void SetPropertyValue(BusinessObject obj, string strPropertyName, object value)
        {
            obj.GetType().GetProperty(strPropertyName)?.SetValue((object)obj, value, (object[])null);
        }

        public void SetPropertyValue(object obj, string strPropertyName, object value)
        {
            obj.GetType().GetProperty(strPropertyName)?.SetValue(obj, value, (object[])null);
        }

        public object GetPropertyValue(BusinessObject obj, string strPropertyName)
        {
            return obj.GetType().GetProperty(strPropertyName)?.GetValue((object)obj, (object[])null);
        }

        public object GetPropertyValue(object obj, string strPropertyName)
        {
            return obj.GetType().GetProperty(strPropertyName)?.GetValue(obj, (object[])null);
        }

        public string GetPropertyStringValue(object obj, string strPropertyName)
        {
            object propertyValue = this.GetPropertyValue(obj, strPropertyName);
            if (propertyValue != null)
                return propertyValue.ToString();
            return string.Empty;
        }

        public int GetPropertyIntValue(object obj, string strPropertyName)
        {
            object propertyValue = this.GetPropertyValue(obj, strPropertyName);
            if (propertyValue != null)
                return Convert.ToInt32(propertyValue);
            return 0;
        }

        public DataSet GetStoredProcedureByTableName(string strTableName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM sysobjects WHERE name LIKE '{0}[_]%' AND type = 'P'", (object)strTableName));
        }

        public DataSet GetAllStoredProcedures()
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM sysobjects WHERE type = 'P'"));
        }

        public bool StoredProcedureIsExist(string strStoredProcedureName)
        {
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT * FROM sysobjects WHERE name = '{0}' AND type = 'P'", (object)strStoredProcedureName));
            return dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
        }

        public string GetStoredProcedureTextByID(int id)
        {
            string empty = string.Empty;
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT text FROM syscomments WHERE id = {0}", (object)id));
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                    empty += row["text"].ToString();
            }
            return empty;
        }

        public string GetStoredProcedureTextByStoredProcedureName(string strStoredProcedureName)
        {
            string empty = string.Empty;
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT sc.* FROM syscomments sc, sysobjects so WHERE sc.id = so.id AND so.name = '{0}' AND so.type = 'P'", (object)strStoredProcedureName));
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                    empty += row["text"].ToString();
            }
            return empty;
        }

        public string GetColumnDescriptionFromTableNameAndColumnName(string strTableName, string strColumName)
        {
            string empty = string.Empty;
            DataSet dataSet = this.dal.GetDataSet(this.spGetColumnDescriptionByTableNameAndColumnName, (object)strTableName, (object)strColumName);
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                empty = dataSet.Tables[0].Rows[0]["value"].ToString();
            return empty;
        }

        public void CreateColumnDescription(string strTableName, string strColumnName, string strColumnDescription)
        {
            this.dal.GetDataSet("sp_addextendedproperty", (object)"MS_Description", (object)strColumnDescription, (object)"Schema", (object)"dbo", (object)"Table", (object)strTableName, (object)"Column", (object)strColumnName);
        }

        public void UpdateColumnDescription(string strTableName, string strColumnName, string strColumnDescription)
        {
            this.dal.GetDataSet("sp_updateextendedproperty", (object)"MS_Description", (object)strColumnDescription, (object)"Schema", (object)"dbo", (object)"Table", (object)strTableName, (object)"Column", (object)strColumnName);
        }

        public void ExecuteNonQuery(string spName, params object[] values)
        {
            SqlDatabaseHelper.ExecuteNonQuery(spName, values);
        }

        public void ExecuteNonQuery(Database database, string spName, params object[] values)
        {
            SqlDatabaseHelper.ExecuteNonQuery(database, spName, values);
        }

        public DataSet GetViewColumns(string strViewName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.VIEW_COLUMN_USAGE WHERE VIEW_NAME = '{0}'", (object)strViewName));
        }

        public DataSet GetAllViews()
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.VIEWS"));
        }

        public string GetViewTextByViewName(string strViewName)
        {
            string empty = string.Empty;
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT sc.* FROM syscomments sc, sysobjects so WHERE sc.id = so.id AND so.name = '{0}' AND so.type = 'V'", (object)strViewName));
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                    empty += row["text"].ToString();
            }
            return empty;
        }

        public DataSet GetViewColumn(string strViewName, string strColumnName)
        {
            return this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.VIEW_COLUMN_USAGE WHERE VIEW_NAME = '{0}' AND COLUMN_NAME = '{1}'", (object)strViewName, (object)strColumnName));
        }

        public string GetTableNameByViewNameAndColumnName(string strViewName, string strColumnName)
        {
            DataSet viewColumn = this.GetViewColumn(strViewName, strColumnName);
            if (viewColumn.Tables.Count > 0 && viewColumn.Tables[0].Rows.Count > 0)
                return viewColumn.Tables[0].Rows[0]["TABLE_NAME"].ToString();
            return string.Empty;
        }

        public string GetTableNameByColumnName(string columnName)
        {
            DataSet dataSet = this.dal.GetDataSet(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = '{0}'", (object)columnName));
            string empty = string.Empty;
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                return Convert.ToString(dataSet.Tables[0].Rows[0]["TABLE_NAME"]);
            return string.Empty;
        }

        public DateTime GetLastCreatedDateOfTable(string strTableName)
        {
            try
            {
                DateTime dateTime = DateTime.MinValue;
                string strColumnName = "AACreatedDate";
                if (this.ColumnIsExist(strTableName, strColumnName))
                {
                    DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("Select MAX([{0}]) From [{1}] Where DATEDIFF(d, [{0}], '9999-12-31') > 0", (object)strColumnName, (object)strTableName)));
                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        dateTime = Convert.ToDateTime(dataSet.Tables[0].Rows[0][0]);
                }
                return dateTime;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public DateTime GetLastUpdatedDateOfTable(string strTableName)
        {
            try
            {
                DateTime dateTime = DateTime.MinValue;
                string strColumnName = "AAUpdatedDate";
                if (this.ColumnIsExist(strTableName, strColumnName))
                {
                    DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("Select MAX([{0}]) From [{1}] Where DATEDIFF(d, [{0}], '9999-12-31') > 0", (object)strColumnName, (object)strTableName)));
                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        dateTime = Convert.ToDateTime(dataSet.Tables[0].Rows[0][0]);
                }
                return dateTime;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public bool ColumnIsExistInBaseBusinessObject(string strPropertyName)
        {
            foreach (MemberInfo property in typeof(BusinessObject).GetProperties())
            {
                if (property.Name.Equals(strPropertyName))
                    return true;
            }
            return false;
        }

        public DataSet GetDataSet(Database database, string spName, params object[] values)
        {
            return SqlDatabaseHelper.RunStoredProcedure((SqlDatabase)database, spName, values);
        }

        public DateTime GetCurrentServerDate()
        {
            //TODO GetCurrentServerDate
            return DateTime.Now;
        }
    }
}