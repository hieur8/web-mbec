using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Model.Client.Login;

namespace MiBo.Domain.Dao
{
    public class ClientLoginDao : AbstractDao
    {
        public User GetUserInfo(InitDataModel inputObject)
        {
            User result = (from tbl in EntityManager.Users
                           where tbl.UserName == inputObject.UserName && tbl.Password==inputObject.Password && tbl.DeleteFlag == false
                             select tbl).SingleOrDefault<User>();

            return result;
        }
    }
}