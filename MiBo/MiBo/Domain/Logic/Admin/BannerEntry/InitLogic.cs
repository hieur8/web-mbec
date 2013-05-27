using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.BannerEntry;
using MiBo.Domain.Web.Admin.BannerEntry;

namespace MiBo.Domain.Logic.Admin.BannerEntry
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
            var banner = resultObject.Banner;
            details.Status = DataHelper.ToString(_status);

            details.BannerCd = DataHelper.ToString(banner.BannerCd);
            details.BannerName = DataHelper.ToString(banner.BannerName);
            details.OfferGroupCd = DataHelper.ToString(banner.OfferGroupCd);
            details.SortKey = DataHelper.ToString(banner.SortKey);
            details.FileId = DataHelper.ToString(banner.FileId);
            details.DeleteFlag = DataHelper.ToString(banner.DeleteFlag);

            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, details.DeleteFlag);
            details.ListDeleteFlag = cbDeleteFlag.ListItems;
            details.DeleteFlag = cbDeleteFlag.SeletedValue;

            var cbOfferGroup = MCodeCom.ToComboItems(resultObject.ListOfferGroup, details.OfferGroupCd);
            details.ListOfferGroup = cbOfferGroup.ListItems;
            details.OfferGroupCd = cbOfferGroup.SeletedValue;

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
            AdminBannerEntryDao adminBannerEntryDao = null;

            // Variable initialize
            adminBannerEntryDao = new AdminBannerEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_BANNERS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if (!IsAdd)
            {
                if (DataCheckHelper.IsNull(inputObject.BannerCd))
                    throw new ExecuteException("E_MSG_DATA_00004", "Mã banner");

                if (!adminBannerEntryDao.IsExistBanner(inputObject.BannerCd))
                    throw new DataNotExistException("Banner");
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
            AdminBannerEntryDao adminBannerEntryDao = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            adminBannerEntryDao = new AdminBannerEntryDao();
            mCodeCom = new MCodeCom();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var listOfferGroup = adminBannerEntryDao.GetListOfferGroup();
            var banner = new Banner();
            if (!IsAdd) banner = adminBannerEntryDao.GetSingleBanner(inputObject.BannerCd);
            else banner.FileId = DataHelper.GetUniqueKey();

            // Set value
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListOfferGroup = listOfferGroup;
            getResult.Banner = banner;

            // Return value
            return getResult;
        }
        #endregion
    }
}