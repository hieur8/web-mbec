using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Master
{
    public class InitResponseModel : MessageResponse
    {
        public string CartCount { get; set; }
        public IList<OutputCategoryModel> ListToys { get; set; }
        public IList<OutputCategoryModel> ListAccessories { get; set; }
        public ListItem[] ListCategory { get; set; }
        public ListItem[] ListAge { get; set; }
        public ListItem[] ListGender { get; set; }
        public ListItem[] ListBrand { get; set; }
        public ListItem[] ListPriceDiv { get; set; }
    }
}