using DevExpress.XtraBars;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant.IC;
using VinaERP.Utilities;
using VinaLib;

namespace VinaERP
{
    public class VinaApp
    {
        public static string CurrentModuleName = string.Empty;

        public static Assembly VinaAssembly { get; set; }

        public static GUIMain MainScreen { get; set; }

        public static ADUsersInfo CurrentUserInfo { get; set; }

        public static string CurrentUserName { get; set; }

        public static SortedList OpenModules = new SortedList();

        public static SortedList LookupTables { get; set; }

        public static SortedList<string, GELookupTablesInfo> LookupTableObjects { get; set; }

        public static ImageList ToolbarImageList = new ImageList();

        public static List<GECurrenciesInfo> CurrencyList { get; set; }

        public static void InitMainFormTitle()
        {
            MainScreen.Text = "VinaERP - Licensed to " + "Me";
            MainScreen.Text += " - " + DateTime.Now.ToShortDateString();
            MainScreen.Text += " - " + CurrentUserName;
        }

        public static BaseModuleERP ShowModule(String strModuleName)
        {
            BaseModuleERP currModule = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (VinaApp.IsOpenedModule(strModuleName))
                {
                    ShowOpenedModule(strModuleName);
                }
                else
                {
                    currModule = VinaModuleFactory.GetModule(strModuleName);
                    if (currModule != null)
                        ShowNewModule(currModule);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                return null;
            }
            return currModule;
        }

        public static bool IsOpenedModule(String strModuleName)
        {
            return OpenModules.ContainsKey(strModuleName);
        }

        public static void ShowOpenedModule(String strModuleName)
        {
            ToolStripButton tsbtnModule = (ToolStripButton)VinaApp.MainScreen.OpenModulesToolStrip.Items[strModuleName];
            CheckOpenModuleToolStripButton(tsbtnModule);
            BaseModuleERP module = (BaseModuleERP)VinaApp.OpenModules[strModuleName];
            module.ParentScreen.Activate();
            module.ParentScreen.Focus();
        }

        public static void CheckOpenModuleToolStripButton(ToolStripButton tsbtnModule)
        {
            tsbtnModule.Checked = true;
            foreach (ToolStripButton tsbtnOpenedModule in VinaApp.MainScreen.OpenModulesToolStrip.Items)
            {
                if (tsbtnOpenedModule.Name != tsbtnModule.Name)
                    tsbtnOpenedModule.Checked = false;
            }
        }

        public static void RemoveOpenedModule(BaseModuleERP module)
        {
            if (IsOpenedModule(module.CurrentModuleName))
            {
                ((BaseModuleERP)OpenModules[module.CurrentModuleName]).Close();
                OpenModules.Remove(module.CurrentModuleName);
            }
        }

        public static void RemoveOpenedModule(String strModuleName)
        {
            if (IsOpenedModule(strModuleName))
            {
                OpenModules.Remove(strModuleName);
            }
        }

        public static void ShowNewModule(BaseModuleERP module)
        {
            VinaApp.UpdateOpenedModule(module);
            AddOpenModuleToOpenModulesToolStrip(module.CurrentModuleName);
            module.Show();
        }

        public static void AddOpenModuleToOpenModulesToolStrip(String strModuleName)
        {
            ToolStripButton tsbtnModule = PopulateOpenModulesToolStripButton(strModuleName);
            VinaApp.MainScreen.OpenModulesToolStrip.Items.Add(tsbtnModule);
            tsbtnModule.Visible = true;
            CheckOpenModuleToolStripButton(tsbtnModule);
        }

        private static ToolStripButton PopulateOpenModulesToolStripButton(String strModuleName)
        {
            String strModuleDesc = ((STModulesInfo)(new STModulesController().GetObjectByName(strModuleName))).STModuleDesc;
            if (String.IsNullOrEmpty(strModuleDesc))
                strModuleDesc = strModuleName;
            ToolStripButton tsbtnOpenModules = new ToolStripButton(strModuleDesc, null, OpenModulesToolStrip_Click, strModuleName);

            //ToolStripButton tsbtnOpenModules = new ToolStripButton(strModuleDesc, VinaApp.SectionImageList.Images[strModuleName], OpenModulesToolStrip_Click, strModuleName);
            tsbtnOpenModules.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbtnOpenModules.CheckOnClick = true;
            return tsbtnOpenModules;
        }

        private static void OpenModulesToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtnModule = (ToolStripButton)sender;
            CheckOpenModuleToolStripButton(tsbtnModule);
            ShowModule(tsbtnModule.Name);
        }

        public static void UpdateOpenedModule(BaseModuleERP module)
        {
            if (!IsOpenedModule(module.CurrentModuleName))
            {
                OpenModules.Add(module.CurrentModuleName, module);
            }
            else
                OpenModules[module.CurrentModuleName] = module;
        }

        public static void InitApplication()
        {
            GUIMain guiMain = new GUIMain();
            guiMain.ShowDialog();
        }

        public static bool IsAuthenticated(string username, string password, out string strMessage)
        {
            strMessage = string.Empty;
            ADUsersController adUsersController = new ADUsersController();
            ADUsersInfo objUsersInfo = (ADUsersInfo)adUsersController.GetObjectByName(username);
            if (objUsersInfo == null)
                return false;

            if (!objUsersInfo.ADUserActiveCheck)
            {
                strMessage = "Tài khoản của bạn đã bị khóa. Vui lòng thử lại sau!";
                return false;
            }

            if (!objUsersInfo.ADPassword.Equals(VinaUtil.EncryptMD5Hash(password)))
            {
                strMessage = "Tài khoản hoặc mật khẩu không chính xác. Vui lòng thử lại!";
                return false;
            }
            VinaApp.CurrentUserName = objUsersInfo.ADUserName;
            VinaApp.CurrentUserInfo = objUsersInfo;
            return true;
        }

        public static void SetCurrentUserLogin(string username)
        {
            //TODO
        }

        public static void LogOn()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            ADUsersInfo objUsersInfo = VinaApp.CurrentUserInfo;
            if (VinaApp.CurrentUserInfo != null)
                VinaApp.SetApplicationStyle(CurrentUserInfo.ADUserStyle, CurrentUserInfo.ADUserStyleSkin);

            InitToolbarImageList();

            InitMainFormTitle();

            InitLookupTables();

            InitMenuOfMainForm();

            InitCurrencyList();
        }

        public static void InitCurrencyList()
        {
            CurrencyList = VinaApp.CurrencyList ?? ApiClientHelper.GetExchangeRate();
        }

        public static void LogOutAndClearSection()
        {
            CloseAllOpenModules();
            VinaApp.OpenModules.Clear();
            VinaApp.MainScreen.OpenModulesToolStrip.Items.Clear();
            VinaApp.MainScreen.OpenModulesToolStrip.Enabled = true;
        }

        public static void CloseAllOpenModules()
        {
            for (int i = 0; i < VinaApp.OpenModules.Count; i++)
            {
                BaseModuleERP module = (BaseModuleERP)VinaApp.OpenModules.GetByIndex(i);
                module.ParentScreen.Close();
                i--;
            }
        }

        public static void SetApplicationStyle(String strLookAndFeelStyle, String strLookAndFeelStyleSkin)
        {
            DevExpress.LookAndFeel.LookAndFeelStyle style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            try
            {
                style = (DevExpress.LookAndFeel.LookAndFeelStyle)Enum.Parse(typeof(DevExpress.LookAndFeel.LookAndFeelStyle), strLookAndFeelStyle);

            }
            catch (System.Exception)
            {

            }
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetStyle(style, false, true);
            if (!String.IsNullOrEmpty(strLookAndFeelStyleSkin))
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(strLookAndFeelStyleSkin);
            else
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Black");
        }

        public static void SaveUserStyle(String strLookAndFeelStyle, String strLookAndFeelStyleSkin)
        {
            if (VinaApp.CurrentUserInfo != null)
            {
                ADUsersController objUsersController = new ADUsersController();
                VinaApp.CurrentUserInfo.ADUserStyle = strLookAndFeelStyle;
                VinaApp.CurrentUserInfo.ADUserStyleSkin = strLookAndFeelStyleSkin;
                objUsersController.UpdateObject(VinaApp.CurrentUserInfo);
            }
        }

        public static void InitMenuOfMainForm()
        {
            //for (int i = 2; i < VinaApp.MainScreen.MainMenu.ItemLinks.Count - 2; i++)
            //{
            //    VinaApp.MainScreen.MainMenu.ItemLinks.RemoveAt(i);
            //    i--;
            //}

            STModulesController moduleController = new STModulesController();
            List<STModulesInfo> modules = moduleController.GetAllModulesByUserName(VinaApp.CurrentUserName);

            if (modules.Count() == 0)
                return;
            Dictionary<string, List<STModulesInfo>> dictionary = new Dictionary<string, List<STModulesInfo>>();
            string key;
            foreach (STModulesInfo module in modules)
            {
                key = module.ADUserGroupSectionID + "&&" + module.ADUserGroupSectionName;
                if (!dictionary.ContainsKey(key))
                    dictionary.Add(key, new List<STModulesInfo>());
                dictionary[key].Add(module);
            }

            int imdex = 0;
            foreach (string groupSection in dictionary.Keys)
            {
                if (dictionary[groupSection] != null && dictionary[groupSection].Count != 0)
                {
                    STModulesInfo firstItem = dictionary[groupSection][0];

                    DevExpress.XtraBars.BarSubItem item = new DevExpress.XtraBars.BarSubItem();
                    item.Caption = firstItem.ADUserGroupSectionName;
                    VinaApp.MainScreen.MainMenu.InsertItem(VinaApp.MainScreen.MainMenu.ItemLinks[2 + imdex], item);
                    item = AddSubMenuToMenuItem(item, dictionary[groupSection]);
                    imdex++;
                }
            }
        }

        public static DevExpress.XtraBars.BarSubItem AddSubMenuToMenuItem(DevExpress.XtraBars.BarSubItem menuItem, List<STModulesInfo> modules)
        {
            if (modules != null)
            {
                foreach (STModulesInfo module in modules)
                {
                    DevExpress.XtraBars.BarButtonItem subItem = new DevExpress.XtraBars.BarButtonItem();
                    subItem.Caption = module.STModuleDesc;
                    subItem.Tag = module.STModuleName;
                    subItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BarButtonItem_ItemClick);
                    menuItem.AddItem(subItem);
                }
            }
            return menuItem;
        }

        protected static void BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem subMenu = e.Item as BarButtonItem;
            if (subMenu == null || (subMenu != null && subMenu.Tag == null))
                return;
            VinaApp.ShowModule(subMenu.Tag.ToString());
        }

        public static DataSet GetLookupTableData(string lookupTableName)
        {
            BaseBusinessController objBusinessController = BusinessControllerFactory.GetBusinessController(lookupTableName + "Controller");
            DataSet ds = new DataSet();
            if (objBusinessController != null)
            {
                switch (lookupTableName)
                {
                    case "ICStocks":
                        {
                            ICStocksController objStocksController = new ICStocksController();
                            ds = objStocksController.GetStockByStockType(StockType.Sale); ;
                            break;
                        }
                    default:
                        {
                            ds = objBusinessController.GetAllObjects();
                            break;
                        }
                }
            }
            return ds;
        }

        public static void InitLookupTables()
        {
            LookupTables = new SortedList();
            LookupTableObjects = new SortedList<string, GELookupTablesInfo>();
        }

        public static void InitToolbarImageList()
        {
            try
            {
                VinaApp.ToolbarImageList.Images.Clear();
                VinaApp.ToolbarImageList.ImageSize = new System.Drawing.Size(16, 16);
                foreach (FileInfo file in new DirectoryInfo(Application.StartupPath + "\\Images\\Toolbar").GetFiles())
                {
                    if (file.Extension.ToLower() == ".ico" || file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".bmp")
                    {
                        int length = file.Name.IndexOf(".");
                        if (length > 0)
                        {
                            string key = file.Name.Substring(0, length);
                            System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName);
                            VinaApp.ToolbarImageList.Images.Add(key, image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void RoundByCurrency(BusinessObject obj, int currencyID)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();

            GECurrenciesController currencyController = new GECurrenciesController();
            GECurrenciesInfo currency = currencyController.GetObjectByID(currencyID) as GECurrenciesInfo;
        }

        public static void RoundByCurrency(BusinessObject obj, string columnName, int currencyID)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();

            GECurrenciesController currencyController = new GECurrenciesController();
            GECurrenciesInfo currency = currencyController.GetObjectByID(currencyID) as GECurrenciesInfo;

            if (currency != null && obj != null)
            {
                object value = dbUtil.GetPropertyValue(obj, columnName);
                decimal amount = 0;
                if (value != null)
                {
                    amount = Convert.ToDecimal(value);
                    amount = Math.Round(amount, currency.GECurrencyDecimalNumber);
                    dbUtil.SetPropertyValue(obj, columnName, amount);
                }

            }
        }

        public static string ConvertUnicodeStringToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
