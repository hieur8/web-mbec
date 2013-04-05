using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.BrandList;
using MiBo.Domain.Web.Admin.BrandList;
using Resources;

namespace MiBo.Domain.Logic.Admin.BrandList
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
            IList<OutputBrandModel> listBrands = null;
            MCodeCom mCodeCom = null;
            OutputBrandModel brand = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listBrands = new List<OutputBrandModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var deleteFlagName = string.Empty;
            foreach (var obj in resultObject.ListBrands)
            {
                brand = new OutputBrandModel();

                brand.BrandCd = DataHelper.ToString(obj.BrandCd);
                brand.BrandName = DataHelper.ToString(obj.BrandName);
                brand.FileId = DataHelper.ToString(obj.FileId);
                brand.SortKey = DataHelper.ToString(Formats.NUMBER, obj.SortKey);
                brand.Notes = DataHelper.ToString(obj.Notes);
                brand.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                brand.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, brand.DeleteFlag);
                brand.DeleteFlagName = DataHelper.ToString(deleteFlagName);

                listBrands.Add(brand);
            }

            // Set value
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, null);
            responseModel.ListDeleteFlag = cbDeleteFlag.ListItems;
            responseModel.DeleteFlag = cbDeleteFlag.SeletedValue;
            responseModel.ListBrands = listBrands;

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
            AdminBrandListDao adminBrandListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminBrandListDao = new AdminBrandListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var listBrands = adminBrandListDao.GetListBrands();

            // Set value
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListBrands = listBrands;

            // Return value
            return getResult;
        }
        #endregion
    }
}