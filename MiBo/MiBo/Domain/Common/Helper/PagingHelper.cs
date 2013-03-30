using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Model;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System;

namespace MiBo.Domain.Common.Helper
{
    public static class PagingHelper
    {
        private static Expression<Func<T, object>> GetExpressionSort<T>(string sortBy)
        {
            var type = typeof(T);
            var param = Expression.Parameter(type, "f");
            var exSortBy = Expression.PropertyOrField(param, sortBy);
            var ex = Expression.MakeUnary(ExpressionType.Convert, exSortBy, typeof(object));
            return Expression.Lambda<Func<T, object>>(ex, param);
        }

        private static bool IsSortField<T>(string sortBy)
        {
            var type = typeof(T);
            var allField = type.GetProperties().Select(o => o.Name).ToList();
            return allField.Contains(sortBy);
        }

        public static PagerResult<T> GetPagerList<T>(IList<T> list, PagerModel criteria)
        {
            var result = new PagerResult<T>();
            var limit = 10;
            var offset = 0;

            if (!DataCheckHelper.IsNull(criteria.Limit))
            {
                limit = decimal.ToInt32(criteria.Limit.Value);
                if (limit <= 0) limit = 10;
            }
            if (!DataCheckHelper.IsNull(criteria.Offset))
            {
                offset = decimal.ToInt32(criteria.Offset.Value);
                if (offset <= 0 || offset > list.Count) offset = 0;
            }

            result.AllRecordCount = list.Count;
            result.Limit = limit;
            result.Offset = offset;

            var start = list.Count > offset ? offset : 0;
            var end = list.Count > offset + limit ? offset + limit : list.Count > offset ? list.Count : 0;

            result.AddAll(list.Skip(start).Take(end - start).ToList());

            if (!DataCheckHelper.IsNull(criteria.SortBy))
            {
                if (IsSortField<T>(criteria.SortBy))
                {
                    var ex = GetExpressionSort<T>(criteria.SortBy);
                    if (DataCheckHelper.IsNull(criteria.IsAsc))
                        criteria.IsAsc = true;
                    if (criteria.IsAsc.Value)
                        result.ResultList = result.AsQueryable().OrderBy(ex).ToList();
                    else result.ResultList = result.AsQueryable().OrderByDescending(ex).ToList();
                }
            }

            return result;
        }

        public static T CopyPagerRequest<T>(PagerRequest request, PagerModel criteria)
        {
            criteria.Limit = DataHelper.ConvertInputNumber(request.Limit);
            criteria.Offset = DataHelper.ConvertInputNumber(request.Offset);
            criteria.SortBy = DataHelper.ConvertInputString(request.SortBy);

            if (!DataCheckHelper.IsNull(criteria.SortBy))
                criteria.IsAsc = DataHelper.ConvertInputBoolean(request.IsAsc);

            return DataHelper.AutoCast<T>(criteria);
        }

        public static T CopyPagerModel<T>(PagerModel model, PagerModel criteria)
        {
            criteria.Limit = model.Limit;
            criteria.Offset = model.Offset;
            criteria.SortBy = model.SortBy;
            criteria.IsAsc = model.IsAsc;

            return DataHelper.AutoCast<T>(criteria);
        }
    }
}