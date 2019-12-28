using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.ManagerTimeKeeper
{
    public class ManagerTimeKeeperEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HRTimeKeeperCompletesInfo> TimeKeeperCompletesList { get; set; }
        public VinaList<HRTimeKeeperCompletesInfo> TimeKeeperCompletesList1 { get; set; }
        public List<HRTimeKeeperCompletesInfo> TimeKeeperCompleteBackupList2 { get; set; }
        public List<HRTimeKeeperCompletesInfo> TimeKeeperCompleteBackupList { get; set; }
        public VinaList<HRTimeKeeperCompletesInfo> TimeKeeperCompleteListView { get; set; }
        public VinaList<HRTimeKeeperCompletesInfo> TimeKeeperCompleteListView2 { get; set; }
        public VinaList<HRMachineTimeKeepersInfo> MachineTimeKeepersList { get; set; }
        public VinaList<HRTimeKeepersInfo> TimeKeepersList { get; set; }
        public VinaList<HRTimeKeepersInfo> TimeKeeperList { get; set; }

        public List<HREmployeesInfo> EmployeesList { get; set; }
        #endregion

        #region Constructor
        public ManagerTimeKeeperEntities()
            : base()
        {
            TimeKeeperCompletesList = new VinaList<HRTimeKeeperCompletesInfo>();
            TimeKeeperCompletesList1 = new VinaList<HRTimeKeeperCompletesInfo>();
            TimeKeeperCompleteBackupList2 = new List<HRTimeKeeperCompletesInfo>();
            TimeKeeperCompleteBackupList = new List<HRTimeKeeperCompletesInfo>();
            TimeKeeperCompleteListView = new VinaList<HRTimeKeeperCompletesInfo>();
            TimeKeeperCompleteListView2 = new VinaList<HRTimeKeeperCompletesInfo>();
            MachineTimeKeepersList = new VinaList<HRMachineTimeKeepersInfo>();
            TimeKeepersList = new VinaList<HRTimeKeepersInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
        }

        public override void InitModuleObjectList()
        {
            TimeKeeperCompletesList.InitVinaList(this,
                                             string.Empty,
                                             TableName.HRTimeKeeperCompletesTableName,
                                             VinaList<HRTimeKeeperCompletesInfo>.cstRelationNone);
            TimeKeeperCompletesList1.InitVinaList(this,
                                                         string.Empty,
                                                         TableName.HRTimeKeeperCompletesTableName,
                                                         VinaList<HRTimeKeeperCompletesInfo>.cstRelationNone);
            TimeKeeperCompleteListView.InitVinaList(this,
                                             string.Empty,
                                             TableName.HRTimeKeeperCompletesTableName,
                                             VinaList<HRTimeKeeperCompletesInfo>.cstRelationNone);
            TimeKeeperCompleteListView2.InitVinaList(this,
                                             string.Empty,
                                             TableName.HRTimeKeeperCompletesTableName,
                                             VinaList<HRTimeKeeperCompletesInfo>.cstRelationNone);
            MachineTimeKeepersList.InitVinaList(this,
                                                         string.Empty,
                                                         TableName.HRTimeKeeperCompletesTableName,
                                                         VinaList<HRMachineTimeKeepersInfo>.cstRelationNone);
            TimeKeepersList.InitVinaList(this,
                                             string.Empty,
                                             TableName.HRTimeKeepersTableName,
                                             VinaList<HRTimeKeepersInfo>.cstRelationNone);
        }

        public override void InitGridControlInVinaList()
        {
            TimeKeeperCompletesList.InitVinaListGridControl();
            TimeKeeperCompletesList1.InitVinaListGridControl();
            TimeKeeperCompleteListView.InitVinaListGridControl("fld_dgcHRTimeKeeperCompletesView");
            TimeKeeperCompleteListView2.InitVinaListGridControl("fld_dgcHRTimeKeeperCompletesView2");
            MachineTimeKeepersList.InitVinaListGridControl("fld_dgcHRMachineTimeKeepers");
            TimeKeepersList.InitVinaListGridControl("fld_dgcHRTimeKeepers");
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                TimeKeeperCompletesList.SetDefaultListAndRefreshGridControl();
                TimeKeeperCompletesList1.SetDefaultListAndRefreshGridControl();
                TimeKeeperCompleteListView.SetDefaultListAndRefreshGridControl();
                TimeKeeperCompleteListView2.SetDefaultListAndRefreshGridControl();
                MachineTimeKeepersList.SetDefaultListAndRefreshGridControl();
                TimeKeepersList.SetDefaultListAndRefreshGridControl();

            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public void SaveDataComplete(List<HRTimeKeeperCompletesInfo> timeKeepeCompleterList)
        {
            List<HRTimeKeeperCompletesInfo> TimeKeeperCompleteList = new List<HRTimeKeeperCompletesInfo>();
            if (timeKeepeCompleterList != null)
            {
                TimeKeeperCompleteList.AddRange(timeKeepeCompleterList);
                //TimeKeeperCompleteList.SaveItemObjects();
                HRTimeKeeperCompletesController objTimeKeeperCompletesController = new HRTimeKeeperCompletesController();
                int percent = 0;
                string mess = "Đang lưu dữ liệu: ";
                foreach (HRTimeKeeperCompletesInfo item in TimeKeeperCompleteList)
                {
                    percent++;
                    objTimeKeeperCompletesController.CreateObject(item);
                    if (TimeKeeperCompleteBackupList2.Where(o => o.HRTimeKeeperCompleteDate == item.HRTimeKeeperCompleteDate
                                                                    && o.HRTimeKeeperCompletesEmployeeCardNo == item.HRTimeKeeperCompletesEmployeeCardNo
                                                                    && o.FK_HRTimeKeeperID == item.FK_HRTimeKeeperID && o.HRTimeKeeperCompleteDateCheck == item.HRTimeKeeperCompleteDateCheck).Count() > 0
                        && TimeKeeperCompleteBackupList.Where(o => o.HRTimeKeeperCompleteDate == item.HRTimeKeeperCompleteDate
                                                                    && o.HRTimeKeeperCompletesEmployeeCardNo == item.HRTimeKeeperCompletesEmployeeCardNo
                                                                    && o.FK_HRTimeKeeperID == item.FK_HRTimeKeeperID && o.HRTimeKeeperCompleteDateCheck == item.HRTimeKeeperCompleteDateCheck).Count() > 0)
                    {
                        HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo = TimeKeeperCompleteBackupList2.Where(o => o.HRTimeKeeperCompleteDate == item.HRTimeKeeperCompleteDate
                                                                    && o.HRTimeKeeperCompletesEmployeeCardNo == item.HRTimeKeeperCompletesEmployeeCardNo
                                                                    && o.FK_HRTimeKeeperID == item.FK_HRTimeKeeperID && o.HRTimeKeeperCompleteDateCheck == item.HRTimeKeeperCompleteDateCheck).FirstOrDefault();

                        HRTimeKeeperCompletesInfo objTimeKeeperCompleteOldsInfo = TimeKeeperCompleteBackupList.Where(o => o.HRTimeKeeperCompleteDate == item.HRTimeKeeperCompleteDate
                                                                    && o.HRTimeKeeperCompletesEmployeeCardNo == item.HRTimeKeeperCompletesEmployeeCardNo
                                                                    && o.FK_HRTimeKeeperID == item.FK_HRTimeKeeperID && o.HRTimeKeeperCompleteDateCheck == item.HRTimeKeeperCompleteDateCheck).FirstOrDefault();
                        SaveHistory(TableName.HRTimeKeeperCompletesTableName, objTimeKeeperCompleteOldsInfo, objTimeKeeperCompletesInfo, "Change");
                    }
                }
            }
        }

        public void SaveHistory(string ItemTableName, HRTimeKeeperCompletesInfo oldObject, HRTimeKeeperCompletesInfo newObject, string type)
        {
            //AAColumnAliasController objColumnAliasController = new AAColumnAliasController();
            //List<AAColumnAliasInfo> columnAliasList = new List<AAColumnAliasInfo>();
            //DataSet ds = objColumnAliasController.GetAAColumnAliasByTableName(ItemTableName);
            //if (ds.Tables.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        AAColumnAliasInfo objColumnAliasInfo = (AAColumnAliasInfo)objColumnAliasController.GetObjectFromDataRow(row);
            //        columnAliasList.Add(objColumnAliasInfo);
            //    }
            //}

            //List<HRTimeKeeperHistoryDetailsInfo> historyDetailList = new List<HRTimeKeeperHistoryDetailsInfo>();
            //BOSDbUtil dbUtil = new BOSDbUtil();
            //HRTimeKeeperHistorysController objTimeKeeperHistorysController = new HRTimeKeeperHistorysController();
            //HRTimeKeeperHistoryDetailsController objTimeKeeperHistoryDetailsController = new HRTimeKeeperHistoryDetailsController();
            //HRTimeKeeperHistorysInfo objTimeKeeperHistorysInfo;

            //List<HRTimeKeeperHistorysInfo> historyList = new List<HRTimeKeeperHistorysInfo>();
            //historyList = objTimeKeeperHistorysController.GetTimeKeeperHistoryByTimeKeeperComplete();
            //if (historyList != null)
            //{
            //    historyList.ForEach(o =>
            //    {
            //        objTimeKeeperHistorysController.DeleteObject(o.HRTimeKeeperHistoryID);
            //        objTimeKeeperHistoryDetailsController.DeleteByForeignColumn("FK_HRTimeKeeperHistoryID", o.HRTimeKeeperHistoryID);
            //    });
            //}

            //foreach (AAColumnAliasInfo alias in columnAliasList)
            //{
            //    string oldValue = "";
            //    string newValue = "";
            //    if (dbUtil.GetPropertyValue(oldObject, alias.AAColumnAliasName) != null)
            //    {
            //        oldValue = dbUtil.GetPropertyValue(oldObject, alias.AAColumnAliasName).ToString();
            //    }

            //    if (dbUtil.GetPropertyValue(newObject, alias.AAColumnAliasName) != null)
            //    {
            //        newValue = dbUtil.GetPropertyValue(newObject, alias.AAColumnAliasName).ToString();
            //    }

            //    if (oldValue != newValue)
            //    {
            //        HRTimeKeeperHistoryDetailsInfo objTimeKeeperHistoryDetailsInfo = new HRTimeKeeperHistoryDetailsInfo();
            //        objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailTableName = ItemTableName;
            //        objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailColumnName = alias.AAColumnAliasCaption;
            //        objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailOldValue = oldValue;
            //        objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailNewValue = newValue;
            //        objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailEmployeeCardNumber = newObject.HRTimeKeeperCompletesEmployeeCardNo;
            //        historyDetailList.Add(objTimeKeeperHistoryDetailsInfo);
            //    }
            //}

            //if (type == "Cancel")
            //{
            //    HRTimeKeeperHistoryDetailsInfo objTimeKeeperHistoryDetailsInfo = new HRTimeKeeperHistoryDetailsInfo();
            //    objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailTableName = ItemTableName;
            //    objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailEmployeeCardNumber = newObject.HRTimeKeeperCompletesEmployeeCardNo;
            //    objTimeKeeperHistoryDetailsInfo.HRTimeKeeperHistoryDetailOldValue = oldObject.HRTimeKeeperCompleteDateCheck.ToString();
            //    historyDetailList.Add(objTimeKeeperHistoryDetailsInfo);
            //}

            //if (historyDetailList.Count > 0 || type == "Cancel")
            //{
            //    objTimeKeeperHistorysInfo = new HRTimeKeeperHistorysInfo();
            //    objTimeKeeperHistorysInfo.ADUserID = BOSApp.CurrentUsersInfo.ADUserID;
            //    objTimeKeeperHistorysInfo.ADUserName = BOSApp.CurrentUsersInfo.ADUserName;
            //    objTimeKeeperHistorysInfo.HRTimeKeeperHistoryObjectName = ItemTableName;
            //    objTimeKeeperHistorysInfo.HRTimeKeeperHistoryAction = type;
            //    objTimeKeeperHistorysInfo.HRTimeKeeperHistoryDate = dbUtil.GetCurrentServerDate();
            //    objTimeKeeperHistorysInfo.HRTimeKeeperHistoryObjectID = newObject.HRTimeKeeperCompleteID;
            //    objTimeKeeperHistorysInfo.FK_HRTimeKeeperCompleteID = newObject.HRTimeKeeperCompleteID;
            //    int parentHistoryID = objTimeKeeperHistorysController.CreateObject(objTimeKeeperHistorysInfo);
            //    if (parentHistoryID > 0)
            //    {
            //        foreach (HRTimeKeeperHistoryDetailsInfo item in historyDetailList)
            //        {
            //            item.FK_HRTimeKeeperHistoryID = parentHistoryID;
            //            objTimeKeeperHistoryDetailsController.CreateObject(item);
            //        }
            //    }
            //}
        }

        public void SaveTimeKeeperCompleteListView()
        {
            TimeKeeperCompleteListView.SaveItemObjects();
            TimeKeeperCompleteListView2.SaveItemObjects();
        }

        public void SaveData(List<HRTimeKeepersInfo> timeKeeperList)
        {
            TimeKeeperList = new VinaList<HRTimeKeepersInfo>();
            TimeKeeperList.AddRange(timeKeeperList);
            HRTimeKeepersController objTimeKeepersController = new HRTimeKeepersController();
            int percent = 0;
            string mess = "Đang lưu dữ liệu: ";
            foreach (HRTimeKeepersInfo item in TimeKeeperList)
            {
                percent++;
                double pct = (percent * 100) / TimeKeeperList.Count;
                VinaProgressBar.Start(mess + ": " + Math.Round(pct) + " % ");
                objTimeKeepersController.CreateObject(item);
            }
           VinaProgressBar.Close();
        }
    }
}
