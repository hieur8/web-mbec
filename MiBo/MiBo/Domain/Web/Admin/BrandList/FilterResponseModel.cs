using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.BrandList
{
    public class FilterResponseModel : MessageResponse
    {
        public IList<OutputBrandModel> ListBrands { get; set; }
    }
}