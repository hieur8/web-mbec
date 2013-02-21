using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Master;
using MiBo.Domain.Web.Client.Master;
using Resources;

namespace MiBo.Domain.Logic.Client.Master
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
            IList<OutputCategoryModel> listToys = null;
            IList<OutputCategoryModel> listAccessories = null;
            OutputCategoryModel toy = null;
            OutputCategoryModel accessory = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listToys = new List<OutputCategoryModel>();
            listAccessories = new List<OutputCategoryModel>();

            // Get value
            foreach (var obj in resultObject.ListToys)
            {
                toy = new OutputCategoryModel();

                toy.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                toy.CategoryName = DataHelper.ToString(obj.CategoryName);

                listToys.Add(toy);
            }
            foreach (var obj in resultObject.ListAccessories)
            {
                accessory = new OutputCategoryModel();

                accessory.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                accessory.CategoryName = DataHelper.ToString(obj.CategoryName);

                listAccessories.Add(accessory);
            }

            // Set value
            responseModel.CartCount = DataHelper.ToString(Formats.NUMBER, resultObject.CartCount);
            responseModel.ListToys = listToys;
            responseModel.ListAccessories = listAccessories;
            responseModel.ListCategory = MCodeCom.ToComboItems(resultObject.ListCategory, 0);
            responseModel.ListAge = MCodeCom.ToComboItems(resultObject.ListAge, 0);
            responseModel.ListGender = MCodeCom.ToComboItems(resultObject.ListGender, 0);
            responseModel.ListBrand = MCodeCom.ToComboItems(resultObject.ListBrand, 0);
            responseModel.ListPriceDiv = MCodeCom.ToComboItems(resultObject.ListPriceDiv, 0);

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

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
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
            ClientMasterDao clientMasterDao = null;
            MCodeCom mCodeCom = null;
            CartCom cartCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientMasterDao = new ClientMasterDao();
            mCodeCom = new MCodeCom();
            cartCom = new CartCom(inputObject.Cart);

            // Get data
            var cartCount = cartCom.Count;
            var listToys = clientMasterDao.GetListCategories(Logics.CD_CATEGORY_DIV_TOYS);
            var listAccessories = clientMasterDao.GetListCategories(Logics.CD_CATEGORY_DIV_ACCESSORIES);
            var listCategory = mCodeCom.GetListCategory(true, false);
            var listAge = mCodeCom.GetListAge(true, false);
            var listGender = mCodeCom.GetListGender(true, false);
            var listBrand = mCodeCom.GetListBrand(true, false);
            var listPriceDiv = mCodeCom.GetListCode(Logics.GROUP_PRICE_DIV, null, true, false);

            // Set value
            getResult.CartCount = cartCount;
            getResult.ListToys = listToys;
            getResult.ListAccessories = listAccessories;
            getResult.ListCategory = listCategory;
            getResult.ListAge = listAge;
            getResult.ListGender = listGender;
            getResult.ListBrand = listBrand;
            getResult.ListPriceDiv = listPriceDiv;

            // Return value
            return getResult;
        }
        #endregion
    }
}