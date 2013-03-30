using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.UploadImage;
using MiBo.Domain.Web.Admin.UploadImage;

namespace MiBo.Domain.Logic.Admin.UploadImage
{
    public class DeleteLogic
    {
        #region Invoke Method
        /// <summary>
        /// Delete process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public DeleteResponseModel Invoke(DeleteRequestModel request)
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
        private DeleteDataModel Convert(DeleteRequestModel request)
        {
            // Local variable declaration
            DeleteDataModel inputObject = null;

            // Variable initialize
            inputObject = new DeleteDataModel();

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
        private DeleteResponseModel Convert(DeleteDataModel resultObject)
        {
            // Local variable declaration
            DeleteResponseModel responseModel = null;

            // Variable initialize
            responseModel = new DeleteResponseModel();

            // Set value
            responseModel.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00004"));

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private DeleteResponseModel Execute(DeleteRequestModel request)
        {
            // Local variable declaration
            DeleteResponseModel responseModel = null;
            DeleteDataModel inputObject = null;
            DeleteDataModel resultObject = null;

            // Variable initialize
            responseModel = new DeleteResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check infomation
            Check(inputObject);

            // Delete infomation
            resultObject = DeleteInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>ResultModel</returns>
        private void Check(DeleteDataModel inputObject)
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
                if (!storageFileCom.IsExist(obj.FileId, obj.FileNo, true))
                    throw new DataNotExistException(string.Format("Tập tin ({0})", i + 1));
                i++;
            }
        }

        /// <summary>
        /// Delete infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private DeleteDataModel DeleteInfo(DeleteDataModel inputObject)
        {
            // Local variable declaration
            DeleteDataModel getResult = null;
            StorageFileCom storageFileCom = null;

            // Variable initialize
            getResult = new DeleteDataModel();
            storageFileCom = new StorageFileCom();

            // Get data
            foreach (var obj in inputObject.ListFiles)
            {
                storageFileCom.DeleteLogical(obj, true);
            }

            // Submit data
            storageFileCom.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}