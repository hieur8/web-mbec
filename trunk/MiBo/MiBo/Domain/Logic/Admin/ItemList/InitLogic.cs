using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.ItemList;
using MiBo.Domain.Web.Admin.ItemList;
using Resources;

namespace MiBo.Domain.Logic.Admin.ItemList
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
            MCodeCom mCodeCom = null;
            OutputItemModel item = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listItems = new List<OutputItemModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var itemDivName = string.Empty;
            var deleteFlagName = string.Empty;
            foreach (var obj in resultObject.ListItems)
            {
                item = new OutputItemModel();

                item.ItemCd = DataHelper.ToString(obj.ItemCd);
                item.ItemName = DataHelper.ToString(obj.ItemName);
                item.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                item.CategoryName = DataHelper.ToString(obj.Category.CategoryName);
                item.AgeCd = DataHelper.ToString(obj.AgeCd);
                item.AgeName = DataHelper.ToString(obj.Age.AgeName);
                item.GenderCd = DataHelper.ToString(obj.GenderCd);
                item.GenderName = DataHelper.ToString(obj.Gender.GenderName);
                item.BrandCd = DataHelper.ToString(obj.BrandCd);
                item.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                item.CountryCd = DataHelper.ToString(obj.CountryCd);
                item.CountryName = DataHelper.ToString(obj.Country.CountryName);
                item.UnitCd = DataHelper.ToString(obj.UnitCd);
                item.UnitName = DataHelper.ToString(obj.Unit.UnitName);
                item.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                itemDivName = mCodeCom.GetCodeName(Logics.GROUP_ITEM_DIV, item.ItemDiv);
                item.ItemDivName = DataHelper.ToString(itemDivName);
                item.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                item.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, item.DeleteFlag);
                item.DeleteFlagName = DataHelper.ToString(deleteFlagName);

                listItems.Add(item);
            }

            // Set value
            var cbCategory = MCodeCom.ToComboItems(resultObject.ListCategory, null);
            responseModel.ListCategory = cbCategory.ListItems;
            responseModel.CategoryCd = cbCategory.SeletedValue;
            var cbAge = MCodeCom.ToComboItems(resultObject.ListAge, null);
            responseModel.ListAge = cbAge.ListItems;
            responseModel.AgeCd = cbAge.SeletedValue;
            var cbGender = MCodeCom.ToComboItems(resultObject.ListGender, null);
            responseModel.ListGender = cbGender.ListItems;
            responseModel.GenderCd = cbGender.SeletedValue;
            var cbBrand = MCodeCom.ToComboItems(resultObject.ListBrand, null);
            responseModel.ListBrand = cbBrand.ListItems;
            responseModel.BrandCd = cbBrand.SeletedValue;
            var cbCountry = MCodeCom.ToComboItems(resultObject.ListCountry, null);
            responseModel.ListCountry = cbCountry.ListItems;
            responseModel.CountryCd = cbCountry.SeletedValue;
            var cbUnit = MCodeCom.ToComboItems(resultObject.ListUnit, null);
            responseModel.ListUnit = cbUnit.ListItems;
            responseModel.UnitCd = cbUnit.SeletedValue;
            var cbItemDiv = MCodeCom.ToComboItems(resultObject.ListItemDiv, null);
            responseModel.ListItemDiv = cbItemDiv.ListItems;
            responseModel.ItemDiv = cbItemDiv.SeletedValue;
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, null);
            responseModel.ListDeleteFlag = cbDeleteFlag.ListItems;
            responseModel.DeleteFlag = cbDeleteFlag.SeletedValue;
            responseModel.ListItems = listItems;

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

            // Check infomation
            Check(inputObject);

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {
            // Check role
            if (!PageHelper.AuthRole(Logics.RL_ITEMS))
                throw new ExecuteException("E_MSG_00013");
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
            MCodeCom mCodeCom = null;
            AdminItemListDao adminItemListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminItemListDao = new AdminItemListDao();

            // Get data
            var listCategory = mCodeCom.GetListCategory(true, false);
            var listAge = mCodeCom.GetListAge(true, false);
            var listGender = mCodeCom.GetListGender(true, false);
            var listBrand = mCodeCom.GetListBrand(true, false);
            var listCountry = mCodeCom.GetListCountry(true, false);
            var listUnit = mCodeCom.GetListUnit(true, false);
            var listItemDiv = mCodeCom.GetListCode(Logics.GROUP_ITEM_DIV, null, true, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var listItems = adminItemListDao.GetListItems();

            // Set value
            getResult.ListCategory = listCategory;
            getResult.ListAge = listAge;
            getResult.ListGender = listGender;
            getResult.ListBrand = listBrand;
            getResult.ListCountry = listCountry;
            getResult.ListUnit = listUnit;
            getResult.ListItemDiv = listItemDiv;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListItems = listItems;

            // Return value
            return getResult;
        }
        #endregion
    }
}