using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiBo.Domain.Web.Client.Register
{
    public class OutputEmailModel
    {
        public string UserCd { get; set; }
        public string FullName { get; set; }
        public string Hotline { get; set; }
        public string EmailSupport { get; set; }
        public string ChatYahoo { get; set; }
    }
}