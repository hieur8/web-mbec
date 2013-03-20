using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Master
{
    public class InitResponseModel : MessageResponse
    {
        public string CartCount { get; set; }
        public string DiscountMember { get; set; }
        public string Hotline { get; set; }
        public string Email { get; set; }
        public string ChatYahoo { get; set; }
        public string ChatSkype { get; set; }
        public IList<OutputCategoryModel> ListToys { get; set; }
        public IList<OutputCategoryModel> ListLearningTools { get; set; }
        public IList<OutputCategoryModel> ListBooks { get; set; }
        public IList<OutputAgeModel> ListAges { get; set; }
        public IList<OutputGenderModel> ListGenders { get; set; }
        public IList<OutputBrandModel> ListBrands { get; set; }
        public IList<OutputCountryModel> ListCountries { get; set; }
    }
}