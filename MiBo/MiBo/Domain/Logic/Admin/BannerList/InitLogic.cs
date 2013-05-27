using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.BannerList;
using MiBo.Domain.Web.Admin.BannerList;
using Resources;

namespace MiBo.Domain.Logic.Admin.BannerList
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
            IList<OutputBannerModel> listBanners = null;
            OutputBannerModel banner = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listBanners = new List<OutputBannerModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var deleteFlagName = string.Empty;
            foreach (var obj in resultObject.ListBanners)
            {
                banner = new OutputBannerModel();

                banner.BannerCd = DataHelper.ToString(obj.BannerCd);
                banner.BannerName = DataHelper.ToString(obj.BannerName);
                banner.OfferGroupCd = DataHelper.ToString(obj.OfferGroupCd);
                banner.SortKey = DataHelper.ToString(obj.SortKey);
                banner.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, banner.DeleteFlag);
                banner.DeleteFlagName = DataHelper.ToString(deleteFlagName);
                banner.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);

                listBanners.Add(banner);
            }

            // Set value
            responseModel.ListBanners = listBanners;

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
            if (!PageHelper.AuthRole(Logics.RL_BANNERS))
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
            AdminBannerListDao adminBannerListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminBannerListDao = new AdminBannerListDao();

            // Get data
            var listBanners = adminBannerListDao.GetListBanners();

            // Set value
            getResult.ListBanners = listBanners;

            // Return value
            return getResult;
        }
        #endregion
    }
}