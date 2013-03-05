using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.Master
{
    public class InitDataModel
    {
        public IList<CartItem> Cart { get; set; }

        public decimal CartCount { get; set; }
        public decimal? DiscountMember { get; set; }
        public IList<Category> ListToys { get; set; }
        public IList<Category> ListAccessories { get; set; }
        public IList<MCode> ListCategory { get; set; }
        public IList<MCode> ListAge { get; set; }
        public IList<MCode> ListGender { get; set; }
        public IList<MCode> ListBrand { get; set; }
        public IList<MCode> ListPriceDiv { get; set; }
    }
}