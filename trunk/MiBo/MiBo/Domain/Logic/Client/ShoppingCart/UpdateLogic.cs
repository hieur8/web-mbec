using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Client.ShoppingCart;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class UpdateLogic
    {
        #region Invoke Method
        /// <summary>
        /// Update process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public UpdateResponseModel Invoke(UpdateRequestModel request)
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
        private UpdateDataModel Convert(UpdateRequestModel request)
        {
            // Local variable declaration
            UpdateDataModel inputObject = null;

            // Variable initialize
            inputObject = new UpdateDataModel();

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
        private UpdateResponseModel Convert(UpdateDataModel resultObject)
        {
            // Local variable declaration
            UpdateResponseModel responseModel = null;

            // Variable initialize
            responseModel = new UpdateResponseModel();

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
        private UpdateResponseModel Execute(UpdateRequestModel request)
        {
            // Local variable declaration
            UpdateResponseModel responseModel = null;
            UpdateDataModel inputObject = null;
            UpdateDataModel resultObject = null;

            // Variable initialize
            responseModel = new UpdateResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check infomation
            Check(inputObject);

            // Update infomation
            resultObject = UpdateInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>ResultModel</returns>
        private void Check(UpdateDataModel inputObject)
        {
            // Local variable declaration
            DataCom dataCom = null;
            CartCom cartCom = null;

            // Variable initialize
            dataCom = new DataCom();
            cartCom = new CartCom(inputObject.Cart);

            // Check exist
            foreach (var item in cartCom.Items)
            {
                if (!dataCom.IsExist<Item>(item.ItemCd, false))
                    throw new DataNotExistException(string.Format("Sản phẩm ({0})", item.ItemCd));
            }
        }

        /// <summary>
        /// Update item to cart
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private UpdateDataModel UpdateInfo(UpdateDataModel inputObject)
        {
            // Local variable declaration
            UpdateDataModel getResult = null;
            CartCom cartCom = null;

            // Variable initialize
            getResult = new UpdateDataModel();
            cartCom = new CartCom(inputObject.Cart);

            // Get data
            foreach (var obj in inputObject.ListItems)
            {
                var item = new CartItem();
                item.ItemCd = obj.ItemCd;
                item.Quantity = obj.Quantity.Value;
                cartCom.UpdateItem(item);
            }

            // Set value
            getResult.Cart = cartCom.Items;

            // Return value
            return getResult;
        }
        #endregion
    }
}