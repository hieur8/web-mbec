using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.UserList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputUserModel> ListUsers { get; set; }
        public IList<ComboItem> ListGroup { get; set; }
        public string GroupCd { get; set; }
        public IList<ComboItem> ListCity { get; set; }
        public string CityCd { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public string DeleteFlag { get; set; }
    }
}