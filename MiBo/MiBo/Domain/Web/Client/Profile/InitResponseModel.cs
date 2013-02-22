using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Profile
{
    public class InitResponseModel : MessageResponse
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public string HasNewsletter { get; set; }
    }
}