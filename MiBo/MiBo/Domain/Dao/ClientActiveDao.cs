using System;
using System.Linq;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Dao
{
    public class ClientActiveDao : AbstractDao
    {
        public void Verify(Guid userCd)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Get data
            var listResult = from tbl in EntityManager.Users
                             where tbl.UserCd == userCd
                             select tbl;
            var entity = listResult.SingleOrDefault();

            var listResultUserGroup = from tbl in EntityManager.UserGroups
                                      where tbl.UserCd == userCd 
                                      && tbl.GroupCd == Logics.GP_USERS
                                      select tbl;
            var entityUserGroup = listResultUserGroup.SingleOrDefault();

            // Set data
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = false;

            entityUserGroup.UpdateDate = currentDate;
            entityUserGroup.DeleteFlag = false;

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}