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
    }
}