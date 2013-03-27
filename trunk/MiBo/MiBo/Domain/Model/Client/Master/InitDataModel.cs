using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.Master
{
    public class InitDataModel
    {
        public IList<CartItem> Cart { get; set; }

        public decimal CartCount { get; set; }
        public string Email { get; set; }
        public string ChatYahoo { get; set; }
        public string ChatSkype { get; set; }
        public IList<Category> ListToys { get; set; }
        public IList<Category> ListLearningTools { get; set; }
        public IList<Category> ListBooks { get; set; }
        public IList<Age> ListAge { get; set; }
        public IList<Gender> ListGender { get; set; }
        public IList<Brand> ListBrand { get; set; }
        public IList<Country> ListCountry { get; set; }
    }
}