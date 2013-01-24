using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;

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
        /// <param name="selectedIndex">Selected index</param>
        /// <returns>List ListItem</returns>
        public static ListItem[] ToComboItems(IList<MCode> target, int selectedIndex)
        {
            // Local variable declaration
            IList<ListItem> listComboItems = null;

            // Variable initialize
            listComboItems = new List<ListItem>();

            foreach (var item in target)
            {
                var combo = new ListItem();
                combo.Value = DataHelper.ToString(item.CodeCd);
                combo.Text = DataHelper.ToString(item.CodeName);
                if (target.IndexOf(item) == selectedIndex)
                    combo.Selected = true;
                listComboItems.Add(combo);
            }

            return listComboItems.ToArray();
        }
    }
}