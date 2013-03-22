using System.Collections.Generic;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Web.Client.ItemDetails
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputDetailsModel> Details { get; set; }
        public IList<MiBo.Domain.Web.Client.Index.OutputItemModel> lstItem { get; set; }
    }
}