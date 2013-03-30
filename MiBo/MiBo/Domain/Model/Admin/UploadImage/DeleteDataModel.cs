using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.UploadImage
{
    public class DeleteDataModel
    {
        public IList<StorageFile> ListFiles { get; set; }
    }
}