using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.UserEntry
{
    public class OutputDetailsModel
    {
        public string Password { get; set; }
        public string Status { get; set; }
        public string UserCd { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string CityCd { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string DeleteFlag { get; set; }
        public string GroupCd { get; set; }
        public IList<ComboItem> ListCity { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public IList<ComboItem> ListGroup { get; set; }
    }
}