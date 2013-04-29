namespace MiBo.Domain.Web.Admin.UserList
{
    public class OutputUserModel
    {
        public string UserCd { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string CityCd { get; set; }
        public string CityName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string UpdateDate { get; set; }
        public string DeleteFlag { get; set; }
        public string DeleteFlagName { get; set; }
        public string GroupCd { get; set; }
        public string GroupName { get; set; }
    }
}