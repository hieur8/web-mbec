using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.ParamList;
using MiBo.Domain.Web.Admin.ParamList;

namespace MiBo.Domain.Logic.Admin.ParamList
{
    public class UpdateLogic
    {
        #region Invoke Method
        /// <summary>
        /// Update process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public UpdateResponseModel Invoke(UpdateRequestModel request)
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
        private UpdateDataModel Convert(UpdateRequestModel request)
        {
            // Local variable declaration
            UpdateDataModel inputObject = null;

            // Variable initialize
            inputObject = new UpdateDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);

            // Return value
            return inputObject;
        }

        /// <summary>
        /// Execute convert output.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private UpdateResponseModel Convert(UpdateDataModel resultObject)
        {
            // Local variable declaration
            UpdateResponseModel responseModel = null;

            // Variable initialize
            responseModel = new UpdateResponseModel();

            // Set value
            responseModel.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00001"));

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private UpdateResponseModel Execute(UpdateRequestModel request)
        {
            // Local variable declaration
            UpdateResponseModel responseModel = null;
            UpdateDataModel inputObject = null;
            UpdateDataModel resultObject = null;

            // Variable initialize
            responseModel = new UpdateResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check infomation
            Check(inputObject);

            // Update infomation
            resultObject = UpdateInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>ResultModel</returns>
        private void Check(UpdateDataModel inputObject)
        {
            // Local variable declaration
            MParameterCom mParameterCom = null;

            // Variable initialize
            mParameterCom = new MParameterCom();

            // Check valid
            int i = 0;
            foreach (var obj in inputObject.ListParams)
            {
                if (DataCheckHelper.IsNull(obj.ParamValue))
                    throw new ExecuteException("E_MSG_00004", string.Format("Giá trị ({0})", i + 1));
                if (!mParameterCom.IsExist(obj.ParamCd, false))
                    throw new DataNotExistException(string.Format("Tham số ({0})", i + 1));
                var paramType = mParameterCom.GetType(obj.ParamCd, false);
                if (paramType == Logics.PT_NUMBER && !DataCheckHelper.IsNumber(obj.ParamValue))
                    throw new ExecuteException("E_MSG_00001", string.Format("Giá trị ({0})", i + 1));
                if (paramType == Logics.PT_DATE && !DataCheckHelper.IsDate(obj.ParamValue))
                    throw new ExecuteException("E_MSG_00001", string.Format("Giá trị ({0})", i + 1));
            }
        }

        /// <summary>
        /// Update item to cart
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private UpdateDataModel UpdateInfo(UpdateDataModel inputObject)
        {
            // Local variable declaration
            UpdateDataModel getResult = null;
            MParameterCom mParameterCom = null;

            // Variable initialize
            getResult = new UpdateDataModel();
            mParameterCom = new MParameterCom();

            // Get data
            foreach (var obj in inputObject.ListParams)
            {
                mParameterCom.Update(obj, false);
            }

            // Submit data
            mParameterCom.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}