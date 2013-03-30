using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;

namespace MiBo.Domain.Dao
{
    public class ClientCheckoutDao : AbstractDao
    {
        public void  makeCheckout(Accept accept, IList<CartItem> cart)
        {

            UserCom userCom = new UserCom();
            accept.AcceptSlipNo = MNumberCom.GetSlipNo(Logics.CD_BUSINESS_ACCEPT);

            int i = 0;
            while (IsExist<Accept>(accept.AcceptSlipNo, false))
	        {
                Thread.Sleep(5000);
                accept.AcceptSlipNo = MNumberCom.GetSlipNo(Logics.CD_BUSINESS_ACCEPT);
                if (i == 10) throw new ExecuteException("E_MSG_00014");
                i++;
	        } 

            accept.DeliveryCd = DataHelper.GetUniqueKey();
            accept.ViewId = MNumberCom.GenViewId(accept.AcceptSlipNo, Logics.CD_BUSINESS_ACCEPT);
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

        public AcceptModel GetAccept(string acceptSlipNo)
        {
            var result = from tbl in EntityManager.Accepts
                         where tbl.AcceptSlipNo == acceptSlipNo
                         && tbl.DeleteFlag == false
                         select tbl;

            var acceptModel = new AcceptModel();

            DataHelper.CopyObject(result.SingleOrDefault(), acceptModel);
            acceptModel.TotalAmount = acceptModel.AcceptDetails.Where(o => o.DeleteFlag == false).Sum(o => o.DetailAmt);

            return acceptModel;
        }
    }
}