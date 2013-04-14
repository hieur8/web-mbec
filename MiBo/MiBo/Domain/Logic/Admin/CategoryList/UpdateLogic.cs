using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.CategoryList;
using MiBo.Domain.Web.Admin.CategoryList;

namespace MiBo.Domain.Logic.Admin.CategoryList
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
            AdminCategoryListDao adminCategoryListDao = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            adminCategoryListDao = new AdminCategoryListDao();
            mCodeCom = new MCodeCom();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_CATEGORIES))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            int i = 0;
            foreach (var obj in inputObject.ListCategories)
            {
                var dFlag = DataHelper.ToString(obj.DeleteFlag);
                
                if (DataCheckHelper.IsNull(obj.CategoryName))
                    throw new ExecuteException("E_MSG_00004", string.Format("Tên loại ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.CategoryDiv))
                    throw new ExecuteException("E_MSG_00004", string.Format("Chủng loại ({0})", i + 1));
                if (!mCodeCom.IsExist(Logics.GROUP_CATEGORY_DIV, obj.CategoryDiv, false))
                    throw new DataNotExistException(string.Format("Chủng loại ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.SortKey))
                    throw new ExecuteException("E_MSG_00004", string.Format("Thứ tự ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.DeleteFlag))
                    throw new ExecuteException("E_MSG_00004", string.Format("Dữ liệu ({0})", i + 1));
                if (!mCodeCom.IsExist(Logics.GROUP_DELETE_FLAG, dFlag, false))
                    throw new DataNotExistException(string.Format("Dữ liệu ({0})", i + 1));
                if (!adminCategoryListDao.IsExistCategory(obj.CategoryCd))
                    throw new DataNotExistException(string.Format("Loại sản phẩm ({0})", i + 1));
                i++;
            }
        }

        /// <summary>
        /// Update item to cart
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private UpdateDataModel UpdateInfo(UpdateDataModel inputObject)
        {
            // Local variable declaration
            UpdateDataModel getResult = null;
            AdminCategoryListDao adminCategoryListDao = null;

            // Variable initialize
            getResult = new UpdateDataModel();
            adminCategoryListDao = new AdminCategoryListDao();

            // Update data
            foreach (var obj in inputObject.ListCategories)
            {
                adminCategoryListDao.UpdateCategory(obj);
            }
            // Submit data
            adminCategoryListDao.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}