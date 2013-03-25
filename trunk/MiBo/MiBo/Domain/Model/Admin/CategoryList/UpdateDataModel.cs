using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.CategoryList
{
    public class UpdateDataModel
    {
        public IList<Category> ListCategories { get; set; }
    }
}