using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.ItemEntry;
using MiBo.Domain.Web.Admin.ItemEntry;

namespace MiBo.Domain.Logic.Admin.ItemEntry
{
    public class SaveLogic
    {
        #region Private variable
        private string _status;
        private bool IsAdd { get { return _status == Logics.CODE_STATUS_ADD; } }
        private bool IsEdit { get { return _status == Logics.CODE_STATUS_EDIT; } }
        #endregion

        #region Constructor

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

            var pack = new Pack();
            pack.ItemCd = inputObject.ItemCd;
            pack.UnitCd = inputObject.UnitCd;
            pack.BuyingPrice = inputObject.BuyingPrice;
            pack.SalesPrice = inputObject.SalesPrice;
            pack.Notes = string.Empty;
            pack.SortKey = decimal.One;
            inputObject.ListPacks = new List<Pack>() { pack };

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

            // Check valid
            if(!FileHelper.ExistImages(inputObject.ImagePath, Logics.EXT_JPEG))
                throw new ExecuteException("E_MSG_00012", "Hình ảnh");
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

            // Variable initialize
            saveResult = new SaveDataModel();
            adminItemEntryDao = new AdminItemEntryDao();

            if (IsAdd) adminItemEntryDao.InsertItem(inputObject); // Insert 
            else adminItemEntryDao.UpdateItem(inputObject); // Update
            FileHelper.MoveImages(inputObject.ImagePath,
                string.Format(Logics.PATH_IMG_ITEM, inputObject.ItemCd), Logics.EXT_JPEG);

            return saveResult;
        }
        #endregion
    }
}