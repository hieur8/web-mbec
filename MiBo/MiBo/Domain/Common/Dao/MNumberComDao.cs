using System.Linq;

namespace MiBo.Domain.Common.Dao
{
    public class MNumberComDao : AbstractDao
    {
        public decimal GetMaxSlipNo(string code, string year, string month)
        {
            var result = from tbl in EntityManager.MNumbers
                         where tbl.Code == code && tbl.Year == year
                         && tbl.Month == month
                         select tbl.SlipNo;

            var count = result.LongCount();

            return count > 0 ? result.Max() : decimal.Zero;
        }

        public MNumber GetSingle(string code, string year, string month, decimal slipNo)
        {
            var result = from tbl in EntityManager.MNumbers
                         where tbl.Code == code && tbl.Year == year
                         && tbl.Month == month && tbl.SlipNo == slipNo
                         select tbl;

            return result.SingleOrDefault();
        }
    }
}