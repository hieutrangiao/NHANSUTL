using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VinaLib
{
    public class VinaUtil
    {
       private static SortedList<string, IEnumerable> _configValueUtility { get; set; }

        public const String cstDummyTable = "CSDummy";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objInfo"></param>
        /// <returns></returns>
        public static String GetTableNameFromBusinessObject(BusinessObject objInfo)
        {
            if (objInfo != null)
            {
                if (String.IsNullOrEmpty(objInfo.TableName) == false)
                    return objInfo.TableName;

                String strBusinessObjectName = objInfo.GetType().Name;
                String strTableName = strBusinessObjectName.Substring(0, strBusinessObjectName.Length - 4);
                return strTableName;
            }
            else
                return cstDummyTable;
        }

        public static SortedList<string, IEnumerable> ADConfigValueUtility
        {
            get{ return _configValueUtility ?? ( _configValueUtility = GetAllADConfigValueFromDataBase()); }
        }

        private static SortedList<string, IEnumerable> GetAllADConfigValueFromDataBase()
        {
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            DataSet ds = objConfigValuesController.GetAllObjects();
            List<ADConfigValuesInfo> configValueList = new List<ADConfigValuesInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ADConfigValuesInfo objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectFromDataRow(row);
                    configValueList.Add(objConfigValuesInfo);
                }
            }
            SortedList<string, IEnumerable> result = new SortedList<string, IEnumerable>();
            if(configValueList.Count() == 0)
                return result;

            var group = configValueList.GroupBy(o => o.ADConfigKeyGroup).OrderBy(o => o.Key);
            foreach (var item in group)
            {
                result.Add(item.Key, group.SelectMany(o => o.Where(o1=>o1.ADConfigKeyGroup == item.Key).OrderBy(o1=>o1.ADConfigKeySortOrder)));
            }
            return result;
        }

        public static String GetTableNameFromBusinessObjectType(Type tpBusinessObject)
        {
            String strBusinessObjectName = tpBusinessObject.Name;
            String strTableName = strBusinessObjectName.Substring(0, strBusinessObjectName.Length - 4);
            return strTableName;
        }

        public static string GetFullTypeName(string strTypeName)
        {
            string str = strTypeName;
            switch (strTypeName)
            {
                case "Int32":
                    str = "System." + strTypeName;
                    break;
            }
            return str;
        }

        public static string GetBusinessControllerNameFromBusinessObject(BusinessObject objInfo)
        {
            return VinaUtil.GetTableNameFromBusinessObject(objInfo) + "Controller";
        }

        public static string EncryptMD5Hash(string strInput)
        {
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();

            StringBuilder strOutput = new StringBuilder();

            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(strInput));

            for (int i = 0; i < bytes.Length; i++)
            {
                strOutput.Append(bytes[i].ToString("x2"));
            }

            return strOutput.ToString();
        }
    }
}
