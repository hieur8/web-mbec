using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Items
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputItemModel> ListItems { get; set; }
    }
}