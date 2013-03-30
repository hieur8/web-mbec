using System.Collections.Generic;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Index;
using MiBo.Domain.Web.Client.Index;
using Resources;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Logic.Client.Index
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
            IList<OutputBannerModel> listBanners = null;
            IList<OutputItemModel> listNewItems = null;
            IList<OutputItemModel> listHotItems = null;
            IList<OutputItemModel> listOfferItems = null;
            OutputBannerModel banner = null;
            OutputItemModel newItem = null;
            OutputItemModel hotItem = null;
            OutputItemModel offerItem = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listBanners = new List<OutputBannerModel>();
            listNewItems = new List<OutputItemModel>();
            listHotItems = new List<OutputItemModel>();
            listOfferItems = new List<OutputItemModel>();

            // Get value
            foreach (var obj in resultObject.ListBanners)
            {
                banner = new OutputBannerModel();

                banner.BannerCd = DataHelper.ToString(obj.BannerCd);
                banner.BannerName = DataHelper.ToString(obj.BannerName);
                banner.Image = DataHelper.ToString(obj.FileId);

                listBanners.Add(banner);
            }

            foreach (var obj in resultObject.ListNewItems)
            {
                newItem = new OutputItemModel();
                newItem.ItemCd = DataHelper.ToString(obj.ItemCd);
                newItem.ItemName = DataHelper.ToString(obj.ItemName);
                newItem.ItemImage = DataHelper.ToString(obj.ItemImage);
                newItem.BrandCd = DataHelper.ToString(obj.BrandCd);
                newItem.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                newItem.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                newItem.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                newItem.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                newItem.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                newItem.Notes = DataHelper.ToString(obj.Notes);

                listNewItems.Add(newItem);
            }

            foreach (var obj in resultObject.ListHotItems)
            {
                hotItem = new OutputItemModel();

                hotItem.ItemCd = DataHelper.ToString(obj.ItemCd);
                hotItem.ItemName = DataHelper.ToString(obj.ItemName);
                hotItem.ItemImage = DataHelper.ToString(obj.ItemImage);
                hotItem.BrandCd = DataHelper.ToString(obj.BrandCd);
                hotItem.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                hotItem.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                hotItem.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                hotItem.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                hotItem.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                hotItem.Notes = DataHelper.ToString(obj.Notes);

                listHotItems.Add(hotItem);
            }

            foreach (var obj in resultObject.ListOfferItems)
            {
                offerItem = new OutputItemModel();

                offerItem.ItemCd = DataHelper.ToString(obj.ItemCd);
                offerItem.ItemName = DataHelper.ToString(obj.ItemName);
                offerItem.ItemImage = DataHelper.ToString(obj.ItemImage);
                offerItem.BrandCd = DataHelper.ToString(obj.BrandCd);
                offerItem.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                offerItem.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                offerItem.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                offerItem.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                offerItem.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                offerItem.Notes = DataHelper.ToString(obj.Notes);

                listOfferItems.Add(offerItem);
            }

            // Set value
            responseModel.DiscountMember = DataHelper.ToString(Formats.PERCENT, resultObject.DiscountMember);
            responseModel.Hotline = DataHelper.ToString(resultObject.Hotline);
            responseModel.ChatYahoo = DataHelper.ToString(resultObject.ChatYahoo);
            responseModel.ChatSkype = DataHelper.ToString(resultObject.ChatSkype);
            responseModel.ListBanners = listBanners;
            responseModel.ListNewItems = listNewItems;
            responseModel.ListHotItems = listHotItems;
            responseModel.ListOfferItems = listOfferItems;

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
            ClientIndexDao clientIndexDao = null;
            ItemCom itemCom = null;
            MParameterCom mParameterCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientIndexDao = new ClientIndexDao();
            itemCom = new ItemCom();
            mParameterCom = new MParameterCom();

            // Get data
            var listBanners = clientIndexDao.GetListBanners();
            var listNewItems = clientIndexDao.GetListNewItems();
            var listHotItems = clientIndexDao.GetListHotItems();
            var listOfferItems = clientIndexDao.GetListOfferItems();
            var discountMember = mParameterCom.GetNumber(Logics.PR_DISCOUNT_MEMBER, false);
            var strHotline = mParameterCom.GetString(Logics.PR_HOTLINE, false);
            var strChatYahoo = mParameterCom.GetString(Logics.PR_CHAT_YAHOO, false);
            var strChatSkype = mParameterCom.GetString(Logics.PR_CHAT_SKYPE, false);

            // Set value
            getResult.DiscountMember = discountMember;
            getResult.Hotline = strHotline;
            getResult.ChatYahoo = strChatYahoo;
            getResult.ChatSkype = strChatSkype;
            getResult.ListBanners = listBanners;
            getResult.ListNewItems = itemCom.ToListItemModel(listNewItems);
            getResult.ListHotItems = itemCom.ToListItemModel(listHotItems);
            getResult.ListOfferItems = itemCom.ToListItemModel(listOfferItems);

            // Return value
            return getResult;
        }
        #endregion
    }
}