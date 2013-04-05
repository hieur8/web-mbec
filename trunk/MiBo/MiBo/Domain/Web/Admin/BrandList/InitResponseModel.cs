using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.BrandList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputBrandModel> ListBrands { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public string DeleteFlag { get; set; }
    }
}