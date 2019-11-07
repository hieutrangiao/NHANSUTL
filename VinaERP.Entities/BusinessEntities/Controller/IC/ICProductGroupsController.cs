using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP
{

    public class ICProductGroupsController : BaseBusinessController
    {
        public ICProductGroupsController()
        {
            dal = new DALBaseProvider("ICProductGroups", typeof(ICProductGroupsInfo));
        }

        public List<ICProductGroupsInfo> GetListFromDataSet(DataSet ds)
        {
            List<ICProductGroupsInfo> productGroupList = new List<ICProductGroupsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)GetObjectFromDataRow(row);
                    productGroupList.Add(objProductGroupsInfo);
                }
            }
            return productGroupList;
        }

        public List<ICProductGroupsInfo> GetProductGroupByDepartmentID(int departmentID)
        {
            DataSet ds = dal.GetAllDataByForeignColumn("FK_ICDepartmentID", departmentID);
            return GetListFromDataSet(ds);
        }
    }
}
