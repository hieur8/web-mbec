using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GroupList;
using MiBo.Domain.Web.Admin.GroupList;

namespace MiBo.Domain.Logic.Admin.GroupList
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

            // Add message
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
            AdminGroupListDao adminGroupListDao = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            adminGroupListDao = new AdminGroupListDao();
            mCodeCom = new MCodeCom();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_USERS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            int i = 0;
            foreach (var obj in inputObject.ListGroups)
            {
                var dFlag = DataHelper.ToString(obj.DeleteFlag);

                if (DataCheckHelper.IsNull(obj.GroupName))
                    throw new ExecuteException("E_MSG_00004", string.Format("Tên nhóm ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.SortKey))
                    throw new ExecuteException("E_MSG_00004", string.Format("Thứ tự ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.DeleteFlag))
                    throw new ExecuteException("E_MSG_00004", string.Format("Dữ liệu ({0})", i + 1));
                if (!mCodeCom.IsExist(Logics.GROUP_DELETE_FLAG, dFlag, false))
                    throw new DataNotExistException(string.Format("Dữ liệu ({0})", i + 1));
                if (!adminGroupListDao.IsExistGroup(obj.GroupCd))
                    throw new DataNotExistException(string.Format("Nhóm ({0})", i + 1));
                i++;
            }
        }

        /// <summary>
        /// Update infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private UpdateDataModel UpdateInfo(UpdateDataModel inputObject)
        {
            // Local variable declaration
            UpdateDataModel getResult = null;
            AdminGroupListDao adminGroupListDao = null;

            // Variable initialize
            getResult = new UpdateDataModel();
            adminGroupListDao = new AdminGroupListDao();

            // Update data
            foreach (var obj in inputObject.ListGroups)
            {
                adminGroupListDao.UpdateGroup(obj);
            }
            // Submit data
            adminGroupListDao.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}