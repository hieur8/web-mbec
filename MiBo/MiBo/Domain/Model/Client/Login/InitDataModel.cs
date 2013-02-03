using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Client.Login
{
    public class InitDataModel
    {
        public bool StatusFlag { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}