using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.UserEntry;
using MiBo.Domain.Web.Admin.UserEntry;

namespace MiBo.Domain.Logic.Admin.UserEntry
{
    public class InitLogic
    {
        #region Private variable
        private string _status;
        private bool IsAdd { get { return _status == Logics.CODE_STATUS_ADD; } }
        #endregion

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
            _status = DataHelper.ConvertInputString(request.Status);

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
            var user = resultObject.User;
            details.Password = DataHelper.ToString(Logics.PASSWORD_DEFAULT);
            details.Status = DataHelper.ToString(_status);
            details.UserCd = DataHelper.ToString(user.UserCd);
            details.Email = DataHelper.ToString(user.Email);
            details.FullName = DataHelper.ToString(user.FullName);
            details.Address = DataHelper.ToString(user.Address);
            details.CityCd = DataHelper.ToString(user.CityCd);
            details.Phone1 = DataHelper.ToString(user.Phone1);
            details.Phone2 = DataHelper.ToString(user.Phone2);
            details.DeleteFlag = DataHelper.ToString(user.DeleteFlag);
            if (user.UserGroups.Count > decimal.Zero)
                details.GroupCd = DataHelper.ToString(user.UserGroups[0].GroupCd);

            var cbCity = MCodeCom.ToComboItems(resultObject.ListCity, details.CityCd);
            details.ListCity = cbCity.ListItems;
            details.CityCd = cbCity.SeletedValue;
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, details.DeleteFlag);
            details.ListDeleteFlag = cbDeleteFlag.ListItems;
            details.DeleteFlag = cbDeleteFlag.SeletedValue;
            var cbGroup = MCodeCom.ToComboItems(resultObject.ListGroup, details.GroupCd);
            details.ListGroup = cbGroup.ListItems;
            details.GroupCd = cbGroup.SeletedValue;

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
            var adminUserEntryDao = new AdminUserEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_USERS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if (!IsAdd)
            {
                if (DataCheckHelper.IsNull(inputObject.UserCd))
                    throw new ExecuteException("E_MSG_DATA_00004", "Mã tài khoản");

                if (!adminUserEntryDao.IsExist(inputObject.UserCd))
                    throw new DataNotExistException("Tài khoản");
            }
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
            AdminUserEntryDao adminUserEntryDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminUserEntryDao = new AdminUserEntryDao();

            // Get data
            var listCity = mCodeCom.GetListCity(false, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var listGroup = mCodeCom.GetListGroup(false, false);
            var user = new User();
            if (!IsAdd) user = adminUserEntryDao.GetSingle(inputObject.UserCd);

            // Set value
            getResult.ListCity = listCity;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListGroup = listGroup;
            getResult.User = user;

            // Return value
            return getResult;
        }
        #endregion
    }
}