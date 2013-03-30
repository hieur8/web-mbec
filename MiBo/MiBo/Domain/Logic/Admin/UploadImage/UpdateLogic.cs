using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Web.Admin.UploadImage;
using MiBo.Domain.Model.Admin.UploadImage;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Exceptions;

namespace MiBo.Domain.Logic.Admin.UploadImage
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
            StorageFileCom storageFileCom = null;

            // Variable initialize
            storageFileCom = new StorageFileCom();

            // Check valid
            int i = 0;
            foreach (var obj in inputObject.ListFiles)
            {
                if (DataCheckHelper.IsNull(obj.FileId))
                    throw new ExecuteException("E_MSG_00004", string.Format("Mã tập tin ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.FileNo))
                    throw new ExecuteException("E_MSG_00004", string.Format("Số tập tin ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.SortKey))
                    throw new ExecuteException("E_MSG_00004", string.Format("Thứ tự ({0})", i + 1));
                if (!storageFileCom.IsExist(obj.FileId, obj.FileNo, true))
                    throw new DataNotExistException(string.Format("Tập tin ({0})", i + 1));
                i++;
            }
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private UpdateDataModel UpdateInfo(UpdateDataModel inputObject)
        {
            // Local variable declaration
            UpdateDataModel getResult = null;
            StorageFileCom storageFileCom = null;

            // Variable initialize
            getResult = new UpdateDataModel();
            storageFileCom = new StorageFileCom();

            // Get data
            foreach (var obj in inputObject.ListFiles)
            {
                storageFileCom.UpdateSortKey(obj, true);
            }

            // Submit data
            storageFileCom.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}