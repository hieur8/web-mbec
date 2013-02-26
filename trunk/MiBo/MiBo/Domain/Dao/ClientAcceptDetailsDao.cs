using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Model.Client.AcceptDetails;

namespace MiBo.Domain.Dao
{
    public class ClientAcceptDetailsDao : AbstractDao
    {
        public AcceptModel GetAccept(InitDataModel inputObject)
        {
            var result = from tbl in EntityManager.Accepts
                         where ((tbl.AcceptSlipNo == inputObject.AcceptSlipNo
                         && tbl.ClientCd == PageHelper.UserName)
                         || tbl.ViewId == inputObject.ViewId)
                         && tbl.DeleteFlag == false
                         select tbl;

            var acceptModel = new AcceptModel();

            DataHelper.CopyObject(result.SingleOrDefault(), acceptModel);
            acceptModel.TotalAmount = acceptModel.AcceptDetails.Where(o => o.DeleteFlag == false).Sum(o => o.DetailAmt);

            return acceptModel;
        }

        public bool IsExistAccept(InitDataModel inputObject)
        {
            var result = from tbl in EntityManager.Accepts
                         where ((tbl.AcceptSlipNo == inputObject.AcceptSlipNo
                         && tbl.ClientCd == PageHelper.UserName)
                         || tbl.ViewId == inputObject.ViewId)
                         && tbl.DeleteFlag == false
                         select tbl;

            var count = result.LongCount();

            return count >= decimal.One;
        }
    }
}