using System;
using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.UserEntry
{
    public class InitDataModel
    {
        public Guid UserCd { get; set; }

        public User User { get; set; }
        public IList<MCode> ListCity { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
        public IList<MCode> ListGroup { get; set; }
    }
}