using System;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Client.Profile;

namespace MiBo.Domain.Dao
{
    public class ClientProfileDao : AbstractDao
    {
        public void UpdateUser(SaveDataModel inputObject)
        {
            // Get LinQ
            var result = from tbl in EntityManager.Users
                         where tbl.UserCd == PageHelper.UserCd
                         && tbl.DeleteFlag == false
                         select tbl;
            var resultSub = from tbl in EntityManager.Newsletters
                                where tbl.Email == PageHelper.UserName
                                select tbl;

            // Get entity
            var entity = result.SingleOrDefault();
            var entitySub = resultSub.SingleOrDefault();

            // Get system date
            var currentDate = DateTime.Now;

            // Setting value
            entity.FullName = inputObject.FullName;
            entity.Address = inputObject.Address;
            entity.HasNewsletter = inputObject.HasNewsletter;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;

            if (inputObject.HasChagngePassword)
                entity.Password = inputObject.NewPassword;

            if (inputObject.HasNewsletter)
            {
                if (entitySub == null)
                {
                    entitySub = new Newsletter();
                    entitySub.Email = PageHelper.UserName;
                    entitySub.CreateUser = PageHelper.UserName;
                    entitySub.CreateDate = currentDate;
                    entitySub.UpdateUser = PageHelper.UserName;
                    entitySub.UpdateDate = currentDate;
                    entitySub.DeleteFlag = false;
                    EntityManager.Newsletters.InsertOnSubmit(entitySub);
                }
                else
                {
                    entitySub.UpdateUser = PageHelper.UserName;
                    entitySub.UpdateDate = currentDate;
                    entitySub.DeleteFlag = false;
                }
            }
            else
            {
                if(entitySub != null)
                    entitySub.DeleteFlag = true;
            }

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}