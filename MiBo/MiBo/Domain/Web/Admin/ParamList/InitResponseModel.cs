using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ParamList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputParamModel> ListParams { get; set; }
    }
}