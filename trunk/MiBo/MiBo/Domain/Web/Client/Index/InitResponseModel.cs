using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Index
{
    public class InitResponseModel : MessageResponse
    {
        public IList<ItemOutputModel> ListNewItems { get; set; }
    }
}