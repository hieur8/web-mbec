using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Register
{
    public class RegisterResponseModel : MessageResponse
    {
        //0 : thanh cong , 1 : that bai, 2 username da ton tai
        public int StatusFlag { get; set; }    
    }
}