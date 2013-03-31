using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Items
{
    public class InitResponseModel : MessageResponse
    {
        public string Title { get; set; }
        public string DiscountMember { get; set; }
        public string Hotline { get; set; }
        public string ChatYahooIM { get; set; }
        public string ChatSkypeIM { get; set; }
        public string ChatYahooIcon { get; set; }
        public string ChatSkypeIcon { get; set; }
        public PagerResponse<OutputItemModel> ListItems { get; set; }
    }
}