using System.Collections.Generic;
using System.Linq;
using System;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Common.Dao
{
    public class StorageFileComDao : AbstractDao
    {
        /// <summary>
        /// Check exist file
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="fileNo">FileNo</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string fileId, decimal fileNo, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.StorageFiles
                         where tbl.FileId == fileId && tbl.FileNo == fileNo
                         && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }

        /// <summary>
        /// Get single file
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="fileNo">FileNo</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>File</returns>
        public StorageFile GetSingle(string fileId, decimal fileNo, bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.StorageFiles
                             where tbl.FileId == fileId && tbl.FileNo == fileNo
                             && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                             select tbl;

            return listResult.SingleOrDefault();
        }

        /// <summary>
        /// Get all files
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List files</returns>
        public IList<StorageFile> GetList(string fileId, bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.StorageFiles
                             where tbl.FileId == fileId
                                   && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                             orderby tbl.SortKey descending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Get max file no
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <returns>File no</returns>
        public decimal GetMaxFileNo(string fileId)
        {
            var result = from tbl in EntityManager.StorageFiles
                             where tbl.FileId == fileId
                             select tbl.FileNo;

            var count = result.LongCount();

            return count > 0 ? result.Max() : decimal.Zero;
        }

        /// <summary>
        /// Get all files
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="ActiveFlag">ActiveFlag</param>
        /// <returns>List files</returns>
        public IList<StorageFile> GetListActive(string fileId, bool activeFlag)
        {
            var listResult = from tbl in EntityManager.StorageFiles
                             where tbl.FileId == fileId
                                   && tbl.ActiveFlag == activeFlag
                                   && tbl.DeleteFlag == false
                             orderby tbl.SortKey descending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void DeleteLogical(StorageFile param, bool ignoreDeleteFlag)
        {
            // Get entity
            var entity = GetSingle(param.FileId, param.FileNo, ignoreDeleteFlag);

            // Set value
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = DateTime.Now;
            entity.DeleteFlag = true;
        }

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="param">StorageFile</param>
        public void Insert(StorageFile param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new StorageFile();
            entity.FileId = param.FileId;
            entity.FileNo = param.FileNo;
            entity.FileName = param.FileName;
            entity.FileGroup = param.FileGroup;
            entity.SortKey = param.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;

            entity.ActiveFlag = false;
            entity.DeleteFlag = false;

            EntityManager.StorageFiles.InsertOnSubmit(entity);
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void UpdateActiveFlag(StorageFile param, bool ignoreDeleteFlag)
        {
            // Get entity
            var entity = GetSingle(param.FileId, param.FileNo, ignoreDeleteFlag);

            // Set value
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = DateTime.Now;
            entity.ActiveFlag = param.ActiveFlag;
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void UpdateSortKey(StorageFile param, bool ignoreDeleteFlag)
        {
            // Get entity
            var entity = GetSingle(param.FileId, param.FileNo, ignoreDeleteFlag);

            // Set value
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = DateTime.Now;
            entity.SortKey = param.SortKey;
        }
    }
}