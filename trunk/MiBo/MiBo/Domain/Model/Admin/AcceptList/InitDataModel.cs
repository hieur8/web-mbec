using System;
using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.AcceptList
{
    public class InitDataModel
    {
        public IList<Accept> ListAccepts { get; set; }
        public IList<MCode> ListSlipStatus { get; set; }
        public DateTime AcceptDateStart { get; set; }
        public DateTime AcceptDateEnd { get; set; }
    }
}