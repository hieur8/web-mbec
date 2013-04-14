using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.ItemList;
using MiBo.Domain.Web.Admin.ItemList;
using Resources;

namespace MiBo.Domain.Logic.Admin.ItemList
{
    public class FilterLogic
    {
        #region Invoke Method
        /// <summary>
        /// Filter process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public FilterResponseModel Invoke(FilterRequestModel request)
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
        private FilterDataModel Convert(FilterRequestModel request)
        {
            // Local variable declaration
            FilterDataModel inputObject = null;

            // Variable initialize
            inputObject = new FilterDataModel();

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
        private FilterResponseModel Convert(FilterDataModel resultObject)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            IList<OutputItemModel> listItems = null;
            MCodeCom mCodeCom = null;
            OutputItemModel item = null;

            // Variable initialize
            responseModel = new FilterResponseModel();
            listItems = new List<OutputItemModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var itemDivName = string.Empty;
            var deleteFlagName = string.Empty;
            foreach (var obj in resultObject.ListItems)
            {
                item = new OutputItemModel();

                item.ItemCd = DataHelper.ToString(obj.ItemCd);
                item.ItemName = DataHelper.ToString(obj.ItemName);
                item.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                item.CategoryName = DataHelper.ToString(obj.Category.CategoryName);
                item.AgeCd = DataHelper.ToString(obj.AgeCd);
                item.AgeName = DataHelper.ToString(obj.Age.AgeName);
                item.GenderCd = DataHelper.ToString(obj.GenderCd);
                item.GenderName = DataHelper.ToString(obj.Gender.GenderName);
                item.BrandCd = DataHelper.ToString(obj.BrandCd);
                item.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                item.CountryCd = DataHelper.ToString(obj.CountryCd);
                item.CountryName = DataHelper.ToString(obj.Country.CountryName);
                item.UnitCd = DataHelper.ToString(obj.UnitCd);
                item.UnitName = DataHelper.ToString(obj.Unit.UnitName);
                item.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                itemDivName = mCodeCom.GetCodeName(Logics.GROUP_ITEM_DIV, item.ItemDiv);
                item.ItemDivName = DataHelper.ToString(itemDivName);
                item.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                item.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, item.DeleteFlag);
                item.DeleteFlagName = DataHelper.ToString(deleteFlagName);
                listItems.Add(item);
            }

            // Set value
            responseModel.ListItems = listItems;

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private FilterResponseModel Execute(FilterRequestModel request)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            FilterDataModel inputObject = null;
            FilterDataModel resultObject = null;

            // Variable initialize
            responseModel = new FilterResponseModel();

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
        private void Check(FilterDataModel inputObject)
        {
            // Check role
            if (!PageHelper.AuthRole(Logics.RL_ITEMS))
                throw new ExecuteException("E_MSG_00013");
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject)
        {
            // Local variable declaration
            FilterDataModel getResult = null;
            MCodeCom mCodeCom = null;
            AdminItemListDao adminItemListDao = null;

            // Variable initialize
            getResult = new FilterDataModel();
            mCodeCom = new MCodeCom();
            adminItemListDao = new AdminItemListDao();

            // Get data
            var listItems = adminItemListDao.GetListItems(inputObject);

            // Set value
            getResult.ListItems = listItems;

            // Return value
            return getResult;
        }
        #endregion
    }
}