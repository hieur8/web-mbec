using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.UploadImage;
using MiBo.Domain.Web.Admin.UploadImage;

namespace MiBo.Domain.Logic.Admin.UploadImage
{
    public class UploadLogic
    {
        #region Invoke Method
        /// <summary>
        /// Upload process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public UploadResponseModel Invoke(UploadRequestModel request)
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
        private UploadDataModel Convert(UploadRequestModel request)
        {
            // Local variable declaration
            UploadDataModel inputObject = null;

            // Variable initialize
            inputObject = new UploadDataModel();

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
        private UploadResponseModel Convert(UploadDataModel resultObject)
        {
            // Local variable declaration
            UploadResponseModel responseModel = null;

            // Variable initialize
            responseModel = new UploadResponseModel();

            // Set value
            responseModel.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00005"));

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private UploadResponseModel Execute(UploadRequestModel request)
        {
            // Local variable declaration
            UploadResponseModel responseModel = null;
            UploadDataModel inputObject = null;
            UploadDataModel resultObject = null;

            // Variable initialize
            responseModel = new UploadResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check infomation
            Check(inputObject);

            // Upload infomation
            resultObject = UploadInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>ResultModel</returns>
        private void Check(UploadDataModel inputObject)
        {
            // Check valid
            if (DataCheckHelper.IsNull(inputObject.InputStream))
                throw new ExecuteException("E_MSG_00004", "Tập tin");
            if (!StorageFileCom.MapImageSize.ContainsKey(inputObject.FileGroup))
                throw new ExecuteException("E_MSG_00001", "Nhóm tập tin");
        }

        /// <summary>
        /// Upload infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private UploadDataModel UploadInfo(UploadDataModel inputObject)
        {
            // Local variable declaration
            UploadDataModel getResult = null;
            StorageFileCom storageFileCom = null;

            // Variable initialize
            getResult = new UploadDataModel();
            storageFileCom = new StorageFileCom();

            // Get data
            var fileId = inputObject.FileId;
            var maxFileNo = storageFileCom.GetMaxFileNo(fileId);

            // Set data
            var param = new StorageFile();
            param.FileId = fileId;
            param.FileNo = maxFileNo + 1;
            param.FileName = DataHelper.GetUniqueKey() + ".jpg";
            param.FileGroup = inputObject.FileGroup;
            param.SortKey = inputObject.SortKey;

            // Upload data
            var uploadList = StorageFileCom.MapImageSize[param.FileGroup];

            foreach (var obj in uploadList)
	        {
                var path = string.Format("/pages/media/images/{0}/{1}/{2}",
                    inputObject.FileGroup, obj.SizeName, param.FileName);
                UploadHelper.UploadImage(inputObject.InputStream, obj.Width, obj.Height, path);
	        }

            // Insert data
            storageFileCom.Insert(param);

            // Submit data
            storageFileCom.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}