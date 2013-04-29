using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GroupRoleList;
using MiBo.Domain.Web.Admin.GroupRoleList;
using Resources;

namespace MiBo.Domain.Logic.Admin.GroupRoleList
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
            IList<OutputGroupRoleModel> listGroupRoles = null;
            OutputGroupRoleModel groupRole = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listGroupRoles = new List<OutputGroupRoleModel>();

            // Get value
            var cbDeleteFlag = new ComboModel();
            foreach (var obj in resultObject.ListGroupRoles)
            {
                groupRole = new OutputGroupRoleModel();
                groupRole.GroupCd = DataHelper.ToString(obj.GroupCd);
                groupRole.GroupName = DataHelper.ToString(obj.Group.GroupName);
                groupRole.RoleCd = DataHelper.ToString(obj.RoleCd);
                groupRole.RoleName = DataHelper.ToString(obj.Role.RoleName);
                groupRole.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                groupRole.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);

                cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, groupRole.DeleteFlag);
                groupRole.ListDeleteFlag = cbDeleteFlag.ListItems;
                groupRole.DeleteFlag = cbDeleteFlag.SeletedValue;

                listGroupRoles.Add(groupRole);
            }

            // Set value
            responseModel.GroupCd = resultObject.GroupCd;
            responseModel.ListGroupRoles = listGroupRoles;

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

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Check processing.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {
            // Local variable declaration
            var adminGroupRoleListDao = new AdminGroupRoleListDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_USERS))
                throw new ExecuteException("E_MSG_00013");

            // Exist group
            if(!adminGroupRoleListDao.IsExistGroup(inputObject.GroupCd))
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
            AdminGroupRoleListDao adminGroupRoleListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminGroupRoleListDao = new AdminGroupRoleListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var listGroupRoles = adminGroupRoleListDao.GetListGroupRoles(inputObject.GroupCd);

            // Set value
            getResult.GroupCd = inputObject.GroupCd;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListGroupRoles = listGroupRoles;

            // Return value
            return getResult;
        }
        #endregion
    }
}