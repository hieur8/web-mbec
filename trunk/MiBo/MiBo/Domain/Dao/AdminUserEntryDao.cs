using System;
using System.Linq;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.UserEntry;

namespace MiBo.Domain.Dao
{
    public class AdminUserEntryDao : AbstractDao
    {
        public bool IsExist(Guid userCd)
        {
            var result = from tbl in EntityManager.Users
                         where tbl.UserCd == userCd
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }

        public User GetSingle(Guid userCd)
        {
            var result = from tbl in EntityManager.Users
                         where tbl.UserCd == userCd
                         select tbl;

            return result.SingleOrDefault();
        }

        public UserGroup GetSingleUserGroup(Guid userCd, string groupCd)
        {
            var result = from tbl in EntityManager.UserGroups
                         where tbl.UserCd == userCd && tbl.GroupCd == groupCd
                         select tbl;

            return result.SingleOrDefault();
        }

        public void Insert(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;
            // Get unique code
            var userCd = Guid.NewGuid();

            // Set data
            var entity = new User();
            entity.UserCd = userCd;
            entity.Email = inputObject.Email;
            entity.FullName = inputObject.FullName;
            entity.Password = DataHelper.GetMd5Hash(Logics.PASSWORD_DEFAULT);
            entity.Address = inputObject.Address;
            entity.Phone1 = inputObject.Phone1;
            entity.Phone2 = inputObject.Phone2;
            entity.CityCd = inputObject.CityCd;
            entity.HasNewsletter = false;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            var entityGroupUser = new UserGroup();
            entityGroupUser.UserCd = userCd;
            entityGroupUser.GroupCd = inputObject.GroupCd;
            entityGroupUser.CreateUser = PageHelper.UserName;
            entityGroupUser.CreateDate = currentDate;
            entityGroupUser.UpdateUser = PageHelper.UserName;
            entityGroupUser.UpdateDate = currentDate;
            entityGroupUser.DeleteFlag = inputObject.DeleteFlag;

            // Insert
            EntityManager.Users.InsertOnSubmit(entity);
            EntityManager.UserGroups.InsertOnSubmit(entityGroupUser);

            // Submit
            EntityManager.SubmitChanges();
        }

        public void Update(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set data
            var entity = GetSingle(inputObject.UserCd);
            entity.Email = inputObject.Email;
            entity.FullName = inputObject.FullName;
            entity.Address = inputObject.Address;
            entity.Phone1 = inputObject.Phone1;
            entity.Phone2 = inputObject.Phone2;
            entity.CityCd = inputObject.CityCd;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            var entityGroupUser = GetSingleUserGroup(inputObject.UserCd, inputObject.GroupCd);
            entityGroupUser.UpdateUser = PageHelper.UserName;
            entityGroupUser.UpdateDate = currentDate;
            entityGroupUser.DeleteFlag = inputObject.DeleteFlag;

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}