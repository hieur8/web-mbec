using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Exceptions;

namespace MiBo.Domain.Dao
{
    public class ClientCheckoutDao : AbstractDao
    {
        public void makeCheckout(Accept accept, IList<CartItem> cart)
        {
           
            accept.AcceptSlipNo = MNumberCom.GetSlipNo(Logics.CD_BUSINESS_ACCEPT);
            accept.DeliveryCd = DataHelper.GetUniqueKey();
            accept.ViewId = DataHelper.GetUniqueKey();
            EntityManager.Accepts.InsertOnSubmit(accept);
            int countNo = 1;
            foreach (CartItem item in cart)
            {           
                AcceptDetail detail = new AcceptDetail();
                detail.AcceptSlipNo = accept.AcceptSlipNo;
                detail.DetailNo = countNo++;
                detail.ItemCd = item.ItemCd;
                var itemResult = GetSingle<Item>(item.ItemCd, false);
                if (itemResult == null)
                {
                    throw new DataNotExistException("Mã sản phẩm");
                }
                detail.ItemName = itemResult.ItemName;
                detail.UnitCd = itemResult.UnitCd;
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

            var number  = MNumberCom.ToMNumber(accept.AcceptSlipNo);
            EntityManager.MNumbers.InsertOnSubmit(number);

            EntityManager.SubmitChanges();
        }
    }
}