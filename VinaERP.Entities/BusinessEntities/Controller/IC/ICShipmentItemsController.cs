﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region ICShipmentItems
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICShipmentItemsController
    //Created Date:Saturday, December 1, 2018
    //-----------------------------------------------------------

    public class ICShipmentItemsController : BaseBusinessController
    {
        public ICShipmentItemsController()
        {
            dal = new DALBaseProvider("ICShipmentItems", typeof(ICShipmentItemsInfo));
        }

        public List<ICShipmentItemsInfo> GetShipmentItemForInvoice()
        {
            DataSet ds = dal.GetDataSet("ICShipmentItems_GetShipmentItemForInvoice");
            return (List<ICShipmentItemsInfo>)GetListFromDataSet(ds);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<ICShipmentItemsInfo> shipmentItems = new List<ICShipmentItemsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICShipmentItemsInfo objShipmentItemsInfo = (ICShipmentItemsInfo)GetObjectFromDataRow(row);
                    shipmentItems.Add(objShipmentItemsInfo);
                }
            }
            return shipmentItems;
        }

        public List<ICShipmentItemsInfo> GetShipmentItemForReport(int shipmentID)
        {
            DataSet ds = dal.GetDataSet("ICShipmentItems_GetShipmentItemForReport", shipmentID);
            return (List<ICShipmentItemsInfo>)GetListFromDataSet(ds);
        }
    }
    #endregion
}