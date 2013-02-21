using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Client.Register
{
    public class InitDataModel
    {
        public string email { get; set; }
        public string pass { get; set; }
        public bool isSendEmail { get; set; }
        public int StatusFlag { get; set; }  
    }
}