using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.AcceptDetails
{
    public class InitDataModel
    {
        // Request
        public string AcceptSlipNo { get; set; }
        public string ViewId { get; set; }

        // Response
        public AcceptModel Accept { get; set; }
    }
}