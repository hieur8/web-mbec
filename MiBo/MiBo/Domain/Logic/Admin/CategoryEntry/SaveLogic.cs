using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.CategoryEntry;
using MiBo.Domain.Web.Admin.CategoryEntry;

namespace MiBo.Domain.Logic.Admin.CategoryEntry
{
    public class SaveLogic
    {
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
            AdminCategoryEntryDao adminCategoryEntryDao = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            adminCategoryEntryDao = new AdminCategoryEntryDao();
            mCodeCom = new MCodeCom();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_CATEGORIES))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            var dFlag = DataHelper.ToString(inputObject.DeleteFlag);

            if (!mCodeCom.IsExist(Logics.GROUP_CATEGORY_DIV, inputObject.CategoryDiv, false))
                throw new DataNotExistException("Chủng loại");
            if (!mCodeCom.IsExist(Logics.GROUP_DELETE_FLAG, dFlag, false))
                throw new DataNotExistException("Dữ liệu");
            if (adminCategoryEntryDao.IsExistCategory(inputObject.CategoryCd))
                throw new DataExistException("Loại sản phẩm");
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
            AdminCategoryEntryDao adminCategoryEntryDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminCategoryEntryDao = new AdminCategoryEntryDao();

            // Insert data
            adminCategoryEntryDao.InsertCategory(inputObject);

            return saveResult;
        }
        #endregion
    }
}