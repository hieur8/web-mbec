using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.BrandEntry;
using MiBo.Domain.Web.Admin.BrandEntry;

namespace MiBo.Domain.Logic.Admin.BrandEntry
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
            var brand = resultObject.Brand;
            details.Status = DataHelper.ToString(_status);
            details.BrandCd = DataHelper.ToString(brand.BrandCd);
            details.BrandName = DataHelper.ToString(brand.BrandName);
            details.BrandSearchName = DataHelper.ToString(brand.BrandSearchName);
            details.FileId = DataHelper.ToString(brand.FileId);
            details.Notes = DataHelper.ToString(brand.Notes);
            details.SortKey = DataHelper.ToString(brand.SortKey);
            details.DeleteFlag = DataHelper.ToString(brand.DeleteFlag);
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
            AdminBrandEntryDao adminBrandEntryDao = null;

            // Variable initialize
            adminBrandEntryDao = new AdminBrandEntryDao();

            // Check valid
            if (!IsAdd)
            {
                if (DataCheckHelper.IsNull(inputObject.BrandCd))
                    throw new ExecuteException("E_MSG_DATA_00004", "Mã thương hiệu");

                if (!adminBrandEntryDao.IsExistBrand(inputObject.BrandCd))
                    throw new DataNotExistException("Thương");
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
            AdminBrandEntryDao adminBrandEntryDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminBrandEntryDao = new AdminBrandEntryDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var brand = new Brand();
            if (!IsAdd) brand = adminBrandEntryDao.GetSingleBrand(inputObject.BrandCd);
            else brand.FileId = DataHelper.GetUniqueKey();

            // Set value
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.Brand = brand;

            // Return value
            return getResult;
        }
        #endregion
    }
}