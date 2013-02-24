using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Client.Profile
{
    public class InitDataModel
    {
        public User User { get; set; }
        public bool HasChangePassword { get; set; }
    }
}