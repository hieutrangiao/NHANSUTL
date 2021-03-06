﻿using VinaLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaLib;
using VinaLib;
using System.Reflection;
using BOSLib;

namespace VinaERP
{
    public class ERPModuleEntities
    {
        #region Constant
        public const String AAStatusColumn = "AAStatus";
        public const String AACreatedUser = "AACreatedUser";
        public const String AACreatedDate = "AACreatedDate";
        public const String AAUpdatedUser = "AAUpdatedUser";
        public const String AAUpdatedDate = "AAUpdatedDate";

        public const String NewObjectNoText = "***NEW***";
        #endregion

        public BaseModule Module { get; set; }

        public BusinessObject MainObject { get; set; }

        public BusinessObject SearchObject { get; set; }

        public BindingSource SearchObjectBindingSource { get; set; }

        public BindingSource MainObjectBindingSource { get; set; }

        #region Constructor
        public ERPModuleEntities()
        {
            MainObjectBindingSource = new BindingSource();
        }

        public virtual void InitModuleEntity()
        {
            InitMainObject();
            InitModuleObjects();
            InitModuleObjectList();

            InitMainObjectBindingSource();
        }

        public virtual void InitGridControlInVinaList()
        {

        }

        #endregion

        #region Init MainObject, ModuleObjects Functions
        public virtual void InitMainObject()
        {

        }

        public virtual void InitModuleObjects()
        {

        }

        public virtual void InitModuleObjectList()
        {

        }

        public virtual void InitMainObjectBindingSource()
        {
            if (MainObject != null)
            {
                MainObjectBindingSource.DataSource = MainObject;
            }
            if (SearchObject != null)
            {
                SearchObjectBindingSource = new BindingSource();
                SearchObjectBindingSource.DataSource = SearchObject;
            }
        }
        #endregion

        public virtual void Invalidate(int iObjectID)
        {
            InvalidateMainObject(iObjectID);
            InvalidateModuleObjects(iObjectID);
        }

        public virtual void InvalidateMainObject(int iObjectID)
        {
            Type typMainObjectType = MainObject.GetType();
            BaseBusinessController objMainObjectController = new BaseBusinessController(typMainObjectType);
            MainObject = (BusinessObject)objMainObjectController.GetObjectByID(iObjectID);
            UpdateMainObjectBindingSource();
        }

        public virtual void UpdateMainObjectBindingSource()
        {
            MainObjectBindingSource.DataSource = this.MainObject;
            MainObjectBindingSource.ResetBindings(false);
        }

        public virtual void InvalidateModuleObjects(int iObjectID)
        {

        }


        #region "Action New"
        public virtual void New()
        {
            this.SetDefaultMainObject();
            //this.SetDefaultModuleObjects();
            this.SetDefaultModuleObjectsList();
        }

        public virtual void SetDefaultMainObject()
        {
            try
            {
                VinaDbUtil vinaDbUtil = new VinaDbUtil();

                string fromBusinessObject = VinaUtil.GetTableNameFromBusinessObject(this.MainObject);
                string str = fromBusinessObject.Substring(0, fromBusinessObject.Length - 1) + "ID";
                this.MainObject = (BusinessObject)BusinessObjectFactory.GetBusinessObject(fromBusinessObject + "Info");

                vinaDbUtil.SetPropertyValue(this.MainObject, str.Substring(0, str.Length - 2) + "No", (object)BusinessObject.DefaultObjectNo);
                vinaDbUtil.SetPropertyValue(this.MainObject, "AAStatus", (object)BusinessObject.DefaultAAStatus);

                this.UpdateMainObjectBindingSource();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region "Action Save"
        public virtual int SaveMainObject()
        {
            if (Module.Toolbar.IsNewAction())
                return CreateMainObject();
            else
                return UpdateMainObject();
        }

        public virtual int CreateMainObject()
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            int iObjectID = 0;
            bool editObjectNo = true;

            //Get Table which Business object Represent            
            String strMainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(MainObject);
            BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");

            //Set Object No value
            String strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";
            String strColumnNo = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "No";
            String strMainObjectNo = dbUtil.GetPropertyStringValue(MainObject, strColumnNo);
            int numberingStart = 0;
            try
            {
                if (strMainObjectNo.Equals(NewObjectNoText))
                {
                    editObjectNo = false;
                    strMainObjectNo = GetMainObjectNo(ref numberingStart);
                    dbUtil.SetPropertyValue(MainObject, strColumnNo, strMainObjectNo);
                }

                //Set Created User, Created Date
                dbUtil.SetPropertyValue(MainObject, AACreatedUser, VinaApp.CurrentUserName);
                dbUtil.SetPropertyValue(MainObject, AACreatedDate, DateTime.Now);


                iObjectID = dbUtil.GetPropertyIntValue(MainObject, strPrimaryColumn);
                if (iObjectID == 0)
                {
                    iObjectID = objMainObjectController.CreateObject(MainObject);
                }
                else
                {
                    objMainObjectController.CreateObject(MainObject, iObjectID);
                }
            }
            catch (Exception ex)
            {
                if (!editObjectNo)
                {
                    dbUtil.SetPropertyValue(MainObject, strColumnNo, NewObjectNoText);
                    dbUtil.SetPropertyValue(MainObject, strPrimaryColumn, 0);
                }

                iObjectID = 0;
                MessageBox.Show(ex.Message.ToString());
            }

            return iObjectID;
        }

        public virtual int UpdateMainObject()
        {
            int iObjectID = 0;
            String strMainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(MainObject);
            BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");

            VinaDbUtil dbUtil = new VinaDbUtil();
            dbUtil.SetPropertyValue(MainObject, AAUpdatedUser, VinaApp.CurrentUserName);
            dbUtil.SetPropertyValue(MainObject, AAUpdatedDate, DateTime.Now);

            iObjectID = objMainObjectController.UpdateObject(MainObject);
            return iObjectID;
        }
        #endregion

        public virtual void SetDefaultModuleObjectsList()
        {

        }

        public virtual void SaveModuleObjects()
        {

        }

        public virtual String GetMainObjectNo(ref int numberingStart)
        {
            String strMainObjectNo = String.Empty;
            GENumberingsController objGENumberingController = new GENumberingsController();
            GENumberingsInfo objGENumberingInfo = (GENumberingsInfo)objGENumberingController.GetObjectByName(Module.CurrentModuleName);

            if (objGENumberingInfo != null)
            {
                String mainTableName = VinaUtil.GetTableNameFromBusinessObject(MainObject);
                BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(mainTableName + "Controller");
                if (objMainObjectController != null)
                {
                    VinaDbUtil dbUtil = new VinaDbUtil();
                    string strPrefixHaveYear = DateTime.Now.Year.ToString().Substring(2,2);
                    List<string> subMainObjectNoList = new List<string>();
                    subMainObjectNoList.Add(objGENumberingInfo.GENumberingPrefix);
                    if (objGENumberingInfo.GENumberingPrefixHaveYear)
                    {
                        subMainObjectNoList.Add(strPrefixHaveYear);
                    }
                    subMainObjectNoList.Add(objGENumberingInfo.GENumberingNumber.ToString().PadLeft(objGENumberingInfo.GENumberingLength, '0'));

                    strMainObjectNo = string.Join(".", subMainObjectNoList.ToArray());

                    numberingStart = objGENumberingInfo.GENumberingNumber;
                    while (objMainObjectController.IsExist(strMainObjectNo))
                    {
                        objGENumberingInfo.GENumberingNumber++;

                        subMainObjectNoList.Clear();
                        subMainObjectNoList.Add(objGENumberingInfo.GENumberingPrefix);
                        if (objGENumberingInfo.GENumberingPrefixHaveYear)
                        {
                            subMainObjectNoList.Add(strPrefixHaveYear);
                        }
                        subMainObjectNoList.Add(objGENumberingInfo.GENumberingNumber.ToString().PadLeft(objGENumberingInfo.GENumberingLength, '0'));

                        strMainObjectNo = string.Join(".", subMainObjectNoList.ToArray());
                        numberingStart = objGENumberingInfo.GENumberingNumber;
                    }
                }
            }
            return strMainObjectNo;
        }

        public virtual void SetProductPrice(BusinessObject item)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            String itemTableName = VinaUtil.GetTableNameFromBusinessObject(item);
            string itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);

            //Get Item Qty
            String columnName = itemTablePrefix + "ProductQty";
            decimal qty = Convert.ToDecimal(dbUtil.GetPropertyValue(item, columnName));
            if (qty == 0)
            {
                qty = 1;
                dbUtil.SetPropertyValue(item, columnName, qty);
            }

            //Get Item Unit Price
            columnName = itemTablePrefix + "ProductUnitPrice";
            decimal unitPrice = Convert.ToDecimal(dbUtil.GetPropertyValue(item, columnName));

            //Get Item Discount Percent                
            columnName = itemTablePrefix + "DiscountPercent";
            decimal discountPercent = Convert.ToDecimal(dbUtil.GetPropertyValue(item, columnName));

            //Set Item Discount Amount                
            columnName = itemTablePrefix + "DiscountAmount";
            decimal discountAmount = qty * unitPrice * discountPercent / 100;
            dbUtil.SetPropertyValue(item, columnName, discountAmount);

            //Get Item Tax Percent
            columnName = itemTablePrefix + "TaxPercent";
            decimal taxPercent = Convert.ToDecimal(dbUtil.GetPropertyValue(item, columnName));

            //Set Item Tax Amount                
            columnName = itemTablePrefix + "TaxAmount";
            decimal taxAmount = (qty * unitPrice - discountAmount) * taxPercent / 100;
            dbUtil.SetPropertyValue(item, columnName, taxAmount);

            //Set Item Total Amount
            columnName = itemTablePrefix + "TotalAmount";
            dbUtil.SetPropertyValue(item, columnName, qty * unitPrice - discountAmount + taxAmount);
        }

        public virtual void CreateMainObjectRule()
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            MainObject.BusinessRuleCollections = new List<BusinessRule>();
            String strMainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(MainObject);

            DataSet dsColumns = dbUtil.GetNotAllowNullTableColumns(strMainObjectTableName);
            if (dsColumns.Tables.Count > 0)
            {
                AAColumnAliasController objColumnAlliasController = new AAColumnAliasController();
                List<AAColumnAliasInfo> LstColumnAlias = objColumnAlliasController.GetColumnAliasByTableName(strMainObjectTableName);
                foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
                {
                    String strColumnName = rowColumn["COLUMN_NAME"].ToString();
                    String strBrokenRuleDescription = String.Empty;
                    //Add rule if column is not primary key
                    if (!dbUtil.IsPrimaryKey(strMainObjectTableName, strColumnName))
                    {
                        //If column does not allow null
                        if (!dbUtil.ColumnIsAllowNull(strMainObjectTableName, strColumnName))
                        {
                            AAColumnAliasInfo objColumnAliasInfo = LstColumnAlias.Where(a => a.AATableName == strMainObjectTableName
                            && a.AAColumnAliasName == strColumnName).FirstOrDefault();
                            if (objColumnAliasInfo != null)
                            {
                                strBrokenRuleDescription = String.Format(string.Format("{0} không thể để trống", objColumnAliasInfo.AAColumnAliasCaption));
                            }
                            else
                            {
                                strBrokenRuleDescription = String.Format(string.Format("{0} không thể để trống", strColumnName));
                            }

                            if (((IBaseModuleERP)Module).IsForeignKey(strMainObjectTableName, strColumnName))
                            {
                                BusinessRule foreignKeyRule = new BusinessRule(
                                                                    strColumnName,
                                                                    strBrokenRuleDescription,
                                                                    IsValidForeignKeyProperty);
                                MainObject.BusinessRuleCollections.Add(foreignKeyRule);
                            }
                            else
                            {
                                BusinessRule nonForeignKeyRule = new BusinessRule(strColumnName, strBrokenRuleDescription, IsValidNonForeignKeyPropety);
                                MainObject.BusinessRuleCollections.Add(nonForeignKeyRule);
                            }
                        }
                    }
                }
            }
            dsColumns.Dispose();
        }

        public bool IsValidForeignKeyProperty(String strForeignKeyColumn)
        {
            try
            {
                VinaDbUtil dbUtil = new VinaDbUtil();
                //String strMainObjectTableName = MainObject.GetType().Name.Substring(0, MainObject.GetType().Name.Length - 4);
                String strMainObjectTableName = VinaUtil.GetTableNameFromBusinessObject(MainObject);
                String strPrimaryTable = ((IBaseModuleERP)Module).GetTreePrimaryTableWhichForeignColumnReferenceTo(strMainObjectTableName, strForeignKeyColumn);
                String strPrimaryColumn = ((IBaseModuleERP)Module).GetTreePrimaryTableWhichForeignColumnReferenceTo(strMainObjectTableName, strForeignKeyColumn);
                BaseBusinessController objPrimaryTableObjectController = BusinessControllerFactory.GetBusinessController(strPrimaryTable + "Controller");
                int iForeignKeyColumnValue = Convert.ToInt32(dbUtil.GetPropertyValue(MainObject, strForeignKeyColumn));
                if (iForeignKeyColumnValue > 0)
                    return objPrimaryTableObjectController.IsExist(iForeignKeyColumnValue);
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool IsValidNonForeignKeyPropety(String strNonForeignKeyColumn)
        {
            try
            {
                VinaDbUtil dbUtil = new VinaDbUtil();
                PropertyInfo property = MainObject.GetType().GetProperty(strNonForeignKeyColumn);
                if (property.PropertyType.Equals(typeof(int)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    int iConvert = Convert.ToInt32(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(double)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    double dbConvert = Convert.ToDouble(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(decimal)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    decimal dcConvert = Convert.ToDecimal(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(short)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    short sConvert = Convert.ToInt16(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(bool)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    bool bConvert = Convert.ToBoolean(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(DateTime)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    DateTime dtConvert = Convert.ToDateTime(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(string)) || property.PropertyType.Equals(typeof(String)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    String strConvert = Convert.ToString(objPropertyValue);
                    if (!String.IsNullOrEmpty(strConvert))
                        return true;
                    else
                        return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
