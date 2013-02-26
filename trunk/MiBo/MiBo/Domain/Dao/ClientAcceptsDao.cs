using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Dao
{
    public class ClientAcceptsDao : AbstractDao
    {
        public IList<AcceptModel> GetListAccepts(string userName)
        {
            var listAccept = from tbl in EntityManager.Accepts
                             where tbl.ClientCd == userName
                             && tbl.DeleteFlag == false
                             orderby tbl.UpdateDate ascending
                             select tbl;

            var listResult = new List<AcceptModel>();
            AcceptModel acceptModel = null;

            foreach (var obj in listAccept.ToList())
            {
                acceptModel = new AcceptModel();
                DataHelper.CopyObject(obj, acceptModel);
                acceptModel.TotalAmount = acceptModel.AcceptDetails.Where(o => o.DeleteFlag == false).Sum(o => o.DetailAmt);
                listResult.Add(acceptModel);
            }

            return listResult;
        }
    }
}