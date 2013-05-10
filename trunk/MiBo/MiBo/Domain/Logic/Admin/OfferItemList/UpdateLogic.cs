using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.OfferItemList;
using MiBo.Domain.Web.Admin.OfferItemList;

namespace MiBo.Domain.Logic.Admin.OfferItemList
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
            AdminOfferItemListDao adminOfferItemListDao = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            adminOfferItemListDao = new AdminOfferItemListDao();
            mCodeCom = new MCodeCom();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_OFFERS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            int i = 0;
            foreach (var obj in inputObject.ListOfferItems)
            {
                if (DataCheckHelper.IsNull(obj.OfferItemCd))
                    throw new ExecuteException("E_MSG_00004", string.Format("Mã sản phẩm ({0})", i + 1));
                if (DataCheckHelper.IsNull(obj.OfferItemQtty))
                    throw new ExecuteException("E_MSG_00004", string.Format("Số lượng ({0})", i + 1));
                if (obj.OfferItemQtty <= 0)
                    throw new ExecuteException("E_MSG_00011", "Số lượng");
                var dFlag = DataHelper.ToString(obj.DeleteFlag);
                if (DataCheckHelper.IsNull(obj.DeleteFlag))
                    throw new ExecuteException("E_MSG_00004", string.Format("Dữ liệu ({0})", i + 1));
                if (!mCodeCom.IsExist(Logics.GROUP_DELETE_FLAG, dFlag, false))
                    throw new DataNotExistException(string.Format("Dữ liệu ({0})", i + 1));
                if (!adminOfferItemListDao.IsExistItem(obj.OfferItemCd))
                    throw new DataNotExistException(string.Format("Mã sản phẩm ({0})", i + 1));
                if (!adminOfferItemListDao.IsExistOfferItem(obj.OfferCd, obj.DetailNo))
                    throw new DataNotExistException(string.Format("Sản phẩm tặng ({0})", i + 1));
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
            AdminOfferItemListDao adminOfferItemListDao = null;

            // Variable initialize
            getResult = new UpdateDataModel();
            adminOfferItemListDao = new AdminOfferItemListDao();

            // Update data
            foreach (var obj in inputObject.ListOfferItems)
            {
                adminOfferItemListDao.UpdateOfferItem(obj);
            }
            // Submit data
            adminOfferItemListDao.SubmitChanges();

            // Return value
            return getResult;
        }
        #endregion
    }
}