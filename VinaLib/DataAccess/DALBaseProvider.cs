using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class DALBaseProvider
    {
        public string TableName { get; set; }

        public Type ObjectType { get; set; }

        public DALBaseProvider()
        {
        }

        public DALBaseProvider(string strTableName, Type objType)
        {
            this.TableName = strTableName;
            this.ObjectType = objType;
        }

        private string GenerateInsertQuery()
        {
            string str = string.Format("INSERT INTO [dbo].[{0}] ", (object)this.TableName);
            DataSet allTableColumns = SqlDatabaseHelper.GetAllTableColumns(this.TableName);
            if (allTableColumns.Tables.Count > 0)
                str = str + this.GenerateInsertColumns(allTableColumns) + " VALUES " + this.GenerateInsertColumnParameters(allTableColumns);
            return str;
        }

        private string GenerateInsertColumns(DataSet dsTableColumns)
        {
            string str = "(";
            for (int index = 0; index < dsTableColumns.Tables[0].Rows.Count; ++index)
                str = index != dsTableColumns.Tables[0].Rows.Count - 1 ? str + "[" + dsTableColumns.Tables[0].Rows[index]["COLUMN_NAME"].ToString() + "]," : str + "[" + dsTableColumns.Tables[0].Rows[index]["COLUMN_NAME"].ToString() + "])";
            return str;
        }

        private string GenerateInsertColumnParameters(DataSet dsTableColumns)
        {
            string str = "(";
            for (int index = 0; index < dsTableColumns.Tables[0].Rows.Count; ++index)
                str = index != dsTableColumns.Tables[0].Rows.Count - 1 ? str + "@" + dsTableColumns.Tables[0].Rows[index]["COLUMN_NAME"].ToString() + "," : str + "@" + dsTableColumns.Tables[0].Rows[index]["COLUMN_NAME"].ToString() + ")";
            return str;
        }

        private string GenerateUpdateQuery()
        {
            string str = string.Format("UPDATE [dbo].[{0}] SET ", (object)this.TableName);
            DataSet allTableColumns = SqlDatabaseHelper.GetAllTableColumns(this.TableName);
            if (allTableColumns.Tables.Count > 0)
                str = str + this.GenerateUpdateSetStatement(allTableColumns) + " WHERE " + this.GenerateUpdateQueryWhereClause(allTableColumns);
            return str;
        }

        private string GenerateUpdateSetStatement(DataSet dsTableColumns)
        {
            string str = string.Empty;
            for (int index = 0; index < dsTableColumns.Tables[0].Rows.Count; ++index)
            {
                string strColumnName = dsTableColumns.Tables[0].Rows[index]["COLUMN_NAME"].ToString();
                if (!SqlDatabaseHelper.ColumnIsPrimaryKey(this.TableName, strColumnName))
                {
                    if (index == dsTableColumns.Tables[0].Rows.Count - 1)
                        str = str + "[" + strColumnName + "] = @" + strColumnName;
                    else
                        str = str + "[" + strColumnName + "] = @" + strColumnName + ",";
                }
            }
            return str;
        }

        private string GenerateUpdateQueryWhereClause(DataSet dsTableColumns)
        {
            string empty = string.Empty;
            string primaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName);
            return empty + "[" + primaryKeyColumn + "] = @" + primaryKeyColumn;
        }

        private string GenerateSelectAllQuery()
        {
            return string.Format("SELECT * FROM [dbo].[{0}]", (object)this.TableName);
        }

        private string GenerateSelectByPrimaryKeyQuery()
        {
            return string.Format("SELECT * FROM [dbo].[{0}] WHERE [{1}]=@{2}", (object)this.TableName, (object)SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), (object)SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName));
        }

        private string GenerateDeleteQuery()
        {
            return string.Format("DELETE FROM [dbo].[{0}] WHERE [{1}]=@{2}", (object)this.TableName, (object)SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), (object)SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName));
        }

        private string GenerateDeleteAllObjectsQuery()
        {
            return string.Format("DELETE FROM [dbo].[{0}]", (object)this.TableName);
        }

        #region "Genarate Procedure Name"
        private string GenerateInsertStoredProcedureName()
        {
            return string.Format("{0}_Insert", (object)this.TableName);
        }

        private string GenerateUpdateStoredProcedureName()
        {
            return string.Format("{0}_Update", (object)this.TableName);
        }

        private string GenerateSelectByPrimaryKeyStoredProcedureName()
        {
            return string.Format("{0}_SelectByID", (object)this.TableName);
        }

        private string GenerateSelectByNameStoredProcedureName()
        {
            return string.Format("{0}_SelectByName", (object)this.TableName);
        }

        private string GenerateSelectByNoStoredProcedureName()
        {
            return string.Format("{0}_SelectByNo", (object)this.TableName);
        }

        private string GenerateDeleteStoredProcedureName()
        {
            return string.Format("{0}_DeleteByID", (object)this.TableName);
        }

        private string GenerateDeleteByForeignColumnStoredProcedureName(string strForeignColumn)
        {
            return string.Format("{0}_DeleteBy{1}", (object)this.TableName, (object)strForeignColumn);
        }

        private string GenerateSelectAllStoredProcedureName()
        {
            return string.Format("{0}_SelectAll", (object)this.TableName);
        }

        private string GenerateDeleteAllStoredProcedureName()
        {
            return string.Format("{0}_DeleteAll", (object)this.TableName);
        }

        private string GenerateSelectDeletedByPrimayKeyStoredProcedureName()
        {
            return string.Format("{0}_SelectDeletedByID", (object)this.TableName);
        }

        private string GenerateSelectByForeignColumnStoredProcedureName(string strForeignColumnName)
        {
            return string.Format("{0}_SelectBy{1}", (object)this.TableName, (object)strForeignColumnName);
        }

        private string GenerateSearchObjectStoredProcedureName()
        {
            return string.Format("{0}_Search", (object)this.TableName);
        }
        #endregion

        public void SetValueToPrimaryColumn(object obj, int iObjectID)
        {
            SqlDatabaseHelper.SetValueToPrimaryColumn(obj, this, iObjectID);
        }

        public void SetValueToIDStringColumn(object obj, int iObjectID)
        {
            SqlDatabaseHelper.SetValueToIDStringColumn(obj, this, iObjectID);
        }

        public object GetPrimaryColumnValue(object obj)
        {
            return SqlDatabaseHelper.GetPrimaryColumnValue(obj, this);
        }

        public virtual int GetMaxID()
        {
            return SqlDatabaseHelper.GetMaxID(this.TableName);
        }

        public DbCommand GetStoredProcedureCommand(string spName)
        {
            return SqlDatabaseHelper.GetStoredProcedure(spName);
        }

        public void AddParameter(DbCommand cmd, string name, DbType type, ParameterDirection direction, object value)
        {
            SqlDatabaseHelper.AddParameter(cmd, name, type, direction, value);
        }

        public void ExecuteStoredProcedure(string spName, params object[] parameters)
        {
            SqlDatabaseHelper.RunStoredProcedure(spName, parameters);
        }

        public object GetParameterValue(DbCommand cmd, string paramName)
        {
            if (cmd.Parameters[paramName].Value == DBNull.Value)
                return (object)null;
            return cmd.Parameters[paramName].Value;
        }

        public DbTransaction BeginTransaction()
        {
            return SqlDatabaseHelper.BeginTransaction();
        }

        public void CommitTransaction(DbTransaction transaction)
        {
            SqlDatabaseHelper.CommitTransaction(transaction);
        }

        public void RollbackTransaction(DbTransaction transaction)
        {
            SqlDatabaseHelper.RollbackTransaction(transaction);
        }

        public virtual int CreateObject(object obj)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, this.GenerateInsertStoredProcedureName());
        }

        public virtual int CreateObject(object obj, DbTransaction transaction)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, this.GenerateInsertStoredProcedureName(), transaction);
        }

        public virtual int UpdateObject(object obj)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, this.GenerateUpdateStoredProcedureName());
        }

        public virtual int UpdateObject(object obj, DbTransaction transaction)
        {
            return SqlDatabaseHelper.InsertObject(obj, this, this.GenerateUpdateStoredProcedureName(), transaction);
        }

        public virtual void DeleteObject(int iObjectID)
        {
            DbCommand storedProcedure = SqlDatabaseHelper.GetStoredProcedure(this.GenerateDeleteStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(storedProcedure, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), SqlDbType.Int, (object)iObjectID);
            SqlDatabaseHelper.RunStoredProcedure(storedProcedure);
        }

        public virtual void DeleteObject(int iObjectID, DbTransaction transaction)
        {
            try
            {
                DbCommand storedProcedure = SqlDatabaseHelper.GetStoredProcedure(this.GenerateDeleteStoredProcedureName());
                SqlDatabaseHelper.AddInParameter(storedProcedure, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), SqlDbType.Int, (object)iObjectID);
                storedProcedure.Transaction = transaction;
                SqlDatabaseHelper.RunStoredProcedure(storedProcedure);
                SqlDatabaseHelper.CommitTransaction(transaction);
            }
            catch (Exception ex)
            {
                SqlDatabaseHelper.RollbackTransaction(transaction);
            }
        }

        public virtual void DeleteAllObjects()
        {
            SqlDatabaseHelper.RunStoredProcedure(this.GenerateDeleteAllStoredProcedureName());
        }

        public virtual void DeleteByForeignColumn(string strForeignColumn, object objValue)
        {
            SqlDatabaseHelper.RunStoredProcedure(this.GenerateDeleteByForeignColumnStoredProcedureName(strForeignColumn), objValue);
        }

        public virtual object GetObjectById(int iObjectID)
        {
            DbCommand storedProcedure = SqlDatabaseHelper.GetStoredProcedure(this.GenerateSelectByPrimaryKeyStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(storedProcedure, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), SqlDbType.Int, (object)iObjectID);
            DataSet dataSet = SqlDatabaseHelper.RunStoredProcedure(storedProcedure);
            if (dataSet.Tables.Count <= 0)
                return (object)null;
            return SqlDatabaseHelper.GetSingleObject(dataSet.Tables[0], this.ObjectType);
        }

        public virtual DataSet GetDataSetByID(int iObjectID)
        {
            DbCommand storedProcedure = SqlDatabaseHelper.GetStoredProcedure(this.GenerateSelectByPrimaryKeyStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(storedProcedure, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), SqlDbType.Int, (object)iObjectID);
            return SqlDatabaseHelper.RunStoredProcedure(storedProcedure);
        }

        public virtual string GetObjectNameByID(int iObjectID)
        {
            object objectById = this.GetObjectById(iObjectID);
            if (objectById != null)
            {
                PropertyInfo property = this.ObjectType.GetProperty(SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName).Substring(0, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName).Length - 2) + "Name");
                if (property != null)
                    return property.GetValue(objectById, (object[])null).ToString();
            }
            return string.Empty;
        }

        public virtual string GetObjectNoByID(int iObjectID)
        {
            object objectById = this.GetObjectById(iObjectID);
            if (objectById != null)
            {
                PropertyInfo property = this.ObjectType.GetProperty(SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName).Substring(0, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName).Length - 2) + "No");
                if (property != null)
                    return property.GetValue(objectById, (object[])null).ToString();
            }
            return string.Empty;
        }

        public virtual object GetObjectByName(string strObjectName)
        {
            try
            {
                DataSet dataSet = SqlDatabaseHelper.RunStoredProcedure(this.GenerateSelectByNameStoredProcedureName(), (object)strObjectName);
                if (dataSet.Tables.Count > 0)
                    return SqlDatabaseHelper.GetSingleObject(dataSet.Tables[0], this.ObjectType);
            }
            catch (Exception ex)
            {
                return (object)null;
            }
            return (object)null;
        }

        public virtual object GetObjectByNo(string strObjectNo)
        {
            try
            {
                DataSet dataSet = SqlDatabaseHelper.RunStoredProcedure(this.GenerateSelectByNoStoredProcedureName(), (object)strObjectNo);
                if (dataSet.Tables.Count > 0)
                    return SqlDatabaseHelper.GetSingleObject(dataSet.Tables[0], this.ObjectType);
            }
            catch (Exception ex)
            {
                return (object)null;
            }
            return (object)null;
        }

        public virtual int GetObjectIDByName(string strObjectName)
        {
            int num = 0;
            object objectByName = this.GetObjectByName(strObjectName);
            if (objectByName != null)
                num = Convert.ToInt32(SqlDatabaseHelper.GetPrimaryColumnValue(objectByName, this));
            return num;
        }

        public virtual int GetObjectIDByNo(string strObjectNo)
        {
            int num = 0;
            object objectByNo = this.GetObjectByNo(strObjectNo);
            if (objectByNo != null)
                num = Convert.ToInt32(SqlDatabaseHelper.GetPrimaryColumnValue(objectByNo, this));
            return num;
        }

        public virtual object GetDeletedObjectByID(int iObjectID)
        {
            DbCommand storedProcedure = SqlDatabaseHelper.GetStoredProcedure(this.GenerateSelectDeletedByPrimayKeyStoredProcedureName());
            SqlDatabaseHelper.AddInParameter(storedProcedure, SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName), SqlDbType.Int, (object)iObjectID);
            DataSet dataSet = SqlDatabaseHelper.RunStoredProcedure(storedProcedure);
            if (dataSet.Tables.Count <= 0)
                return (object)null;
            return SqlDatabaseHelper.GetSingleObject(dataSet.Tables[0], this.ObjectType);
        }

        public DataSet GetDataSet(string spName, params object[] paramValues)
        {
            return SqlDatabaseHelper.RunStoredProcedure(spName, paramValues);
        }

        public DataSet GetDataSet(string strQuery)
        {
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(strQuery));
        }

        public DataSet GetDataSet(DbCommand cmd)
        {
            return SqlDatabaseHelper.RunStoredProcedure(cmd);
        }

        public object GetDataObject(string spName, params object[] paramValues)
        {
            return this.GetSingleObject(SqlDatabaseHelper.RunStoredProcedure(spName, paramValues).Tables[0]);
        }

        public object GetSingleValue(string spName, params object[] paramValues)
        {
            DataSet dataSet = this.GetDataSet(spName, paramValues);
            object obj = (object)null;
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
                obj = dataSet.Tables[0].Rows[0][0];
            return obj;
        }

        public object GetSingleObject(DataTable dt)
        {
            return SqlDatabaseHelper.GetSingleObject(dt, this.ObjectType);
        }

        public object GetFirstObject()
        {
            return this.GetSingleObject(this.GetAllObject().Tables[0]);
        }

        public object GetObjectFromDataRow(DataRow row)
        {
            return SqlDatabaseHelper.GetObjectFromDataRow(row, this.ObjectType);
        }

        public DataSet SearchObject(object objSearch)
        {
            DbCommand storedProcedure = SqlDatabaseHelper.GetStoredProcedure(this.GenerateSearchObjectStoredProcedureName());
            SqlDatabaseHelper.AddParameterForSearchProperties(objSearch, storedProcedure);
            return SqlDatabaseHelper.RunStoredProcedure(storedProcedure);
        }

        public DataSet GetAllDataByForeignColumn(string strForeignColumnName, object objValue)
        {
            return SqlDatabaseHelper.RunStoredProcedure(this.GenerateSelectByForeignColumnStoredProcedureName(strForeignColumnName), objValue);
        }

        public virtual DataSet GetAllObject()
        {
            return SqlDatabaseHelper.RunStoredProcedure(this.GenerateSelectAllStoredProcedureName());
        }

        public DataSet GetAllObjectsByObjectParentID(int iObjectParentID)
        {
            string primaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName);
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("Select *, (select COUNT(*) from [{0}] tbl2 where tbl2.[{1}] = tbl1.[{3}] and tbl2.AAStatus = 'Alive') as TheNumberOfChild From [{0}] tbl1 Where AAStatus = 'Alive' And ([{1}]={2}) And ({2}>0)", (object)this.TableName, (object)(primaryKeyColumn.Substring(0, primaryKeyColumn.Length - 2) + "ParentID"), (object)iObjectParentID, (object)primaryKeyColumn)));
        }

        public void DeleteAllObjectsByObjectParentID(int iObjectParentID)
        {
            string primaryKeyColumn = SqlDatabaseHelper.GetPrimaryKeyColumn(this.TableName);
            string strColumnName = primaryKeyColumn.Substring(0, primaryKeyColumn.Length - 2) + "ParentID";
            if (!SqlDatabaseHelper.ColumnIsExistInTable(this.TableName, strColumnName))
                return;
            SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("Update [{0}] Set AAStatus = 'Delete' Where ([{1}]={2}) And ({2}>0)", (object)this.TableName, (object)strColumnName, (object)iObjectParentID)));
        }

        public DataSet GetMembersFromOwner(string strOwnerTable, int iOwnerID, string strMemberTable, string strSwitcherTable)
        {
            string primaryKeyColumn1 = SqlDatabaseHelper.GetPrimaryKeyColumn(strOwnerTable);
            SqlDatabaseHelper.GetPrimaryKeyColumn(strSwitcherTable);
            string primaryKeyColumn2 = SqlDatabaseHelper.GetPrimaryKeyColumn(strMemberTable);
            string str = string.Format("Select [{0}] From [{1}] Where [{1}].[{2}] IN (Select [{2}] From [{3}] Where [{3}].[{2}]={4})", (object)primaryKeyColumn2, (object)strSwitcherTable, (object)primaryKeyColumn1, (object)strOwnerTable, (object)iOwnerID);
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("Select * From [{0}] Where [{1}] IN ({2})", (object)strMemberTable, (object)primaryKeyColumn2, (object)str)));
        }

        public DataSet DeleteMembersFromOwner(string strOwnerTable, int iOwnerID, string strMemberTable, string strSwitcherTable)
        {
            string primaryKeyColumn1 = SqlDatabaseHelper.GetPrimaryKeyColumn(strOwnerTable);
            SqlDatabaseHelper.GetPrimaryKeyColumn(strSwitcherTable);
            string primaryKeyColumn2 = SqlDatabaseHelper.GetPrimaryKeyColumn(strMemberTable);
            string str = string.Format("Select [{0}] From [{1}] Where [{1}].[{2}] IN (Select [{2}] From [{3}] Where [{3}].[{2}]={4}))", (object)primaryKeyColumn2, (object)strSwitcherTable, (object)primaryKeyColumn1, (object)strOwnerTable, (object)iOwnerID);
            return SqlDatabaseHelper.RunQuery(SqlDatabaseHelper.GetQuery(string.Format("Detete From [{0}] Where [{1}] IN ({2})", (object)strMemberTable, (object)primaryKeyColumn2, (object)str)));
        }
    }
}

