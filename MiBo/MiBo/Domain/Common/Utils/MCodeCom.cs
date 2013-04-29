using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Utils
{
    public class MCodeCom
    {
        private readonly MCodeComDao _comDao;
        public MCodeCom() { _comDao = new MCodeComDao(); }

        /// <summary>
        /// Get code name
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">CodeCd</param>
        /// <returns>Code name</returns>
        public string GetCodeName(string codeGroupCd, string codeCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(codeGroupCd)
                || DataCheckHelper.IsNull(codeCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetCodeName(codeGroupCd, codeCd);
        }

        /// <summary>
        /// Get code content
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">CodeCd</param>
        /// <returns>CodeContent</returns>
        public string GetCodeContent(string codeGroupCd, string codeCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(codeGroupCd)
                || DataCheckHelper.IsNull(codeCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetCodeContent(codeGroupCd, codeCd);
        }

        /// <summary>
        /// Get single master code
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">CodeCd</param>
        /// <returns>Master code</returns>
        public MCode GetSingle(string codeGroupCd, string codeCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(codeGroupCd)
                || DataCheckHelper.IsNull(codeCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetSingle(codeGroupCd, codeCd);
        }


        /// <summary>
        /// Get list code by group
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="skipCodes">SkipCodes</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List code</returns>
        public IList<MCode> GetListCode(string codeGroupCd, string skipCode, bool nullValue, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            string[] skipCodes = null;
            IList<MCode> listItems = null;

            // Variable initialize
            skipCodes = new string[0];
            listItems = new List<MCode>();

            // Check param
            if (DataCheckHelper.IsNull(codeGroupCd))
                throw new ParamInvalidException();
            // Check skipCode
            if (skipCode != null) skipCodes = skipCode.Split(Logics.DELIMITER_SKIP_CODE);
            // Check nullValue
            if (nullValue) listItems.Add(new MCode());
            // Get data
            var codeDiv = _comDao.GetListCode(codeGroupCd, skipCodes, ignoreDeleteFlag);
            // Add information
            foreach (var code in codeDiv)
            {
                listItems.Add(code);
            }

            //Return value
            return listItems;
        }

        /// <summary>
        /// Check exist code
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">CodeCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string codeGroupCd, string codeCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(codeGroupCd)
                || DataCheckHelper.IsNull(codeCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.IsExist(codeGroupCd, codeCd, ignoreDeleteFlag); ;
        }

        /// <summary>
        /// Get skip code
        /// </summary>
        /// <param name="codeCd">CodeCd</param>
        /// <returns>Skip code</returns>
        public string GetSkipCode(string codeCd)
        {
            // Local variable declaration
            string result = null;

            // Get information
            result = GetCodeName(Logics.GROUP_SKIP_CODE, codeCd);

            // Return value
            return result;
        }

        /// <summary>
        /// Convert output combo items list
        /// </summary>
        /// <param name="target">List master code</param>
        /// <param name="selectedValue">Selected value</param>
        /// <returns>List ListItem</returns>
        public static ComboModel ToComboItems(IList<MCode> target, string selectedValue)
        {
            // Local variable declaration
            ComboModel comboModel = null;
            IList<ComboItem> listComboItems = null;

            // Variable initialize
            listComboItems = new List<ComboItem>();
            comboModel = new ComboModel();

            // Get data
            var val = string.Empty;
            foreach (var obj in target)
            {
                var combo = new ComboItem();
                combo.Code = DataHelper.ToString(obj.CodeCd);
                combo.Name = DataHelper.ToString(obj.CodeName);
                if (combo.Code == selectedValue
                    || (DataCheckHelper.IsNull(selectedValue) && target.IndexOf(obj) == 0))
                    val = combo.Code;
                listComboItems.Add(combo);
            }

            // Set value
            comboModel.SeletedValue = val;
            comboModel.ListItems = listComboItems;

            return comboModel;
        }

        /// <summary>
        /// Get list category
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List category</returns>
        public IList<MCode> GetListCategory(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListCategory(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.CategoryCd;
                code.CodeName = obj.CategoryName;
                listResult.Add(code);
            }
            return listResult;
        }

        /// <summary>
        /// Get list age
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List age</returns>
        public IList<MCode> GetListAge(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListAge(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.AgeCd;
                code.CodeName = obj.AgeName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list gender
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List gender</returns>
        public IList<MCode> GetListGender(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListGender(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.GenderCd;
                code.CodeName = obj.GenderName;
                listResult.Add(code);
            }
            return listResult;
        }

        /// <summary>
        /// Get list brand
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List brand</returns>
        public IList<MCode> GetListBrand(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListBrand(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.BrandCd;
                code.CodeName = obj.BrandName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list country
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List country</returns>
        public IList<MCode> GetListCountry(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListCountry(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.CountryCd;
                code.CodeName = obj.CountryName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list unit
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List unit</returns>
        public IList<MCode> GetListUnit(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListUnit(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.UnitCd;
                code.CodeName = obj.UnitName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list role
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List role</returns>
        public IList<MCode> GetListRole(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListRole(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.RoleCd;
                code.CodeName = obj.RoleName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list group
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List group</returns>
        public IList<MCode> GetListGroup(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListGroup(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.GroupCd;
                code.CodeName = obj.GroupName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list city
        /// </summary>
        /// <param name="nullValue">NullValue</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List city</returns>
        public IList<MCode> GetListCity(bool nullValue, bool ignoreDeleteFlag)
        {
            var data = _comDao.GetListCity(ignoreDeleteFlag);
            var listResult = new List<MCode>();
            var code = new MCode();
            if (nullValue) listResult.Add(code);
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.CityCd;
                code.CodeName = obj.CityName;
                listResult.Add(code);
            }

            return listResult;
        }

        /// <summary>
        /// Get list city
        /// </summary>
        /// <returns>List city</returns>
        public IList<MCode> GetListCity()
        {
            var data = _comDao.GetListCity(false);
            var listResult = new List<MCode>();
            var code = new MCode();
            foreach (var obj in data)
            {
                code = new MCode();
                code.CodeCd = obj.CityCd;
                code.CodeName = obj.CityName;
                listResult.Add(code);
            }

            return listResult;
        }
    }
}