using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.UserList
{
    public class FilterDataModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string CityCd { get; set; }
        public bool? DeleteFlag { get; set; }
        public string GroupCd { get; set; }

        public IList<User> ListUsers { get; set; }
    }
}