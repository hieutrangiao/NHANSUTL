using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP.Modules.PaymentTerm
{

    public class PaymentTermModule : BaseModuleERP
    {

        public PaymentTermModule()
        {
            CurrentModuleName = "PaymentTerm";
            CurrentModuleEntity = new PaymentTermEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            PaymentTermEntities entity = (PaymentTermEntities)CurrentModuleEntity;
            //GEPaymentTermsInfo objPaymentTermsInfo = (GEPaymentTermsInfo)CurrentModuleEntity.MainObject;
            //bool flag = true; int dumpDeposit = 0; int dumpPayment = 0; bool flagType = true;
            //int count = entity.GEPaymentTermItemList.Count;
            //foreach (GEPaymentTermItemsInfo item in entity.GEPaymentTermItemList)
            //{
            //    if (item.GEPaymentTermItemPercentPayment == 0)
            //    {
            //        flag = false;
            //        break;
            //    }
            //    if (string.IsNullOrEmpty(item.GEPaymentTermItemPaymentType))
            //    {
            //        flag = false;
            //        break;
            //    }
            //    if (string.IsNullOrEmpty(item.GEPaymentTermItemType))
            //    {
            //        flag = false;
            //        break;
            //    }
            //    //if (item.GEPaymentTermItemPaymentType == PaymentTermItemPaymentType.Deposit.ToString())
            //    //{
            //    //    dumpDeposit++;
            //    //    if(dumpDeposit >1)
            //    //    {
            //    //        flagType = false;
            //    //        break;
            //    //    }
            //    //}
            //    //if (item.GEPaymentTermItemPaymentType == PaymentTermItemPaymentType.Payment.ToString())
            //    //{
            //    //    dumpPayment++;
            //    //    if (dumpPayment > 1)
            //    //    {
            //    //        flagType = false;
            //    //        break;
            //    //    }
            //    //}
            //}
            //if (!flag)
            //{
            //    MessageBox.Show("Vui lòng chọn loại thanh toán , thời điểm thanh toán, % thanh toán, đợt thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return 0;
            //}
            //if (!flagType)
            //{
            //    MessageBox.Show(" Vui lòng chọn lại đợt thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return 0;
            //}
            //if (count == 0)
            //{

            //    MessageBox.Show(" Vui lòng cấu hình chi tiết cho điều khoản thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return 0;
            //}

            return base.ActionSave();

        }
        public void RemoveSelectedItemFromGEPaymentTermItemList()
        {
            PaymentTermEntities entity = (PaymentTermEntities)CurrentModuleEntity;
            entity.PaymentTermItemList.RemoveSelectedRowObjectFromList();
        }
    }
}
