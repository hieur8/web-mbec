using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.CategoryList;
using MiBo.Domain.Web.Admin.CategoryList;
using Resources;

namespace MiBo.Domain.Logic.Admin.CategoryList
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
            IList<OutputCategoryModel> listCategories = null;
            OutputCategoryModel category = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listCategories = new List<OutputCategoryModel>();

            // Get value
            var cbCategoryDiv = new ComboModel();
            var cbDeleteFlag = new ComboModel();
            foreach (var obj in resultObject.ListCategories)
            {
                category = new OutputCategoryModel();
                category.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                category.CategoryName = DataHelper.ToString(obj.CategoryName);
                category.CategorySearchName = DataHelper.ToString(obj.CategorySearchName);
                category.CategoryDiv = DataHelper.ToString(obj.CategoryDiv);
                category.SortKey = DataHelper.ToString(Formats.NUMBER, obj.SortKey);
                category.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                category.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);

                cbCategoryDiv = MCodeCom.ToComboItems(resultObject.ListCategoryDiv, category.CategoryDiv);
                category.ListCategoryDiv = cbCategoryDiv.ListItems;
                category.CategoryDiv = cbCategoryDiv.SeletedValue;
                cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, category.DeleteFlag);
                category.ListDeleteFlag = cbDeleteFlag.ListItems;
                category.DeleteFlag = cbDeleteFlag.SeletedValue;

                listCategories.Add(category);
            }

            // Set value
            responseModel.ListCategories = listCategories;

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
            if (!PageHelper.AuthRole(Logics.RL_CATEGORIES))
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
            AdminCategoryListDao adminCategoryListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminCategoryListDao = new AdminCategoryListDao();

            // Get data
            var listCategoryDiv = mCodeCom.GetListCode(Logics.GROUP_CATEGORY_DIV, null, false, false);
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var listAccepts = adminCategoryListDao.GetListCategories();

            // Set value
            getResult.ListCategoryDiv = listCategoryDiv;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListCategories = listAccepts;

            // Return value
            return getResult;
        }
        #endregion
    }
}