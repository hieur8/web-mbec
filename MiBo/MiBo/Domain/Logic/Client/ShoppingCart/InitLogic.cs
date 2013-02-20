using System.Collections.Generic;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.ShoppingCart;
using MiBo.Domain.Web.Client.ShoppingCart;
using Resources;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class InitLogic
    {
        #region Invoke Method
        /// <summary>
        /// Initialization process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public InitResponseModel Invoke(InitRequestModel request)
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
        private InitDataModel Convert(InitRequestModel request)
        {
            // Local variable declaration
            InitDataModel inputObject = null;

            // Variable initialize
            inputObject = new InitDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);
            // Set cart
            inputObject.Cart = DataHelper.ConvertInputCart(request.Cart);

            // Return value
            return inputObject;
        }

        /// <summary>
        /// Execute convert ouput.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Convert(InitDataModel resultObject)
        {
            // Local variable declaration
            InitResponseModel responseModel = null;
            IList<OutputItemModel> listItems = null;
            OutputItemModel item = null;
            IList<OutputItemModel> listOfferItems = null;
            OutputItemModel offerItem = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listItems = new List<OutputItemModel>();
            listOfferItems = new List<OutputItemModel>();

            // Get value
            foreach (var obj in resultObject.ListItems)
            {
                item = new OutputItemModel();

                item.ItemCd = DataHelper.ToString(obj.ItemCd);
                item.ItemName = DataHelper.ToString(obj.ItemName);
                item.ItemImage = DataHelper.ToString(obj.ItemImage);
                item.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                item.Quantity = DataHelper.ToString(Formats.NUMBER, obj.Quantity);
                item.Amount = DataHelper.ToString(Formats.CURRENCY, obj.Amount);

                foreach (var sub in obj.ListOfferItems)
                {
                    offerItem = new OutputItemModel();
                    offerItem.ItemCd = DataHelper.ToString(sub.OfferItemCd);
                    offerItem.ItemName = DataHelper.ToString(sub.Item.ItemName);
                    offerItem.ItemImage = DataHelper.ToString(sub.Item.ItemImages[0].Image);
                    offerItem.Quantity = DataHelper.ToString(Formats.NUMBER, sub.OfferItemQtty * obj.Quantity);
                    listOfferItems.Add(offerItem);
                }

                listItems.Add(item);
            }

            // Set value
            responseModel.TotalAmount = DataHelper.ToString(Formats.CURRENCY, resultObject.TotalAmount);
            responseModel.ListItems = listItems;
            responseModel.ListOfferItems = listOfferItems;

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Execute(InitRequestModel request)
        {
            // Local variable declaration
            InitResponseModel responseModel = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = null;

            // Variable initialize
            responseModel = new InitResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing
            Check(inputObject);

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {
            // Local variable declaration
            ClientShoppingCartDao clientShoppingCartDao = null;
            CartCom cartCom = null;

            // Variable initialize
            clientShoppingCartDao = new ClientShoppingCartDao();
            cartCom = new CartCom(inputObject.Cart);

            // Check exist
            foreach (var item in cartCom.Items)
            {
                if (!clientShoppingCartDao.IsExistItem(item.ItemCd))
                    throw new DataNotExistException(Parameters.P_SHOPPING_CART_00001);
            }
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject)
        {
            // Local variable declaration
            InitDataModel getResult = null;
            ClientShoppingCartDao clientShoppingCartDao = null;
            ItemCom itemCom = null;
            CartCom cartCom = null;
            IList<ItemModel> listItems = null;
            ItemModel itemModel = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientShoppingCartDao = new ClientShoppingCartDao();
            itemCom = new ItemCom();
            cartCom = new CartCom(inputObject.Cart);
            listItems = new List<ItemModel>();

            // Get data
            foreach (var obj in cartCom.Items)
            {
                itemModel = itemCom.ToItemModel(clientShoppingCartDao.GetSingleItem(obj.ItemCd));
                itemModel.Quantity = obj.Quantity;
                obj.Price = itemModel.SalesPrice.Value;

                listItems.Add(itemModel);
            }

            // Set value
            getResult.ListItems = listItems;
            getResult.TotalAmount = cartCom.TotalAmount;

            // Return value
            return getResult;
        }
        #endregion
    }
}