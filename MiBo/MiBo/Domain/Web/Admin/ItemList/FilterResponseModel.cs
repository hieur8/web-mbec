using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ItemList
{
    public class FilterResponseModel : MessageResponse
    {
        public IList<OutputItemModel> ListItems { get; set; }
    }
}