using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public String makeCheckout(Accept accept, IList<CartItem> cart)
        {
            ItemCom itemCom = new ItemCom();
            decimal priceGift = 0;
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
                if (!itemCom.HasOffer(item.ItemCd))
                {
                    priceGift = priceGift + itemResult.SalesPrice.Value * item.Quantity;
                }
            }

            if (priceGift != 0 && priceGift > 100000)
            {
                GiftCard gift = new GiftCard();
                gift.GiftCd = RandomString(10, true);
                gift.Price = priceGift * 10 / 100;
                gift.CreateDate = accept.CreateDate;
                gift.UpdateUser = accept.UpdateUser;
                gift.UpdateDate = accept.UpdateDate;
                gift.DeleteFlag = false;
                gift.GiftStatus = Logics.CD_GIFT_STATUS_INACTIVE;
                EntityManager.GiftCards.InsertOnSubmit(gift);
                accept.GiftCd = gift.GiftCd;
            }
            if (accept.UseGiftCd != null)
            {
                if (IsExist<GiftCard>(accept.UseGiftCd, false))
                {
                    GiftCard useGift = GetSingle<GiftCard>(accept.UseGiftCd, false);
                    useGift.GiftStatus = Logics.CD_GIFT_STATUS_USED;
                }
            }
            var number  = MNumberCom.ToMNumber(accept.AcceptSlipNo);
            EntityManager.MNumbers.InsertOnSubmit(number);
            EntityManager.Accepts.InsertOnSubmit(accept);

            EntityManager.SubmitChanges();
            return accept.AcceptSlipNo;
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

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();

        }

        public void updateStatus(String acceptSlipNo, string status)
        {
            Accept result = GetSingle<Accept>(acceptSlipNo, false);
            if (result != null)
            {
                result.SlipStatus = status;
                EntityManager.SubmitChanges();
            }
           
        }

        public Accept getAcceptById(string slipNo)
        {
            return GetSingle<Accept>(slipNo, false);
        }

        public void updateGenId(String acceptSlipNo, string genId)
        {
            Accept result = GetSingle<Accept>(acceptSlipNo, false);
            if (result != null)
            {
                result.GenId = genId;
                EntityManager.SubmitChanges();
            }
        }
    }
}