using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.ItemEntry;
using MiBo.Domain.Web.Admin.ItemEntry;
using MiBo.Domain.Common.Utils;

namespace MiBo.Domain.Logic.Admin.ItemEntry
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
            AdminItemEntryDao adminItemEntryDao = null;

            // Variable initialize
            adminItemEntryDao = new AdminItemEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_ITEMS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if (IsAdd && adminItemEntryDao.IsExistItem(inputObject.ItemCd))
                throw new DataExistException("Sản phẩm");
            if (IsEdit && !adminItemEntryDao.IsExistItem(inputObject.ItemCd))
                throw new DataNotExistException("Sản phẩm");
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
            AdminItemEntryDao adminItemEntryDao = null;
            StorageFileCom storageFileCom = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminItemEntryDao = new AdminItemEntryDao();
            storageFileCom = new StorageFileCom();

            if (IsAdd) adminItemEntryDao.InsertItem(inputObject); // Insert 
            else adminItemEntryDao.UpdateItem(inputObject); // Update

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