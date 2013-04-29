using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.UserList
{
    public class InitDataModel
    {
        public IList<User> ListUsers { get; set; }
        public IList<MCode> ListCity { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
        public IList<MCode> ListGroup { get; set; }
    }
}