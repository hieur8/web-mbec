using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;
using System.Collections.Generic;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Dao
{
    public class ClientCheckoutDao : AbstractDao
    {
        public void makeCheckout(Accept accept, IList<CartItem> cart)
        {
            MNumberCom com = new MNumberCom();
            accept.AcceptSlipNo = com.GetSlipNo("01");
            accept.DeliveryCd = DataHelper.GetUniqueKey();
            EntityManager.Accepts.InsertOnSubmit(accept);
            int countNo = 1;
            foreach (CartItem item in cart)
            {           
                AcceptDetail detail = new AcceptDetail();
                detail.AcceptSlipNo = accept.AcceptSlipNo;
                detail.DetailNo = countNo++;
                detail.ItemCd = item.ItemCd;
                detail.ItemName = item.ItemName;
                ItemComDao itemComDao = new ItemComDao();
                Item getItem = itemComDao.GetSingle(item.ItemCd, false);
                if (getItem != null)
                {
                    detail.UnitCd = getItem.UnitCd;
                }
                detail.DetailQtty = item.Quantity;
                detail.DetailPrice = item.Price;
                detail.DetailAmt = item.Amount;
                detail.CreateUser = accept.CreateUser;
                detail.CreateDate = accept.CreateDate;
                detail.UpdateUser = accept.UpdateUser;
                detail.UpdateDate = accept.UpdateDate;
                detail.DeleteFlag = false;
                EntityManager.AcceptDetails.InsertOnSubmit(detail);
            }
            EntityManager.SubmitChanges();
        }
    }
}