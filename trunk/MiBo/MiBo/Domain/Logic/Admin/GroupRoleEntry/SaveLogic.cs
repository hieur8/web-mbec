using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GroupRoleEntry;
using MiBo.Domain.Web.Admin.GroupRoleEntry;

namespace MiBo.Domain.Logic.Admin.GroupRoleEntry
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
            response.GroupCd = DataHelper.ToString(resultObject.GroupCd);
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
            var adminGroupRoleEntryDao = new AdminGroupRoleEntryDao();
            var mCodeCom = new MCodeCom();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_USERS))
                throw new ExecuteException("E_MSG_00013");

            // Exist group
            if (!adminGroupRoleEntryDao.IsExistGroup(inputObject.GroupCd))
                throw new DataNotExistException("Nhóm");

            // Check valid
            var dFlag = DataHelper.ToString(inputObject.DeleteFlag);

            if (!mCodeCom.IsExist(Logics.GROUP_DELETE_FLAG, dFlag, false))
                throw new DataNotExistException("Dữ liệu");
            if (adminGroupRoleEntryDao.IsExistGroupRole(inputObject.GroupCd, inputObject.RoleCd))
                throw new DataExistException("Quyền");
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
            AdminGroupRoleEntryDao adminGroupRoleEntryDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminGroupRoleEntryDao = new AdminGroupRoleEntryDao();

            // Insert data
            adminGroupRoleEntryDao.InsertGroupRole(inputObject);

            // Set value
            saveResult.GroupCd = inputObject.GroupCd;

            // Return value
            return saveResult;
        }
        #endregion
    }
}