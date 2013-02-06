using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.ItemDetails;
using MiBo.Domain.Web.Client.ItemDetails;
using Resources;

namespace MiBo.Domain.Logic.Client.ItemDetails
{
    public class BuyLogic
    {
        #region Invoke Method
        /// <summary>
        /// Buy process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public BuyResponseModel Invoke(BuyRequestModel request)
        {
            var response = Execute(request);
            return response;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Execute convert input.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>DataModel</returns>
        private BuyDataModel Convert(BuyRequestModel request)
        {
            // Local variable declaration
            BuyDataModel inputObject = null;

            // Variable initialize
            inputObject = new BuyDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);
            // Convert cart
            inputObject.Cart = DataHelper.ConvertInputCart(request.Cart);

            // Return value
            return inputObject;
        }

        /// <summary>
        /// Execute convert output.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private BuyResponseModel Convert(BuyDataModel resultObject)
        {
            // Local variable declaration
            BuyResponseModel responseModel = null;

            // Variable initialize
            responseModel = new BuyResponseModel();

            // Set value
            responseModel.Cart = resultObject.Cart;

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private BuyResponseModel Execute(BuyRequestModel request)
        {
            // Local variable declaration
            BuyResponseModel responseModel = null;
            BuyDataModel inputObject = null;
            BuyDataModel resultObject = null;

            // Variable initialize
            responseModel = new BuyResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check infomation
            Check(inputObject);

            // Get infomation
            resultObject = AddInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>ResultModel</returns>
        private void Check(BuyDataModel inputObject)
        {
            // Local variable declaration
            ClientItemDetailsDao clientItemDetailsDao = null;
            CartCom cartCom = null;

            // Variable initialize
            clientItemDetailsDao = new ClientItemDetailsDao();
            cartCom = new CartCom(inputObject.Cart);

            // Check exist
            foreach (var item in cartCom.Items)
            {
                if (!clientItemDetailsDao.IsExistItem(item.ItemCd))
                    throw new DataNotExistException(Parameters.P_ITEM_DETAILS_00001);
            }
        }

        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private BuyDataModel AddInfo(BuyDataModel inputObject)
        {
            // Local variable declaration
            BuyDataModel getResult = null;
            CartCom cartCom = null;

            // Variable initialize
            getResult = new BuyDataModel();
            cartCom = new CartCom(inputObject.Cart);

            // Get data
            var cartItem = new CartItem();
            cartItem.ItemCd = inputObject.ItemCd;
            cartItem.Quantity = inputObject.ItemQtty.Value;
            cartCom.AddItem(cartItem);

            // Set value
            getResult.Cart = cartCom.Items;

            // Return value
            return getResult;
        }
        #endregion
    }
}