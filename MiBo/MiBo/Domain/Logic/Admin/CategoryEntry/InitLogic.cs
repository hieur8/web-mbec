using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.CategoryEntry;
using MiBo.Domain.Web.Admin.CategoryEntry;

namespace MiBo.Domain.Logic.Admin.CategoryEntry
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
            details.CategoryDiv = DataHelper.ToString(resultObject.CategoryDiv);
            details.DeleteFlag = DataHelper.ToString(resultObject.DeleteFlag);

            var cbCategoryDiv = MCodeCom.ToComboItems(resultObject.ListCategoryDiv, details.CategoryDiv);
            details.ListCategoryDiv = cbCategoryDiv.ListItems;
            details.CategoryDiv = cbCategoryDiv.SeletedValue;
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

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();

            // Get data
            var listCategoryDiv = mCodeCom.GetListCode(Logics.GROUP_CATEGORY_DIV, null, false, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);

            // Set value
            getResult.ListCategoryDiv = listCategoryDiv;
            getResult.ListDeleteFlag = listDeleteFlag;

            // Return value
            return getResult;
        }
        #endregion
    }
}