using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GroupRoleEntry;
using MiBo.Domain.Web.Admin.GroupRoleEntry;

namespace MiBo.Domain.Logic.Admin.GroupRoleEntry
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
            InitResponseModel response = null;
            OutputDetailsModel details = null;

            // Variable initialize
            response = new InitResponseModel();
            details = new OutputDetailsModel();

            // Get value
            var group = resultObject.Group;

            details.GroupCd = DataHelper.ToString(group.GroupCd);
            details.GroupName = DataHelper.ToString(group.GroupName);
            details.RoleCd = DataHelper.ToString(resultObject.RoleCd);
            details.DeleteFlag = DataHelper.ToString(resultObject.DeleteFlag);

            var cbRole = MCodeCom.ToComboItems(resultObject.ListRole, details.RoleCd);
            details.ListRole = cbRole.ListItems;
            details.RoleCd = cbRole.SeletedValue;
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, details.DeleteFlag);
            details.ListDeleteFlag = cbDeleteFlag.ListItems;
            details.DeleteFlag = cbDeleteFlag.SeletedValue;

            // Set value
            response.Details = new List<OutputDetailsModel>() { details };

            // Return value
            return response;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Execute(InitRequestModel request)
        {
            // Local variable declaration
            InitResponseModel response = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = null;

            // Variable initialize
            response = new InitResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing
            Check(inputObject);

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            response = Convert(resultObject);

            return response;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private void Check(InitDataModel inputObject)
        {
            // Local variable declaration
            var adminGroupRoleEntryDao = new AdminGroupRoleEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_USERS))
                throw new ExecuteException("E_MSG_00013");

            // Exist group
            if (!adminGroupRoleEntryDao.IsExistGroup(inputObject.GroupCd))
                throw new DataNotExistException("Nhóm");
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
            MCodeCom mCodeCom = null;
            AdminGroupRoleEntryDao adminGroupRoleEntryDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminGroupRoleEntryDao = new AdminGroupRoleEntryDao();

            // Get data
            var group = adminGroupRoleEntryDao.GetGroup(inputObject.GroupCd);
            var listRole = mCodeCom.GetListRole(false, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);

            // Set value
            getResult.Group = group;
            getResult.ListRole = listRole;
            getResult.ListDeleteFlag = listDeleteFlag;

            // Return value
            return getResult;
        }
        #endregion
    }
}