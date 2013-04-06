using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Dao
{
    public class AdminCategoryListDao : AbstractDao
    {
        public IList<Category> GetListCategories()
        {
            // Get value
            var listResult = from tbl in EntityManager.Categories
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public bool IsExistCategory(string categoryCd)
        {
            return IsExist<Category>(categoryCd, true);
        }

        public void UpdateCategory(Category param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<Category>(param.CategoryCd, true);
            entity.CategoryName = param.CategoryName;
            entity.CategorySearchName = param.CategorySearchName;
            entity.CategoryDiv = param.CategoryDiv;
            entity.SortKey = param.SortKey;
            entity.DeleteFlag = param.DeleteFlag;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
        }
    }
}