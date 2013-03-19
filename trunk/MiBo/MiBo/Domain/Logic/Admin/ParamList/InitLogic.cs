using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.ParamList;
using MiBo.Domain.Web.Admin.ParamList;
using Resources;

namespace MiBo.Domain.Logic.Admin.ParamList
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
            IList<OutputParamModel> listParams = null;
            OutputParamModel param = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listParams = new List<OutputParamModel>();

            // Get value
            foreach (var obj in resultObject.ListParams)
            {
                param = new OutputParamModel();

                param.ParamCd = DataHelper.ToString(obj.ParamCd);
                param.ParamName = DataHelper.ToString(obj.ParamName);
                if (obj.ParamType == Logics.PT_NUMBER)
                    param.ParamValue = DataHelper.ToString(Formats.NUMBER, obj.ParamValue);
                else if (obj.ParamType == Logics.PT_DATE)
                    param.ParamValue = DataHelper.ToString(Formats.DATE, obj.ParamValue);
                else
                    param.ParamValue = DataHelper.ToString(obj.ParamValue);
                param.ParamType = DataHelper.ToString(obj.ParamType);
                param.Notes = DataHelper.ToString(obj.Notes);
                param.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                listParams.Add(param);
            }

            // Set value
            responseModel.ListParams = listParams;

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
            MParameterCom mParameterCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            mParameterCom = new MParameterCom();

            // Get data
            var listParams = mParameterCom.GetList(false);

            // Set value
            getResult.ListParams = listParams;

            // Return value
            return getResult;
        }
        #endregion
    }
}