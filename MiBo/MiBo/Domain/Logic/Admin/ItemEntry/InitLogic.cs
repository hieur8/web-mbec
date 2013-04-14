using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.ItemEntry;
using MiBo.Domain.Web.Admin.ItemEntry;
using Resources;

namespace MiBo.Domain.Logic.Admin.ItemEntry
{
    public class InitLogic
    {
        #region Private variable
        private string _status;
        private bool IsAdd { get { return _status == Logics.CODE_STATUS_ADD; } }
        #endregion

        #region Invoke Method
        /// <summary>
        /// Initialization process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public InitResponseModel Invoke(InitRequestModel request)
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
        private InitDataModel Convert(InitRequestModel request)
        {
            // Local variable declaration
            InitDataModel inputObject = null;

            // Variable initialize
            inputObject = new InitDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);
            _status = DataHelper.ConvertInputString(request.Status);

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
            InitResponseModel response = null;
            OutputDetailsModel details = null;

            // Variable initialize
            response = new InitResponseModel();
            details = new OutputDetailsModel();

            // Get value
            var item = resultObject.Item;
            details.Status = DataHelper.ToString(_status);
            details.ItemCd = DataHelper.ToString(item.ItemCd);
            details.ItemName = DataHelper.ToString(item.ItemName);
            details.ItemSearchName = DataHelper.ToString(item.ItemSearchName);
            details.CategoryCd = DataHelper.ToString(item.CategoryCd);
            details.AgeCd = DataHelper.ToString(item.AgeCd);
            details.GenderCd = DataHelper.ToString(item.GenderCd);
            details.BrandCd = DataHelper.ToString(item.BrandCd);
            details.CountryCd = DataHelper.ToString(item.CountryCd);
            details.UnitCd = DataHelper.ToString(item.UnitCd);
            details.ItemDiv = DataHelper.ToString(item.ItemDiv);
            details.SalesPrice = DataHelper.ToString(Formats.NUMBER, item.SalesPrice);
            details.BuyingPrice = DataHelper.ToString(Formats.NUMBER, item.BuyingPrice);
            details.LinkVideo = DataHelper.ToString(item.LinkVideo);
            details.Material = DataHelper.ToString(item.Material);
            details.SummaryNotes = DataHelper.ToString(item.SummaryNotes);
            details.Notes = DataHelper.ToString(item.Notes);
            details.SortKey = DataHelper.ToString(item.SortKey);
            details.DeleteFlag = DataHelper.ToString(item.DeleteFlag);
            details.FileId = DataHelper.ToString(item.FileId);

            var cbCategory = MCodeCom.ToComboItems(resultObject.ListCategory, details.CategoryCd);
            details.ListCategory = cbCategory.ListItems;
            details.CategoryCd = cbCategory.SeletedValue;
            var cbAge = MCodeCom.ToComboItems(resultObject.ListAge, details.AgeCd);
            details.ListAge = cbAge.ListItems;
            details.AgeCd = cbAge.SeletedValue;
            var cbGender = MCodeCom.ToComboItems(resultObject.ListGender, details.GenderCd);
            details.ListGender = cbGender.ListItems;
            details.GenderCd = cbGender.SeletedValue;
            var cbBrand = MCodeCom.ToComboItems(resultObject.ListBrand, details.BrandCd);
            details.ListBrand = cbBrand.ListItems;
            details.BrandCd = cbBrand.SeletedValue;
            var cbCountry = MCodeCom.ToComboItems(resultObject.ListCountry, details.CountryCd);
            details.ListCountry = cbCountry.ListItems;
            details.CountryCd = cbCountry.SeletedValue;
            var cbUnit = MCodeCom.ToComboItems(resultObject.ListUnit, details.UnitCd);
            details.ListUnit = cbUnit.ListItems;
            details.UnitCd = cbUnit.SeletedValue;
            var cbItemDiv = MCodeCom.ToComboItems(resultObject.ListItemDiv, details.ItemDiv);
            details.ListItemDiv = cbItemDiv.ListItems;
            details.ItemDiv = cbItemDiv.SeletedValue;
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, details.DeleteFlag);
            details.ListDeleteFlag = cbDeleteFlag.ListItems;
            details.DeleteFlag = cbDeleteFlag.SeletedValue;

            // Set value
            response.Details = new List<OutputDetailsModel>() { details };

            // Return value
            return response;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Execute(InitRequestModel request)
        {
            // Local variable declaration
            InitResponseModel response = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = null;

            // Variable initialize
            response = new InitResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing
            Check(inputObject);

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            response = Convert(resultObject);

            return response;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private void Check(InitDataModel inputObject)
        {
            // Local variable declaration
            AdminItemEntryDao adminItemEntryDao = null;

            // Variable initialize
            adminItemEntryDao = new AdminItemEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_ITEMS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if (!IsAdd)
            {
                if (DataCheckHelper.IsNull(inputObject.ItemCd))
                    throw new ExecuteException("E_MSG_DATA_00004", "Mã sản phẩm");

                if (!adminItemEntryDao.IsExistItem(inputObject.ItemCd))
                    throw new DataNotExistException("Sản phẩm");
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
            MCodeCom mCodeCom = null;
            AdminItemEntryDao adminItemEntryDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminItemEntryDao = new AdminItemEntryDao();

            // Get data
            var listCategory = mCodeCom.GetListCategory(false, false);
            var listAge = mCodeCom.GetListAge(false, false);
            var listGender = mCodeCom.GetListGender(false, false);
            var listBrand = mCodeCom.GetListBrand(false, false);
            var listCountry = mCodeCom.GetListCountry(false, false);
            var listUnit = mCodeCom.GetListUnit(false, false);
            var listItemDiv = mCodeCom.GetListCode(Logics.GROUP_ITEM_DIV, null, false, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var item = new Item();
            if (!IsAdd) item = adminItemEntryDao.GetSingleItem(inputObject.ItemCd);
            else item.FileId = DataHelper.GetUniqueKey();

            // Set value
            getResult.ListCategory = listCategory;
            getResult.ListAge = listAge;
            getResult.ListGender = listGender;
            getResult.ListBrand = listBrand;
            getResult.ListCountry = listCountry;
            getResult.ListUnit = listUnit;
            getResult.ListItemDiv = listItemDiv;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.Item = item;

            // Return value
            return getResult;
        }
        #endregion
    }
}