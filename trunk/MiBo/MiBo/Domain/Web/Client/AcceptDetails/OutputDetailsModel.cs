using System.Collections.Generic;

namespace MiBo.Domain.Web.Client.AcceptDetails
{
    public class OutputDetailsModel
    {
        public string AcceptSlipNo { get; set; }
        public IList<OutputAcceptDetailsModel> ListAcceptDetails { get; set; }
    }
}