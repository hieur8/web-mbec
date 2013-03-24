using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            // Set data
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = false;

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}