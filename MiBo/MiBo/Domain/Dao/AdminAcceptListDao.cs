using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Model.Admin.AcceptList;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Dao
{
    public class AdminAcceptListDao : AbstractDao
    {
        public IList<Accept> GetListAccepts()
        {
            // Get value
            var listResult = from tbl in EntityManager.Accepts
                             where tbl.DeleteFlag == false
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<Accept> GetListAccepts(FilterDataModel inputObject)
        {
            // Local variable declaration
            var acceptDateStart = inputObject.AcceptDateStart;
            var acceptDateEnd = inputObject.AcceptDateEnd;
            var deliveryDateStart = inputObject.DeliveryDateStart;
            var deliveryDateEnd = inputObject.DeliveryDateEnd;

            // Check end date
            if(acceptDateEnd.HasValue) acceptDateEnd = acceptDateEnd.Value.AddDays(1);
            if(deliveryDateEnd.HasValue) deliveryDateEnd = deliveryDateEnd.Value.AddDays(1);

            // Get value
            var listResult = from tbl in EntityManager.Accepts
                             where (tbl.SlipStatus == inputObject.SlipStatus || DataCheckHelper.IsNull(inputObject.SlipStatus))
                             && (tbl.AcceptSlipNo.CompareTo(inputObject.SlipNoStart) >= 0 || DataCheckHelper.IsNull(inputObject.SlipNoStart))
                             && (tbl.AcceptSlipNo.CompareTo(inputObject.SlipNoEnd) < 0 || DataCheckHelper.IsNull(inputObject.SlipNoEnd))
                             && (tbl.AcceptDate >= acceptDateStart || DataCheckHelper.IsNull(acceptDateStart))
                             && (tbl.AcceptDate < acceptDateEnd || DataCheckHelper.IsNull(acceptDateEnd))
                             && (tbl.DeliveryDate >= deliveryDateStart || DataCheckHelper.IsNull(deliveryDateStart))
                             && (tbl.DeliveryDate < deliveryDateEnd || DataCheckHelper.IsNull(deliveryDateEnd))
                             && (tbl.ClientCd.Contains(inputObject.ClientCd) || DataCheckHelper.IsNull(inputObject.ClientCd))
                             && (tbl.ClientName.Contains(inputObject.ClientName) || DataCheckHelper.IsNull(inputObject.ClientName))
                             && (tbl.AcceptDetails.Any(sub => sub.ItemCd.Contains(inputObject.ItemCd)) || DataCheckHelper.IsNull(inputObject.ItemCd))
                             && (tbl.AcceptDetails.Any(sub => sub.ItemName.Contains(inputObject.ItemName)) || DataCheckHelper.IsNull(inputObject.ItemName))
                             && tbl.DeleteFlag == false
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }
    }
}