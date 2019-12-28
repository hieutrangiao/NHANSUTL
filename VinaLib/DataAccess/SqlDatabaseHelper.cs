using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace VinaLib
{
    public class SqlDatabaseHelper
    {
        private static SqlDatabase database = (SqlDatabase)null;
        public static string AAStatusColumn = "AAStatus";
        private static SortedList lstPrimaryColumns = new SortedList();
        private static List<string> lstTableColumnNames = new List<string>();
        public static string _connectionString = string.Empty;
        private static string _companyName = string.Empty;

        public static SortedList PrimaryColumnsList
        {
            get
            {
                return SqlDatabaseHelper.lstPrimaryColumns;
            }
        }

        public static SortedList<string, DataColumnCollection> NotNullTableColumns { get; set; }

        public static SortedList<string, DataColumnCollection> ForeignTableColumns { get; set; }

        static SqlDatabaseHelper()
        {
            try
            {
                SqlDatabaseHelper._connectionString = ConfigurationManager.ConnectionStrings["VinaERPConnection"].ConnectionString;
                SqlDatabaseHelper.database = new SqlDatabase(SqlDatabaseHelper._connectionString);

                SqlDatabaseHelper.lstPrimaryColumns = SqlDatabaseHelper.GetAllTablePrimaryColumns();
                SqlDatabaseHelper.NotNullTableColumns = new SortedList<string, DataColumnCollection>();
                SqlDatabaseHelper.ForeignTableColumns = new SortedList<string, DataColumnCollection>();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        public static string CompanyName
        {
            get
            {
                return SqlDatabaseHelper._companyName;
            }
            set
            {
                SqlDatabaseHelper._companyName = value;
            }
        }

        public static void SwitchConnection(string strConnectionString)
        {
            SqlDatabaseHelper.database = new SqlDatabase(strConnectionString);
        }

        public static void RollbackToLocalConnection()
        {
            SqlDatabaseHelper.database = new SqlDatabase(SqlDatabaseHelper._connectionString);
        }

        public static SqlDatabase CreateConnection(string connectionString)
        {
            return new SqlDatabase(connectionString);
        }

        public static object GetSingleObject(DataTable dt, System.Type type)
        {
            try
            {
                if (dt.Rows.Count <= 0)
                    return (object)null;
                return SqlDatabaseHelper.GetObjectFromDataRow(dt.Rows[0], type);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static ArrayList GetObjectCollection(DataTable dt, System.Type type, string tableName)
        {
            type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic);
            ArrayList arrayList = new ArrayList();
            foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
                arrayList.Add(SqlDatabaseHelper.GetObjectFromDataRow(row, type));
            return arrayList;
        }

        public static object GetObjectFromDataRow(DataRow row, System.Type type)
        {
            object obj1 = type.InvokeMember("", BindingFlags.CreateInstance, (Binder)null, (object)null, (object[])null);
            foreach (DataColumn column in (InternalDataCollectionBase)row.Table.Columns)
            {
                object obj2 = row[column];
                if (obj2 != DBNull.Value)
                    obj1.GetType().GetProperty(column.ColumnName)?.SetValue(obj1, obj2, (object[])null);
            }
            return obj1;
        }

        public static DataSet GetObjectbyId(string tableName, int id)
        {
            string str = string.Format("Select * From {0} where {1} = {2}", (object)SqlDatabaseHelper.GetPrimaryKeyColumn(tableName), (object)id);
            DbCommand sqlStringCommand = ((Database)SqlDatabaseHelper.database).GetSqlStringCommand(str);
            return ((Database)SqlDatabaseHelper.database).ExecuteDataSet(sqlStringCommand);
        }

        public static void SetValueToPrimaryColumn(object obj, DALBaseProvider provider, int iObjectID)
        {
            string primaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(provider.TableName);
            provider.ObjectType.GetProperty(primaryKeyColumn).SetValue(obj, (object)iObjectID, (object[])null);
        }

        public static void SetValueToIDStringColumn(object obj, DALBaseProvider provider, int iObjectID)
        {
            string primaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(provider.TableName);
            provider.ObjectType.GetProperty(primaryKeyColumn + "String")?.SetValue(obj, (object)iObjectID.ToString(), (object[])null);
        }

        public static object GetPrimaryColumnValue(object obj, DALBaseProvider provider)
        {
            string primaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(provider.TableName);
            return provider.ObjectType.GetProperty(primaryKeyColumn).GetValue(obj, (object[])null);
        }

        public static string GetPrimaryKeyColumn(string strTableName)
        {
            string empty = string.Empty;
            if (SqlDatabaseHelper.lstPrimaryColumns[(object)strTableName] != null)
            {
                empty = SqlDatabaseHelper.lstPrimaryColumns[(object)strTableName].ToString();
            }
            else
            {
                DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu,INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc " + string.Format("WHERE (kcu.TABLE_NAME='{0}')", (object)strTableName) + "AND(kcu.CONSTRAINT_NAME=tc.CONSTRAINT_NAME)AND(tc.CONSTRAINT_TYPE='PRIMARY KEY')"));
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    empty = dataSet.Tables[0].Rows[0]["COLUMN_NAME"].ToString();
            }
            return empty;
        }

        public static DataSet GetAllTableColumns(string strTableName)
        {
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", (object)strTableName)));
        }

        public static SortedList GetAllTablePrimaryColumns()
        {
            SortedList sortedList = new SortedList();
            DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu,INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE" + "(kcu.TABLE_NAME IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES\tWHERE(TABLE_TYPE='BASE TABLE')AND(TABLE_NAME<>'sysdiagrams')))" + " AND(kcu.CONSTRAINT_NAME=tc.CONSTRAINT_NAME)AND(tc.CONSTRAINT_TYPE='PRIMARY KEY') AND kcu.TABLE_SCHEMA <> ('HangFire')"));
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                {
                    string str1 = row["TABLE_NAME"].ToString();
                    string str2 = row["COLUMN_NAME"].ToString();
                    sortedList.Add((object)str1, (object)str2);
                }
            }
            return sortedList;
        }

        public static DataSet GetTableColumn(string strTableName, string strColumnName)
        {
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", (object)strTableName, (object)strColumnName)));
        }

        public static bool ColumnIsExistInTable(string strTableName, string strColumnName)
        {
            DataSet tableColumn = SqlDatabaseHelper.GetTableColumn(strTableName, strColumnName);
            return tableColumn.Tables.Count > 0 && tableColumn.Tables[0].Rows.Count > 0;
        }

        public static bool ColumnIsForeignKey(string strTableName, string strColumnName)
        {
            DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'FOREIGN KEY'", (object)strTableName, (object)strColumnName)));
            return dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
        }

        public static bool IsColumnAllowNull(string strTableName, string strColumnName)
        {
            DataSet tableColumn = SqlDatabaseHelper.GetTableColumn(strTableName, strColumnName);
            return tableColumn.Tables.Count <= 0 || tableColumn.Tables[0].Rows.Count <= 0 || tableColumn.Tables[0].Rows[0]["IS_NULLABLE"].ToString() == "YES";
        }

        public static bool ColumnIsPrimaryKey(string strTableName, string strColumnName)
        {
            DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("SELECT kcu.* FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu, INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc WHERE kcu.TABLE_NAME = '{0}' AND kcu.COLUMN_NAME = '{1}' AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'", (object)strTableName, (object)strColumnName)));
            return dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0;
        }

        public static string GetQueryCommandByTableNameAndTableQueryKey(string strTableName, string strTableQueryKey)
        {
            string empty = string.Empty;
            DataSet dataSet = SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("SELECT * FROM [dbo].[STTableQueries] WHERE ([STTableQueryTableName]='{0}')AND([STTableQueryKey]='{1}')", (object)strTableName, (object)strTableQueryKey)));
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                empty = dataSet.Tables[0].Rows[0]["STTableQueryCommand"].ToString();
            return empty;
        }

        public static void InsertQueryCommand(string strQueryCommand, string strTableName, string strQueryKey)
        {
            DbCommand query = SqlDatabaseHelper.GetQuery(string.Format("INSERT INTO [dbo].[STTableQueries] ([STTableQueryID],[STTableQueryTableName],[STTableQueryKey],[STTableQueryCommand]) VALUES({0},'{1}','{2}','{3}')", (object)(SqlDatabaseHelper.GetMaxID("STTableQueries") + 1), (object)strTableName, (object)strQueryKey, (object)strQueryCommand));
            ((Database)SqlDatabaseHelper.database).ExecuteNonQuery(query);
        }

        public static int GetMaxID(string tableName)
        {
            int num = 0;
            string str = string.Format("SELECT Max({0}) AS MaxID FROM [{1}]", (object)SqlDatabaseHelper.GetPrimaryKeyColumn(tableName), (object)tableName);
            DbCommand sqlStringCommand = ((Database)SqlDatabaseHelper.database).GetSqlStringCommand(str);
            DataSet dataSet = ((Database)SqlDatabaseHelper.database).ExecuteDataSet(sqlStringCommand);
            if (dataSet.Tables.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                if (row[0].ToString() != "")
                    num = (int)row[0];
            }
            return num;
        }

        public static void AddInParameter(DbCommand cmd, string name, SqlDbType type, object objValue)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            SqlDatabaseHelper.database.AddInParameter(cmd, name, type, objValue);
        }

        public static void AddParameter(DbCommand cmd, string name, DbType type, ParameterDirection direction, object value)
        {
            SqlParameter sqlParameter = new SqlParameter(name, value);
            sqlParameter.DbType = type;
            sqlParameter.Direction = direction;
            cmd.Parameters.Add((object)sqlParameter);
        }

        private static bool ColumnIsExistInBaseBusinessObject(string strPropertyName)
        {
            foreach (MemberInfo property in typeof(BusinessObject).GetProperties())
            {
                if (property.Name.Equals(strPropertyName))
                    return true;
            }
            return false;
        }

        public static void AddParameterForObject(object obj, DALBaseProvider provider, DbCommand cmd)
        {
            try
            {
                SqlDatabaseHelper.lstTableColumnNames.Clear();
                DataSet allTableColumns = SqlDatabaseHelper.GetAllTableColumns(provider.TableName);
                if (allTableColumns.Tables.Count > 0)
                {
                    foreach (DataRow row in (InternalDataCollectionBase)allTableColumns.Tables[0].Rows)
                        SqlDatabaseHelper.lstTableColumnNames.Add(row["COLUMN_NAME"].ToString());
                }
                PropertyInfo[] properties = provider.ObjectType.GetProperties();
                for (int index = 0; index < properties.Length; ++index)
                {
                    if (SqlDatabaseHelper.lstTableColumnNames.IndexOf(properties[index].Name) >= 0)
                    {
                        object obj1 = properties[index].GetValue(obj, (object[])null);
                        if (properties[index].PropertyType.Equals(typeof(int)))
                        {
                            if ((properties[index].Name == provider.TableName.Substring(0, provider.TableName.Length - 1) + "ID" || properties[index].Name == provider.TableName + "ID") && cmd.CommandText.Contains("_Insert"))
                                SqlDatabaseHelper.database.AddOutParameter(cmd, properties[index].Name, SqlDbType.Int, 4);
                            else
                                SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.Int, obj1);
                        }
                        else if (properties[index].PropertyType.Equals(typeof(bool)))
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.Bit, obj1);
                        else if (properties[index].PropertyType.Equals(typeof(short)))
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.SmallInt, obj1);
                        else if (properties[index].PropertyType.Equals(typeof(byte)))
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.TinyInt, obj1);
                        else if (properties[index].PropertyType.Equals(typeof(double)))
                        {
                            if (double.IsInfinity((double)obj1))
                                obj1 = (object)0.0;
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.Float, obj1);
                        }
                        else if (properties[index].PropertyType.Equals(typeof(Decimal)))
                            ((Database)SqlDatabaseHelper.database).AddParameter(cmd, properties[index].Name, DbType.Decimal, 24, ParameterDirection.Input, true, (byte)18, (byte)5, properties[index].Name, DataRowVersion.Default, obj1);
                        else if (properties[index].PropertyType.Equals(typeof(string)) || properties[index].PropertyType.Equals(typeof(string)))
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.NVarChar, obj1);
                        else if (properties[index].PropertyType.Equals(typeof(DateTime)))
                        {
                            if ((DateTime)obj1 == DateTime.MinValue)
                                obj1 = (object)DateTime.MaxValue;
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.DateTime, obj1);
                        }
                        else if (properties[index].PropertyType.Equals(typeof(byte[])))
                            SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.VarBinary, obj1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddParameterForSearchProperties(object obj, DbCommand cmd)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            for (int index = 0; index < properties.Length; ++index)
            {
                object obj1 = properties[index].GetValue(obj, (object[])null);
                string name = properties[index].Name;
                if (properties[index].Name.Equals("TopResults"))
                    SqlDatabaseHelper.database.AddInParameter(cmd, name, SqlDbType.Int, obj1);
                else if (properties[index].PropertyType.Equals(typeof(int)))
                    SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.Int, obj1);
                else if (properties[index].PropertyType.Equals(typeof(bool)))
                    SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.Bit, obj1);
                else if (properties[index].PropertyType.Equals(typeof(short)))
                    SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.SmallInt, obj1);
                else if (properties[index].PropertyType.Equals(typeof(double)))
                    SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.Float, obj1);
                else if (properties[index].PropertyType.Equals(typeof(Decimal)))
                {
                    SqlParameter sqlParameter = new SqlParameter(properties[index].Name, SqlDbType.Decimal);
                    sqlParameter.Precision = (byte)18;
                    sqlParameter.Scale = (byte)5;
                    sqlParameter.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add((object)sqlParameter);
                }
                else if (properties[index].PropertyType.Equals(typeof(string)) || properties[index].PropertyType.Equals(typeof(string)))
                    SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.NVarChar, obj1);
                else if (properties[index].PropertyType.Equals(typeof(DateTime)))
                {
                    if (!((DateTime)obj1 == DateTime.MinValue))
                        SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.DateTime, obj1);
                }
                else if (properties[index].PropertyType.Equals(typeof(byte[])))
                    SqlDatabaseHelper.database.AddInParameter(cmd, properties[index].Name, SqlDbType.VarBinary, obj1);
            }
        }

        public static int InsertObject(object obj, DALBaseProvider provider, string spName)
        {
            try
            {
                DbCommand storedProcCommand = ((Database)SqlDatabaseHelper.database).GetStoredProcCommand(spName);
                SqlDatabaseHelper.AddParameterForObject(obj, provider, storedProcCommand);
                ((Database)SqlDatabaseHelper.database).ExecuteNonQuery(storedProcCommand);
                return (int)((Database)SqlDatabaseHelper.database).GetParameterValue(storedProcCommand, SqlDatabaseHelper.GetPrimaryKeyColumn(provider.TableName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertObject(object obj, DALBaseProvider provider, string spName, DbTransaction transaction)
        {
            try
            {
                DbCommand storedProcCommand = ((Database)SqlDatabaseHelper.database).GetStoredProcCommand(spName);
                SqlDatabaseHelper.AddParameterForObject(obj, provider, storedProcCommand);
                storedProcCommand.Transaction = transaction;
                ((Database)SqlDatabaseHelper.database).ExecuteNonQuery(storedProcCommand, transaction);
                transaction.Commit();
                return (int)((Database)SqlDatabaseHelper.database).GetParameterValue(storedProcCommand, SqlDatabaseHelper.GetPrimaryKeyColumn(provider.TableName));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public static DataSet RunStoredProcedure(string spName)
        {
            DbCommand storedProcCommand = ((Database)SqlDatabaseHelper.database).GetStoredProcCommand(spName);
            return ((Database)SqlDatabaseHelper.database).ExecuteDataSet(storedProcCommand);
        }

        public static DataSet RunStoredProcedure(DbCommand cmd)
        {
            try
            {
                return ((Database)SqlDatabaseHelper.database).ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static DataSet RunStoredProcedure(string spName, params object[] values)
        {
            for (int index = 0; index < values.Length; ++index)
            {
                object obj = values[index];
                if (obj != null && obj.GetType() != typeof(bool) && (obj.Equals((object)0) || obj.Equals((object)string.Empty)))
                    values[index] = (object)null;
            }
          return ((Database)SqlDatabaseHelper.database).ExecuteDataSet(spName, values);
        }

        public static DataSet RunStoredProcedure(SqlDatabase database, string spName, params object[] values)
        {
            for (int index = 0; index < values.Length; ++index)
            {
                object obj = values[index];
                if (obj != null && obj.GetType() != typeof(bool) && (obj.Equals((object)0) || obj.Equals((object)string.Empty)))
                    values[index] = (object)null;
            }
            return ((Database)database).ExecuteDataSet(spName, values);
        }

        public static DbCommand GetStoredProcedure(string spName)
        {
            return ((Database)SqlDatabaseHelper.database).GetStoredProcCommand(spName);
        }

        public static object RunStoreProcedure(DbCommand cmd, string retVariable)
        {
            ((Database)SqlDatabaseHelper.database).ExecuteNonQuery(cmd);
            return ((Database)SqlDatabaseHelper.database).GetParameterValue(cmd, retVariable);
        }

        public static void ExecuteNonQuery(string spName, params object[] values)
        {
            ((Database)SqlDatabaseHelper.database).ExecuteNonQuery(spName, values);
        }

        public static void ExecuteNonQuery(Database database, string spName, params object[] values)
        {
            database.ExecuteNonQuery(spName, values);
        }

        public static bool TestConnection()
        {
            return SqlDatabaseHelper.TestConnection(SqlDatabaseHelper.database);
        }

        public static bool TestConnection(SqlDatabase database)
        {
            try
            {
                string str = "Select * From [CSCompanys]";
                DbCommand sqlStringCommand = ((Database)database).GetSqlStringCommand(str);
                ((Database)database).ExecuteDataSet(sqlStringCommand);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DbTransaction BeginTransaction()
        {
            return ((Database)SqlDatabaseHelper.database).CreateConnection().BeginTransaction();
        }

        public static void CommitTransaction(DbTransaction transaction)
        {
            transaction.Commit();
        }

        public static void RollbackTransaction(DbTransaction transaction)
        {
            transaction.Rollback();
        }

        public static DbCommand GetQuery(string strQueryCommand)
        {
            return ((Database)SqlDatabaseHelper.database).GetSqlStringCommand(strQueryCommand);
        }

        public static DbCommand GetQuery(string strTableName, string strTableQueryKey, string strQueryCommand)
        {
            string andTableQueryKey = SqlDatabaseHelper.GetQueryCommandByTableNameAndTableQueryKey(strTableName, strTableQueryKey);
            if (!string.IsNullOrEmpty(andTableQueryKey))
                return ((Database)SqlDatabaseHelper.database).GetSqlStringCommand(andTableQueryKey);
            SqlDatabaseHelper.InsertQueryCommand(strQueryCommand, strTableName, strTableQueryKey);
            return ((Database)SqlDatabaseHelper.database).GetSqlStringCommand(strQueryCommand);
        }

        private static string GetWhereClause(string strQueryCommand)
        {
            if (strQueryCommand.Contains("WHERE"))
                return strQueryCommand.Substring(strQueryCommand.IndexOf("WHERE"));
            return string.Empty;
        }

        public static string[] GetParameters(string strQueryCommand)
        {
            string[] array = new string[0];
            string str1 = SqlDatabaseHelper.GetWhereClause(strQueryCommand);
            if (string.IsNullOrEmpty(str1))
                return (string[])null;
            do
            {
                string str2 = str1.Substring(str1.IndexOf("@"));
                string str3 = str2.Substring(1, str2.IndexOf(")") - 1);
                Array.Resize<string>(ref array, array.Length + 1);
                array[array.Length - 1] = str3;
                str1 = str2.Substring(str3.Length + 1);
                if (str1.StartsWith(")"))
                    str1 = str1.Substring(1);
            }
            while (str1.Contains("@"));
            return array;
        }

        public static DataSet RunQuery(string strTableName, string strQueryCommandKey, string strQueryCommand, params object[] paramValues)
        {
            DbCommand query = SqlDatabaseHelper.GetQuery(strTableName, strQueryCommandKey, strQueryCommand);
            string[] parameters = SqlDatabaseHelper.GetParameters(strQueryCommand);
            if (parameters != null)
            {
                for (int index = 0; index < parameters.Length; ++index)
                {
                    if (paramValues[index].GetType().Equals(typeof(int)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.Int, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(bool)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.Bit, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(short)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.SmallInt, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(double)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.Float, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(Decimal)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.Decimal, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(string)) || paramValues[index].GetType().Equals(typeof(string)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.NVarChar, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(DateTime)))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.DateTime, paramValues[index]);
                    else if (paramValues[index].GetType().Equals(typeof(byte[])))
                        SqlDatabaseHelper.database.AddInParameter(query, parameters[index], SqlDbType.VarBinary, paramValues[index]);
                }
            }
            return SqlDatabaseHelper.RunQuery(query);
        }

        public static DataSet RunQuery(DbCommand cmd)
        {
            return ((Database)SqlDatabaseHelper.database).ExecuteDataSet(cmd);
        }

    }
}