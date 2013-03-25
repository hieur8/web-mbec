using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.CategoryList
{
    public class InitDataModel
    {
        public IList<Category> ListCategories { get; set; }
        public IList<MCode> ListCategoryDiv { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}