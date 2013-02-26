using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Accepts
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputAcceptModel> ListAccepts { get; set; }
        public string AcceptCount { get; set; }
    }
}