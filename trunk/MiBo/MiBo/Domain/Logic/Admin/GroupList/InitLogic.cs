using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GroupList;
using MiBo.Domain.Web.Admin.GroupList;
using Resources;

namespace MiBo.Domain.Logic.Admin.GroupList
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
            IList<OutputGroupModel> listGroups = null;
            OutputGroupModel group = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listGroups = new List<OutputGroupModel>();

            // Get value
            var cbDeleteFlag = new ComboModel();
            foreach (var obj in resultObject.ListGroups)
            {
                group = new OutputGroupModel();
                group.GroupCd = DataHelper.ToString(obj.GroupCd);
                group.GroupName = DataHelper.ToString(obj.GroupName);
                group.SortKey = DataHelper.ToString(Formats.NUMBER, obj.SortKey);
                group.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                group.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);

                cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, group.DeleteFlag);
                group.ListDeleteFlag = cbDeleteFlag.ListItems;
                group.DeleteFlag = cbDeleteFlag.SeletedValue;

                listGroups.Add(group);
            }

            // Set value
            responseModel.ListGroups = listGroups;

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
            AdminGroupListDao adminGroupListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminGroupListDao = new AdminGroupListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var listGroups = adminGroupListDao.GetListGroups();

            // Set value
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListGroups = listGroups;

            // Return value
            return getResult;
        }
        #endregion
    }
}