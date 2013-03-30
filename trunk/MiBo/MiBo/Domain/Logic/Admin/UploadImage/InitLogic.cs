using System.Collections.Generic;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.UploadImage;
using MiBo.Domain.Web.Admin.UploadImage;
using Resources;

namespace MiBo.Domain.Logic.Admin.UploadImage
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
            IList<OutputImageModel> listFiles = null;
            OutputImageModel file = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listFiles = new List<OutputImageModel>();

            // Get value
            foreach (var obj in resultObject.ListFiles)
            {
                file = new OutputImageModel();

                file.FileId = DataHelper.ToString(obj.FileId);
                file.FileName = DataHelper.ToString(obj.FileName);
                file.FileGroup = DataHelper.ToString(obj.FileGroup);
                file.FileNo = DataHelper.ToString(Formats.NUMBER, obj.FileNo);
                file.SortKey = DataHelper.ToString(Formats.NUMBER, obj.SortKey);
                listFiles.Add(file);
            }

            // Set value
            responseModel.FileId = DataHelper.ToString(resultObject.FileId);
            responseModel.FileGroup = DataHelper.ToString(resultObject.FileGroup);
            responseModel.ListFiles = listFiles;

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
            StorageFileCom storageFileCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            storageFileCom = new StorageFileCom();

            // Get data
            var listFiles = storageFileCom.GetList(inputObject.FileId, false);

            // Set value
            getResult.FileId = inputObject.FileId;
            getResult.FileGroup = inputObject.FileGroup;
            getResult.ListFiles = listFiles;

            // Return value
            return getResult;
        }
        #endregion
    }
}