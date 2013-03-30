using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.UploadImage
{
    public class InitDataModel
    {
        public string FileId { get; set; }
        public string FileGroup { get; set; }
        public IList<StorageFile> ListFiles { get; set; }
    }
}