using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Master
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputCategoryModel> ListCategories { get; set; }
    }
}