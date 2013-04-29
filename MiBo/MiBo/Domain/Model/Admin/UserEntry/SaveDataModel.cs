using System;

namespace MiBo.Domain.Model.Admin.UserEntry
{
    public class SaveDataModel
    {
        public string Status { get; set; }
        public Guid UserCd { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string CityCd { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public bool? DeleteFlag { get; set; }
        public string GroupCd { get; set; }
    }
}