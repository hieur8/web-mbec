using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Utils
{
    public class StorageFileCom
    {
        private readonly StorageFileComDao _comDao;
        public StorageFileCom() { _comDao = new StorageFileComDao(); }

        /// <summary>
        /// Check exist file
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="fileNo">FileNo</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string fileId, decimal fileNo, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            var result = true;

            // Check param
            if (DataCheckHelper.IsNull(fileId)
                || DataCheckHelper.IsNull(fileNo))
                throw new ParamInvalidException();

            // Get infomation
            result = _comDao.IsExist(fileId, fileNo, ignoreDeleteFlag);

            //Return value
            return result;
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
            // Local variable declaration
            StorageFile result = null;

            // Check param
            if (DataCheckHelper.IsNull(fileId)
                || DataCheckHelper.IsNull(fileNo))
                throw new ParamInvalidException();

            // Get infomation
            result = _comDao.GetSingle(fileId, fileNo, ignoreDeleteFlag);

            // Return value
            return result;
        }

        /// <summary>
        /// Get all files
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List files</returns>
        public IList<StorageFile> GetList(string fileId, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            IList<StorageFile> resultList = null;

            // Check param
            if (DataCheckHelper.IsNull(fileId))
                throw new ParamInvalidException();

            // Get infomation
            resultList = _comDao.GetList(fileId, ignoreDeleteFlag);

            // Return value
            return resultList;
        }

        /// <summary>
        /// Check exist file
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="ActiveFlag">ActiveFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string fileId, bool activeFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(fileId))
                throw new ParamInvalidException();

            // Get infomation
            var listResult = _comDao.GetListActive(fileId, activeFlag);

            // Check null
            if (DataCheckHelper.IsNull(listResult))
                return false;

            //Return value
            return true;
        }

        /// <summary>
        /// Get single file
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="ActiveFlag">activeFlag</param>
        /// <returns>File</returns>
        public StorageFile GetSingle(string fileId, bool activeFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(fileId))
                throw new ParamInvalidException();

            // Get infomation
            var listResult = _comDao.GetListActive(fileId, activeFlag);

            // Check null
            if (DataCheckHelper.IsNull(listResult))
                return null;

            // Return value
            return listResult[0];
        }

        /// <summary>
        /// Get all files
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <param name="activeFlag">ActiveFlag</param>
        /// <returns>List files</returns>
        public IList<StorageFile> GetListActive(string fileId, bool activeFlag)
        {
            // Local variable declaration
            IList<StorageFile> resultList = null;

            // Check param
            if (DataCheckHelper.IsNull(fileId))
                throw new ParamInvalidException();

            // Get infomation
            resultList = _comDao.GetListActive(fileId, activeFlag);

            // Return value
            return resultList;
        }

        /// <summary>
        /// Get max file no
        /// </summary>
        /// <param name="fileId">FileId</param>
        /// <returns>File no</returns>
        public decimal GetMaxFileNo(string fileId)
        {
            // Check param
            if (DataCheckHelper.IsNull(fileId))
                throw new ParamInvalidException();

            // Get infomation
            var result = _comDao.GetMaxFileNo(fileId);

            // Return value
            return result;
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void DeleteLogical(StorageFile entity, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(entity.FileId)
                || DataCheckHelper.IsNull(entity.FileNo))
                throw new ParamInvalidException();

            //Update value
            _comDao.DeleteLogical(entity, ignoreDeleteFlag);
        }

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="param">StorageFile</param>
        public void Insert(StorageFile param)
        {
            // Check param
            if (DataCheckHelper.IsNull(param.FileId)
                || DataCheckHelper.IsNull(param.FileNo)
                || DataCheckHelper.IsNull(param.FileName)
                || DataCheckHelper.IsNull(param.FileGroup))
                throw new ParamInvalidException();

            //Insert value
            _comDao.Insert(param);
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void UpdateActiveFlag(StorageFile entity, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(entity.FileId)
                || DataCheckHelper.IsNull(entity.FileNo))
                throw new ParamInvalidException();

            //Update value
            _comDao.UpdateActiveFlag(entity, ignoreDeleteFlag);
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void UpdateSortKey(StorageFile entity, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(entity.FileId)
                || DataCheckHelper.IsNull(entity.FileNo))
                throw new ParamInvalidException();

            //Update value
            _comDao.UpdateSortKey(entity, ignoreDeleteFlag);
        }

        /// <summary>
        /// Computes the set of modified objects to be inserted, updated, or deleted,
        ///     and executes the appropriate commands to implement the changes to the database.
        /// </summary>
        public void SubmitChanges()
        {
            _comDao.SubmitChanges();
        }

        public static Dictionary<string, IList<ImageSizeModel>> MapImageSize
            = new Dictionary<string, IList<ImageSizeModel>>() 
        {
            {"items", new List<ImageSizeModel>() {
                new ImageSizeModel("small", 60, 60),
                new ImageSizeModel("normal", 170, 170),
                new ImageSizeModel("larger", 400, 400)}}
        };
    }
}