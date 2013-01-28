using System.Collections.Generic;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Master;
using MiBo.Domain.Web.Client.Master;

namespace MiBo.Domain.Logic.Client.Master
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
            foreach (var obj in resultObject.ListCategories)
            {
                category = new OutputCategoryModel();

                category.CategoryCd = DataHelper.ToString(obj.CategoryCd);
                category.CategoryName = DataHelper.ToString(obj.CategoryName);

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

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
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
            ClientMasterDao clientMasterDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientMasterDao = new ClientMasterDao();

            // Get data
            var listCategories = clientMasterDao.GetListCategories();

            // Set value
            getResult.ListCategories = listCategories;

            // Return value
            return getResult;
        }
        #endregion
    }
}