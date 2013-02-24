using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.ItemDetails
{
    public class InitResponseModel : MessageResponse
    {
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string CategoryCd { get; set; }
        public string CategoryName { get; set; }
        public IList<OutputDetailsModel> Details { get; set; }
    }
}