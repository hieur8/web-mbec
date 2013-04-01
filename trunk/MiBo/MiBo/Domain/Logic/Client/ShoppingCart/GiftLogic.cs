using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Client.ShoppingCart;
using MiBo.Domain.Web.Client.ShoppingCart;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class GiftLogic
    {
        #region Invoke Method
        /// <summary>
        /// Gift process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public GiftResponseModel Invoke(GiftRequestModel request)
        {
            var responseModel = Execute(request);
            return responseModel;
        }
        #endregion

        #region Private Method


   

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private GiftResponseModel Execute(GiftRequestModel request)
        {
            // Local variable declaration
            GiftResponseModel responseModel = null;
            ClientShoppingCartDao shoppingCartDao = new ClientShoppingCartDao();

            // Variable initialize
            responseModel = new GiftResponseModel();

            GiftCard card = shoppingCartDao.getSingleGift(request.GiftCd);
            if (card != null)
            {
                responseModel.IsExit = true;
                responseModel.GiftCd = card.GiftCd;
                responseModel.Price = decimal.Parse(card.Price);
            }
            else
            {
                responseModel.IsExit = false;
            }
            return responseModel;
        }

      
        #endregion
    }
}