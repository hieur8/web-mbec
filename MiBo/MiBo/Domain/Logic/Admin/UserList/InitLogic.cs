using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.UserList;
using MiBo.Domain.Web.Admin.UserList;
using Resources;

namespace MiBo.Domain.Logic.Admin.UserList
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
            IList<OutputUserModel> listUsers = null;
            MCodeCom mCodeCom = null;
            OutputUserModel user = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listUsers = new List<OutputUserModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var deleteFlagName = string.Empty;
            foreach (var obj in resultObject.ListUsers)
            {
                user = new OutputUserModel();

                user.UserCd = DataHelper.ToString(obj.UserCd);
                user.Email = DataHelper.ToString(obj.Email);
                user.FullName = DataHelper.ToString(obj.FullName);
                user.Address = DataHelper.ToString(obj.Address);
                user.CityCd = DataHelper.ToString(obj.CityCd);
                user.CityName = DataHelper.ToString(obj.City.CityName);
                user.Phone1 = DataHelper.ToString(obj.Phone1);
                user.Phone2 = DataHelper.ToString(obj.Phone2);
                user.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                user.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, user.DeleteFlag);
                user.DeleteFlagName = DataHelper.ToString(deleteFlagName);
                if (obj.UserGroups.Count > decimal.Zero)
                {
                    user.GroupCd = DataHelper.ToString(obj.UserGroups[0].GroupCd);
                    user.GroupName = DataHelper.ToString(obj.UserGroups[0].Group.GroupName);
                }
                listUsers.Add(user);
            }

            // Set value
            var cbCity = MCodeCom.ToComboItems(resultObject.ListCity, null);
            responseModel.ListCity = cbCity.ListItems;
            responseModel.CityCd = cbCity.SeletedValue;
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, null);
            responseModel.ListDeleteFlag = cbDeleteFlag.ListItems;
            responseModel.DeleteFlag = cbDeleteFlag.SeletedValue;
            var cbGroup = MCodeCom.ToComboItems(resultObject.ListGroup, null);
            responseModel.ListGroup = cbGroup.ListItems;
            responseModel.GroupCd = cbGroup.SeletedValue;
            responseModel.ListUsers = listUsers;

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
            // Check role
            if (!PageHelper.AuthRole(Logics.RL_USERS))
                throw new ExecuteException("E_MSG_00013");
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
            AdminUserListDao adminUserListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminUserListDao = new AdminUserListDao();

            // Get data
            var listCity = mCodeCom.GetListCity(true, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var listGroup = mCodeCom.GetListGroup(true, false);
            var listUsers = adminUserListDao.GetListUsers();

            // Set value
            getResult.ListCity = listCity;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListGroup = listGroup;
            getResult.ListUsers = listUsers;

            // Return value
            return getResult;
        }
        #endregion
    }
}