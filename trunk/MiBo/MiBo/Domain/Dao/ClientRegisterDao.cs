using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Client.Register;

namespace MiBo.Domain.Dao
{
    public class ClientRegisterDao : AbstractDao
    {
        public void Insert(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set data
            var entity = new User();
            entity.UserCd = inputObject.UserCd;
            entity.Email = inputObject.Email;
            entity.FullName = inputObject.Fullname;
            entity.Password = DataHelper.GetMd5Hash(inputObject.Password);
            entity.Address = inputObject.Address;
            entity.Phone1 = inputObject.Phone1;
            entity.Phone2 = inputObject.Phone2;
            entity.CityCd = inputObject.CityCd;
            entity.HasNewsletter = false;
            entity.CreateUser = inputObject.Email;
            entity.CreateDate = currentDate;
            entity.UpdateUser = inputObject.Email;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = true;

            EntityManager.Users.InsertOnSubmit(entity);

            
        }
    }
}