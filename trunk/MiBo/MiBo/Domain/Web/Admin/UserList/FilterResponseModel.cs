using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.UserList
{
    public class FilterResponseModel : MessageResponse
    {
        public IList<OutputUserModel> ListUsers { get; set; }
    }
}