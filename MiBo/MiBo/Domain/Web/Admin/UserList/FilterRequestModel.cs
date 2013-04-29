namespace MiBo.Domain.Web.Admin.UserList
{
    public class FilterRequestModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string CityCd { get; set; }
        public string DeleteFlag { get; set; }
        public string GroupCd { get; set; }
    }
}