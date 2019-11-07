﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region ARProposalItems
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ARProposalItemsController
    //Created Date:Tuesday, May 21, 2019
    //-----------------------------------------------------------

    public class ARProposalItemsController : BaseBusinessController
    {
        public ARProposalItemsController()
        {
            dal = new DALBaseProvider("ARProposalItems", typeof(ARProposalItemsInfo));
        }
        public override IList GetListFromDataSet(DataSet ds)
        {
            List<ARProposalItemsInfo> proposalList = new List<ARProposalItemsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ARProposalItemsInfo objProposalsInfo = (ARProposalItemsInfo)GetObjectFromDataRow(row);
                    proposalList.Add(objProposalsInfo);
                }
            }
            return proposalList;
        }

        public List<ARProposalItemsInfo> GetAllItemByProopsalID(int proposalID)
        {
            DataSet ds = dal.GetDataSet("ARProposalItems_GetAllItemByProopsalID", proposalID);
            return (List<ARProposalItemsInfo>)GetListFromDataSet(ds);
        }
    }
    #endregion
}