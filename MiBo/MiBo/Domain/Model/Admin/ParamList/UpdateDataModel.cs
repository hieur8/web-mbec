using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.ParamList
{
    public class UpdateDataModel
    {
        public IList<MParameter> ListParams { get; set; }
    }
}