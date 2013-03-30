using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Items
{
    public class InitResponseModel : MessageResponse
    {
        public string CategoryCd { get; set; }
        public string CategoryName { get; set; }
        public PagerResponse<OutputItemModel> ListItems { get; set; }
    }
}