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
            entity.UserCd = Guid.NewGuid();
            entity.Email = inputObject.Email;
            entity.FullName = inputObject.Fullname;
            entity.Password = DataHelper.GetMd5Hash(inputObject.Password);
            entity.HasNewsletter = false;
            entity.CreateUser = inputObject.Email;
            entity.CreateDate = currentDate;
            entity.UpdateUser = inputObject.Email;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = true;

            EntityManager.Users.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}