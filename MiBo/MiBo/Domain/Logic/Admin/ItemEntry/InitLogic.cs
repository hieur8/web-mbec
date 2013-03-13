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
            details.CategoryCd = DataHelper.ToString(item.CategoryCd);
            details.AgeCd = DataHelper.ToString(item.AgeCd);
            details.GenderCd = DataHelper.ToString(item.GenderCd);
            details.BrandCd = DataHelper.ToString(item.BrandCd);
            details.CountryCd = DataHelper.ToString(item.CountryCd);
            details.UnitCd = DataHelper.ToString(item.UnitCd);
            details.ItemDiv = DataHelper.ToString(item.ItemDiv);
            details.SalesPrice = DataHelper.ToString(Formats.NUMBER, item.SalesPrice);
            details.BuyingPrice = DataHelper.ToString(Formats.NUMBER, item.BuyingPrice);
            details.Notes = DataHelper.ToString(item.Notes);
            details.SortKey = DataHelper.ToString(item.SortKey);
            details.DeleteFlag = DataHelper.ToString(item.DeleteFlag);
            details.ListCategory = MCodeCom.ToComboItems(resultObject.ListCategory, 0);
            details.ListAge = MCodeCom.ToComboItems(resultObject.ListAge, 0);
            details.ListGender = MCodeCom.ToComboItems(resultObject.ListGender, 0);
            details.ListBrand = MCodeCom.ToComboItems(resultObject.ListBrand, 0);
            details.ListCountry = MCodeCom.ToComboItems(resultObject.ListCountry, 0);
            details.ListUnit = MCodeCom.ToComboItems(resultObject.ListUnit, 0);
            details.ListItemDiv = MCodeCom.ToComboItems(resultObject.ListItemDiv, 0);
            details.ListDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, 0);
            details.ImagePath = DataHelper.ToString(resultObject.ImagePath);

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
            var listCategory = mCodeCom.GetListCategory(true, false);
            var listAge = mCodeCom.GetListAge(true, false);
            var listGender = mCodeCom.GetListGender(true, false);
            var listBrand = mCodeCom.GetListBrand(true, false);
            var listCountry = mCodeCom.GetListCountry(true, false);
            var listUnit = mCodeCom.GetListUnit(true, false);
            var listItemDiv = mCodeCom.GetListCode(Logics.GROUP_ITEM_DIV, null, true, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var imagePath = UploadHelper.GetUploadUrl();
            var item = new Item();
            if (!IsAdd) {
                item = adminItemEntryDao.GetSingleItem(inputObject.ItemCd);
                FileHelper.CopyImages(string.Format(Logics.PATH_IMG_ITEM, item.ItemCd),
                    imagePath, Logics.EXT_JPEG);
            }

            // Set value
            getResult.ListCategory = listCategory;
            getResult.ListAge = listAge;
            getResult.ListGender = listGender;
            getResult.ListBrand = listBrand;
            getResult.ListCountry = listCountry;
            getResult.ListUnit = listUnit;
            getResult.ListItemDiv = listItemDiv;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ImagePath = imagePath;
            getResult.Item = item;

            // Return value
            return getResult;
        }
        #endregion
    }
}