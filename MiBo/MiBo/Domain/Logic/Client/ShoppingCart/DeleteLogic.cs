using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Client.ShoppingCart;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class DeleteLogic
    {
        #region Invoke Method
        /// <summary>
        /// Delete process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public DeleteResponseModel Invoke(DeleteRequestModel request)
        {
            var responseModel = Execute(request);
            return responseModel;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Execute convert input.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>DataModel</returns>
        private DeleteDataModel Convert(DeleteRequestModel request)
        {
            // Local variable declaration
            DeleteDataModel inputObject = null;

            // Variable initialize
            inputObject = new DeleteDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);
            // Convert cart
            inputObject.Cart = DataHelper.ConvertInputCart(request.Cart);

            // Return value
            return inputObject;
        }

        /// <summary>
        /// Execute convert ouput.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private DeleteResponseModel Convert(DeleteDataModel resultObject)
        {
            // Local variable declaration
            DeleteResponseModel responseModel = null;

            // Variable initialize
            responseModel = new DeleteResponseModel();

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
        private DeleteResponseModel Execute(DeleteRequestModel request)
        {
            // Local variable declaration
            DeleteResponseModel responseModel = null;
            DeleteDataModel inputObject = null;
            DeleteDataModel resultObject = null;

            // Variable initialize
            responseModel = new DeleteResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Get infomation
            resultObject = DeleteInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Delete infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private DeleteDataModel DeleteInfo(DeleteDataModel inputObject)
        {
            // Local variable declaration
            DeleteDataModel getResult = null;
            CartCom cartCom = null;

            // Variable initialize
            getResult = new DeleteDataModel();
            cartCom = new CartCom(inputObject.Cart);

            // Delete data
            cartCom.DeleteItem(inputObject.ItemCd);

            // Set value
            getResult.Cart = cartCom.Items;

            // Return value
            return getResult;
        }
        #endregion
    }
}