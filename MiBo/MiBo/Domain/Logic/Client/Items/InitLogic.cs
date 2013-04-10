using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Items;
using MiBo.Domain.Web.Client.Items;
using Resources;

namespace MiBo.Domain.Logic.Client.Items
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

            inputObject = PagingHelper.CopyPagerRequest<InitDataModel>(request, inputObject);

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
            PagerResponse<OutputItemModel> listItems = null;
            OutputItemModel item = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listItems = new PagerResponse<OutputItemModel>();

            // Get value
            foreach (var obj in resultObject.ListItems)
            {
                item = new OutputItemModel();

                item.ItemCd = DataHelper.ToString(obj.ItemCd);
                item.ItemName = DataHelper.ToString(obj.ItemName);
                item.ItemImage = DataHelper.ToString(obj.ItemImage);
                item.BrandCd = DataHelper.ToString(obj.BrandCd);
                item.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                item.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                item.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                item.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                item.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                item.SummaryNotes = DataHelper.ToString(obj.SummaryNotes);
                item.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                listItems.Add(item);
            }
            listItems.AllRecordCount = resultObject.ListItems.AllRecordCount;
            listItems.Limit = resultObject.ListItems.Limit;
            listItems.Offset = resultObject.ListItems.Offset;

            // Set value
            responseModel.DiscountMember = DataHelper.ToString(Formats.PERCENT, resultObject.DiscountMember);
            responseModel.Hotline = DataHelper.ToString(resultObject.Hotline);
            responseModel.ChatYahooIM = DataHelper.GetYahooIM(resultObject.ChatYahoo);
            responseModel.ChatYahooIcon = DataHelper.GetYahooIcon(resultObject.ChatYahoo);
            responseModel.Title = DataHelper.ToString(resultObject.Title);
            responseModel.ListItems = listItems;

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
            ClientItemsDao clientItemsDao = null;
            ItemCom itemCom = null;
            MParameterCom mParameterCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientItemsDao = new ClientItemsDao();
            itemCom = new ItemCom();
            mParameterCom = new MParameterCom();

            // Get data
            var listItems = clientItemsDao.GetListItems(inputObject);
            var discountMember = mParameterCom.GetNumber(Logics.PR_DISCOUNT_MEMBER, false);
            var strHotline = mParameterCom.GetString(Logics.PR_HOTLINE, false);
            var strChatYahoo = mParameterCom.GetString(Logics.PR_CHAT_YAHOO, false);
            
            // Title
            var title = string.Empty;
            if (!DataCheckHelper.IsNull(inputObject.SearchText))
                title = "Tìm kiếm";
            else if (!DataCheckHelper.IsNull(inputObject.CategoryCd))
                title = clientItemsDao.GetCategoryName(inputObject.CategoryCd);
            else if (!DataCheckHelper.IsNull(inputObject.BrandCd))
                title = clientItemsDao.GetBrandName(inputObject.BrandCd);
            else if (!DataCheckHelper.IsNull(inputObject.AgeCd))
                title = clientItemsDao.GetAgeName(inputObject.AgeCd);
            else if (!DataCheckHelper.IsNull(inputObject.GenderCd))
                title = clientItemsDao.GetGenderName(inputObject.GenderCd);
            else title = "Tất cả";

            // Set value
            getResult.Title = title;
            getResult.DiscountMember = discountMember;
            getResult.Hotline = strHotline;
            getResult.ChatYahoo = strChatYahoo;
            getResult.ListItems = PagingHelper.GetPagerList(
                itemCom.ToListItemModel(listItems), inputObject);

            // Return value
            return getResult;
        }
        #endregion
    }
}