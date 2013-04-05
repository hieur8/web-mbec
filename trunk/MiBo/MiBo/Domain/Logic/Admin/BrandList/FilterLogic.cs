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
    public class FilterLogic
    {
        #region Invoke Method
        /// <summary>
        /// Filter process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public FilterResponseModel Invoke(FilterRequestModel request)
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
        private FilterDataModel Convert(FilterRequestModel request)
        {
            // Local variable declaration
            FilterDataModel inputObject = null;

            // Variable initialize
            inputObject = new FilterDataModel();

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
        private FilterResponseModel Convert(FilterDataModel resultObject)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            IList<OutputBrandModel> listBrands = null;
            MCodeCom mCodeCom = null;
            OutputBrandModel brand = null;

            // Variable initialize
            responseModel = new FilterResponseModel();
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
            responseModel.ListBrands = listBrands;

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private FilterResponseModel Execute(FilterRequestModel request)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            FilterDataModel inputObject = null;
            FilterDataModel resultObject = null;

            // Variable initialize
            responseModel = new FilterResponseModel();

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
        private void Check(FilterDataModel inputObject)
        {
            // Local variable declaration
            DataCom dataCom = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            dataCom = new DataCom();
            mCodeCom = new MCodeCom();
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject)
        {
            // Local variable declaration
            FilterDataModel getResult = null;
            MCodeCom mCodeCom = null;
            AdminBrandListDao adminBrandListDao = null;

            // Variable initialize
            getResult = new FilterDataModel();
            mCodeCom = new MCodeCom();
            adminBrandListDao = new AdminBrandListDao();

            // Get data
            var listBrands = adminBrandListDao.GetListBrands(inputObject);

            // Set value
            getResult.ListBrands = listBrands;

            // Return value
            return getResult;
        }
        #endregion
    }
}