using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ItemList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputItemModel> ListItems { get; set; }
        public ListItem[] ListCategory { get; set; }
        public ListItem[] ListAge { get; set; }
        public ListItem[] ListGender { get; set; }
        public ListItem[] ListBrand { get; set; }
        public ListItem[] ListCountry { get; set; }
        public ListItem[] ListUnit { get; set; }
        public ListItem[] ListItemDiv { get; set; }
        public ListItem[] ListDeleteFlag { get; set; }
    }
}