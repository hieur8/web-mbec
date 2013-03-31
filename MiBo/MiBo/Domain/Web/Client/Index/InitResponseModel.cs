using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Index
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputBannerModel> ListBanners { get; set; }
        public IList<OutputItemModel> ListNewItems { get; set; }
        public IList<OutputItemModel> ListHotItems { get; set; }
        public IList<OutputItemModel> ListOfferItems { get; set; }
        public string DiscountMember { get; set; }
        public string Hotline { get; set; }
        public string ChatYahooIM { get; set; }
        public string ChatSkypeIM { get; set; }
        public string ChatYahooIcon { get; set; }
        public string ChatSkypeIcon { get; set; }
    }
}