using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.BannerEntry;
using MiBo.Domain.Web.Admin.BannerEntry;

namespace MiBo.Domain.Logic.Admin.BannerEntry
{
    public class SaveLogic
    {
        #region Private variable
        private string _status;
        private bool IsAdd { get { return _status == Logics.CODE_STATUS_ADD; } }
        private bool IsEdit { get { return _status == Logics.CODE_STATUS_EDIT; } }
        #endregion

        #region Invoke Method
        /// <summary>
        /// Save process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public SaveResponseModel Invoke(SaveRequestModel request)
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
        private SaveDataModel Convert(SaveRequestModel request)
        {
            // Local variable declaration
            SaveDataModel inputObject = null;

            // Variable initialize
            inputObject = new SaveDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);
            _status = DataHelper.ConvertInputString(request.Status);

            // Return value
            return inputObject;
        }

        /// <summary>
        /// Execute convert ouput.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private SaveResponseModel Convert(SaveDataModel resultObject)
        {
            // Local variable declaration
            SaveResponseModel response = null;

            // Variable initialize
            response = new SaveResponseModel();

            // Set value
            response.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00001"));

            // Return value
            return response;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private SaveResponseModel Execute(SaveRequestModel request)
        {
            // Local variable declaration
            SaveResponseModel response = null;
            SaveDataModel inputObject = null;
            SaveDataModel resultObject = null;

            // Variable initialize
            response = new SaveResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing
            Check(inputObject);

            // Save infomation
            resultObject = SaveInfo(inputObject);

            // Execute convert ouput.
            response = Convert(resultObject);

            return response;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private void Check(SaveDataModel inputObject)
        {
            // Local variable declaration
            AdminBannerEntryDao adminBannerEntryDao = null;

            // Variable initialize
            adminBannerEntryDao = new AdminBannerEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_BANNERS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if (IsAdd && adminBannerEntryDao.IsExistBanner(inputObject.BannerCd))
                throw new DataExistException("Banner");
            if (IsEdit && !adminBannerEntryDao.IsExistBanner(inputObject.BannerCd))
                throw new DataNotExistException("Banner");
        }

        /// <summary>
        /// Save infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SaveDataModel SaveInfo(SaveDataModel inputObject)
        {
            // Local variable declaration
            SaveDataModel saveResult = null;
            AdminBannerEntryDao adminBannerEntryDao = null;
            StorageFileCom storageFileCom = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminBannerEntryDao = new AdminBannerEntryDao();
            storageFileCom = new StorageFileCom();

            if (IsAdd) adminBannerEntryDao.InsertBanner(inputObject); // Insert 
            else adminBannerEntryDao.UpdateBanner(inputObject); // Update

            // Update StorageFile
            foreach (var storageFile in storageFileCom.GetListActive(inputObject.FileId, false))
            {
                storageFile.ActiveFlag = true;
                storageFileCom.UpdateActiveFlag(storageFile, false);
            }
            storageFileCom.SubmitChanges();

            return saveResult;
        }
        #endregion
    }
}