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
            IList<OutputAgeModel> listAges = null;
            IList<OutputGenderModel> listGenders = null;
            IList<OutputBrandModel> listBrands = null;
            IList<OutputCountryModel> listCountries = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listToys = new List<OutputCategoryModel>();
            listAccessories = new List<OutputCategoryModel>();
            listAges = new List<OutputAgeModel>();
            listGenders = new List<OutputGenderModel>();
            listBrands = new List<OutputBrandModel>();
            listCountries = new List<OutputCountryModel>();

            // Get value
            OutputCategoryModel toy = null;
            foreach (var obj in resultObject.ListToys)
            {
                toy = new OutputCategoryModel();

                toy.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                toy.CategoryName = DataHelper.ToString(obj.CategoryName);

                listToys.Add(toy);
            }

            OutputCategoryModel accessory = null;
            foreach (var obj in resultObject.ListAccessories)
            {
                accessory = new OutputCategoryModel();

                accessory.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                accessory.CategoryName = DataHelper.ToString(obj.CategoryName);

                listAccessories.Add(accessory);
            }


            OutputAgeModel age = null;
            foreach (var obj in resultObject.ListAge)
            {
                age = new OutputAgeModel();

                age.AgeCd = DataHelper.ToString(obj.AgeCd);
                age.AgeName = DataHelper.ToString(obj.AgeName);

                listAges.Add(age);
            }

            OutputGenderModel gender = null;
            foreach (var obj in resultObject.ListGender)
            {
                gender = new OutputGenderModel();

                gender.GenderCd = DataHelper.ToString(obj.GenderCd);
                gender.GenderName = DataHelper.ToString(obj.GenderName);

                listGenders.Add(gender);
            }

            OutputBrandModel brand = null;
            foreach (var obj in resultObject.ListBrand)
            {
                brand = new OutputBrandModel();

                brand.BrandCd = DataHelper.ToString(obj.BrandCd);
                brand.BrandName = DataHelper.ToString(obj.BrandName);

                listBrands.Add(brand);
            }

            OutputCountryModel country = null;
            foreach (var obj in resultObject.ListCountry)
            {
                country = new OutputCountryModel();

                country.CountryCd = DataHelper.ToString(obj.CountryCd);
                country.CountryName = DataHelper.ToString(obj.CountryName);

                listCountries.Add(country);
            }

            // Set value
            responseModel.CartCount = DataHelper.ToString(Formats.NUMBER, resultObject.CartCount);
            responseModel.DiscountMember = DataHelper.ToString(Formats.PERCENT, resultObject.DiscountMember);
            responseModel.ListToys = listToys;
            responseModel.ListAccessories = listAccessories;
            responseModel.ListAges = listAges;
            responseModel.ListGenders = listGenders;
            responseModel.ListBrands = listBrands;
            responseModel.ListCountries = listCountries;

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
            MParameterCom mParameterCom = null;
            CartCom cartCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientMasterDao = new ClientMasterDao();
            mCodeCom = new MCodeCom();
            mParameterCom = new MParameterCom();
            cartCom = new CartCom(inputObject.Cart);

            // Get data
            var cartCount = cartCom.Count;
            var discountMember = mParameterCom.GetNumber(Logics.PR_DISCOUNT_MEMBER, false);
            var listToys = clientMasterDao.GetListCategories(Logics.CD_CATEGORY_DIV_TOYS);
            var listAccessories = clientMasterDao.GetListCategories(Logics.CD_CATEGORY_DIV_ACCESSORIES);
            var listAge = clientMasterDao.GetListAge();
            var listGender = clientMasterDao.GetListGender();
            var listBrand = clientMasterDao.GetListBrand();
            var listCountry = clientMasterDao.GetListCountry();

            // Set value
            getResult.CartCount = cartCount;
            getResult.DiscountMember = discountMember * decimal.Negate(decimal.One);
            getResult.ListToys = listToys;
            getResult.ListAccessories = listAccessories;
            getResult.ListAge = listAge;
            getResult.ListGender = listGender;
            getResult.ListBrand = listBrand;
            getResult.ListCountry = listCountry;

            // Return value
            return getResult;
        }
        #endregion
    }
}