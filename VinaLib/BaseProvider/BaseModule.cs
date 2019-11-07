using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaLib
{
    public class BaseModule
    {
        public string CurrentModuleName { get; set; }

        public int CurrentModuleID { get; set; }

        public List<VinaScreen> Screens { get; set; }

        public SortedList<string, System.Windows.Forms.Control> Controls;

        public BaseToolbar Toolbar { get; set; }


        //protected string _code = string.Empty;
        //public const string cstHomeModule = "Home";
        //public const string cstCustomerModule = "Customer";
        //public const string cstSupplierModule = "Supplier";
        //public const string cstProductModule = "Product";
        //public const string cstAccountModule = "Account";
        //public const string cstStockModule = "Stock";
        //public const string cstPriceListModule = "PriceList";
        //public const string cstTemplateModule = "Template";
        //public const string cstSellerModule = "Seller";
        //public const string cstUserManagementModule = "UserManagement";
        //public const string cstBOSActivationModule = "BOSActivation";
        //public const string cstMatchCodeModule = "MatchCode";
        //public const string cstNumberingModule = "Numbering";
        //public const string cstReportModule = "Report";
        //public const string cstDataMainScreen = "DM";
        //public const string cstSearchMainScreen = "SM";
        //public const string cstSearchResultsScreen = "SR";
        //public const string cstDataSubScreen = "DS";
        //public const string cstModuleStatusOpen = "Open";
        //public const string cstModuleStatusHibernate = "Hibernate";
        //public const string cstModuleStatusClose = "Close";
        //public const string cstModuleStatusHide = "Hide";
        //public const string cstModusNormal = "Normal";
        //public const string cstModusSearch = "Search";
        //public const string cstUserAuditNothing = "Nothing";
        //public const string cstUserAuditNew = "Create";
        //public const string cstUserAuditEdit = "Edit";
        //public const string cstObjectHistoryActionNew = "Create";
        //public const string cstObjectHistoryActionChange = "Change";
        //public const string cstObjectHistoryActionDelete = "Delete";
        //protected BOSScreen _activateScreen;

        //public WaitDialogForm WaitDialog;

        //public string Code
        //{
        //    get
        //    {
        //        return this._code;
        //    }
        //    set
        //    {
        //        this._code = value;
        //    }
        //}

        //public BOSScreen ActiveScreen
        //{
        //    get
        //    {
        //        return this._activateScreen;
        //    }
        //    set
        //    {
        //        this._activateScreen = value;
        //        this._activateScreen.Activate();
        //    }
        //}

        //public List<STFieldFormatGroupsInfo> FormatGroups { get; set; }

        public BaseModule()
        {
            this.Toolbar = new BaseToolbar();
            this.Screens = new List<VinaScreen>();
            this.Controls = new SortedList<string, Control>();
            //this.FormatGroups = new List<STFieldFormatGroupsInfo>();
        }

        //public Control GetControlByName(string strControlName)
        //{
        //    if (this.Controls[strControlName] != null)
        //        return this.Controls[strControlName];
        //    return (Control)null;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        public bool Contains(string strControlName)
        {
            Control control = new Control();
            return this.Controls.TryGetValue(strControlName, out control); //this.Controls[strControlName] != null;
        }

        //protected void ShowAllMainScreens()
        //{
        //    for (int index = 0; index < this.Screens.Count; ++index)
        //    {
        //        BOSScreen screen = this.Screens[index];
        //        string screenNumber = this.Screens[index].ScreenNumber;
        //        if (screenNumber.StartsWith("DM") || screenNumber.StartsWith("SM") || screenNumber.StartsWith("SR"))
        //            this.ShowScreen(screen, true);
        //    }
        //}

        //public virtual void ShowScreen(BOSScreen scr, bool bIsChild)
        //{
        //}

        //public virtual BOSScreen GetScreenByScreenNumber(string strScreenNumber)
        //{
        //    for (int index = 0; index < this.Screens.Count; ++index)
        //    {
        //        if (this.Screens[index].ScreenNumber == strScreenNumber)
        //            return this.Screens[index];
        //    }
        //    return (BOSScreen)null;
        //}

        //public MethodInfo GetMethodInfoByMethodNameAndParametersType(string strMethodName, System.Type[] parametersType)
        //{
        //    return this.GetType().GetMethod(strMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder)null, parametersType, (ParameterModifier[])null);
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMethodFullName"></param>
        /// <returns></returns>
        public System.Type[] GetParameterTypeArrayFromMethodFullName(string strMethodFullName)
        {
            string str = strMethodFullName.Substring(strMethodFullName.IndexOf("("));
            System.Type[] array = new System.Type[0];
            for (int index = str.IndexOf(","); index > 0; index = str.IndexOf(","))
            {
                Array.Resize<System.Type>(ref array, array.Length + 1);
                array.SetValue((object)System.Type.GetType(str.Substring(1, index - 1)), array.Length - 1);
                str = str.Substring(index + 1);
            }
            int num = str.IndexOf(")");
            if (num > 0 && !string.IsNullOrEmpty(str.Substring(1, num - 1)))
            {
                Array.Resize<System.Type>(ref array, array.Length + 1);
                array.SetValue((object)this.GetType(VinaUtil.GetFullTypeName(str.Substring(1, num - 1))), array.Length - 1);
            }
            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetAssemblyName()
        {
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strClassName"></param>
        /// <returns></returns>
        public virtual System.Type GetClassType(string strClassName)
        {
            return (System.Type)null;
        }

        #region "Handler Toolbar Function"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strMethodName"></param>
        /// <param name="strMethodFullName"></param>
        /// <param name="strMethodClass"></param>
        /// <returns></returns>
        public MethodInfo GetMethodInfoByMethodFullNameAndMethodClass(string strMethodName, string strMethodFullName, string strMethodClass)
        {
            try
            {
                if (string.IsNullOrEmpty(this.GetAssemblyName()))
                    return (MethodInfo)null;
                return this.GetClassType(strMethodClass)?.GetMethod(strMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder)null, this.GetParameterTypeArrayFromMethodFullName(strMethodFullName), (ParameterModifier[])null);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(this.GetType().Name + ".GetMethodByMethodFullNameAndMethodClass:" + ex.Message);
                return (MethodInfo)null;
            }
        }

        #endregion

        //public virtual string GetAssemblyName()
        //{
        //    return string.Empty;
        //}

        //public virtual System.Type GetClassType(string strClassName)
        //{
        //    return (System.Type)null;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFullTypeName"></param>
        /// <returns></returns>
        protected System.Type GetType(string strFullTypeName)
        {
            if (System.Type.GetType(strFullTypeName) != null)
                return System.Type.GetType(strFullTypeName);
            if (strFullTypeName == "DevExpress.XtraBars.ItemClickEventArgs")
                return typeof(ItemClickEventArgs);
            return Assembly.LoadFile("C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727\\" + strFullTypeName.Substring(0, strFullTypeName.LastIndexOf(".")) + ".dll").GetType(strFullTypeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public object[] GetMethodParameterValues(ParameterInfo[] parameters, params object[] parameterValue)
        {
            TypeConverter typeConverter = new TypeConverter();
            object[] objArray = new object[parameters.Length];
            for (int index = 0; index < parameters.Length; ++index)
                objArray[index] = parameterValue[index];
            return objArray;
        }


        //public virtual STFieldFormatGroupsInfo GetColumnFormat(string tableName, string columnName)
        //{
        //    STFieldFormatGroupsController groupsController = new STFieldFormatGroupsController();
        //    STFieldFormatGroupsInfo formatGroupsInfo = this.FormatGroups.Where<STFieldFormatGroupsInfo>((Func<STFieldFormatGroupsInfo, bool>)(fg =>
        //    {
        //        if (fg.TableName == tableName)
        //            return fg.ColumnName == columnName;
        //        return false;
        //    })).FirstOrDefault<STFieldFormatGroupsInfo>();
        //    if (formatGroupsInfo == null)
        //    {
        //        FormatGroupAttribute formatGroupAttribute = (FormatGroupAttribute)null;
        //        BusinessObject businessObject = BusinessObjectFactory.GetBusinessObject(tableName + "Info");
        //        if (businessObject != null)
        //        {
        //            PropertyInfo property = businessObject.GetType().GetProperty(columnName);
        //            if (property != null)
        //            {
        //                object[] customAttributes = property.GetCustomAttributes(typeof(FormatGroupAttribute), true);
        //                if (customAttributes.Length > 0)
        //                    formatGroupAttribute = (FormatGroupAttribute)customAttributes[0];
        //            }
        //        }
        //        if (formatGroupAttribute != null)
        //            formatGroupsInfo = (STFieldFormatGroupsInfo)groupsController.GetObjectByName(formatGroupAttribute.FormatGroup);
        //        if (formatGroupsInfo == null)
        //            formatGroupsInfo = groupsController.GetFieldFormatGroupByTableNameAndColumnName(tableName, columnName);
        //    }
        //    return formatGroupsInfo;
        //}
    }
}
