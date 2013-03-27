using System;
using System.Text;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Common.Utils
{
    public class MNumberCom
    {
        private readonly MNumberComDao _comDao;
        public MNumberCom() { _comDao = new MNumberComDao(); }

        /// <summary>
        /// Get max slip no
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>Slip no</returns>
        public decimal GetMaxSlipNo(string code, string year, string month)
        {
            // Check param
            if (DataCheckHelper.IsNull(code)
                || DataCheckHelper.IsNull(year)
                || DataCheckHelper.IsNull(month))
                throw new ParamInvalidException();

            // Get infomation
            var result = _comDao.GetMaxSlipNo(code, year, month);

            //Return value
            return result;
        }

        /// <summary>
        /// Get max slip no
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>Slip no</returns>
        public MNumber GetSingle(string code, string year, string month, decimal slipNo)
        {
            // Check param
            if (DataCheckHelper.IsNull(code)
                || DataCheckHelper.IsNull(year)
                || DataCheckHelper.IsNull(month)
                || DataCheckHelper.IsNull(slipNo))
                throw new ParamInvalidException();

            // Get infomation
            var result = _comDao.GetSingle(code, year, month, slipNo);

            //Return value
            return result;
        }

        public const decimal SLIP_NO_DIGITS = 5;

        /// <summary>
        /// Gen slip no
        /// </summary>
        /// <param name="slipNo">Slip no</param>
        /// <param name="prefix">Prefix slip no</param>
        /// <param name="digits">Number of digits in the slip no</param>
        /// <returns>String slip no</returns>
        public static string GenSlipNo(decimal slipNo, string prefix, decimal digits)
        {
            // Local variable declaration
            var result = String.Empty;
            var lenght = 0;

            // Variable initialize
            lenght = Convert.ToString(slipNo).Length;
            result = Convert.ToString(prefix);
            digits -= lenght;

            // Check
            if (digits <= 0) return result + slipNo;

            // Add string
            for (var i = 0; i < digits; i++)
            {
                result += Decimal.Zero;
            }

            // Return value
            return result + slipNo;
        }

        /// <summary>
        /// Get slip no
        /// </summary>
        /// <param name="target">Code</param>
        /// <returns>Slip no</returns>
        public static string GetSlipNo(string target)
        {
            // Local variable declaration
            MNumber mNumber = null;
            MNumberCom mNumberCom = null;
            StringBuilder prefix = null;
            var result = string.Empty;
            var year = string.Empty;
            var month = string.Empty;
            var slipNo = decimal.Zero;
            var digits = SLIP_NO_DIGITS;

            // Variable initialize
            mNumberCom = new MNumberCom();
            prefix = new StringBuilder();

            // Get system date
            var currentDate = DateTime.Now;

            // Get year & month
            year = Convert.ToString(currentDate.Year).Substring(2);
            month = DataHelper.ToStringWithZero(currentDate.Month);

            // Get info
            slipNo = mNumberCom.GetMaxSlipNo(target, year, month);
            mNumber = mNumberCom.GetSingle(target, year, month, slipNo);

            // Check mNumber
            if (mNumber != null) digits = mNumber.Digits.Value;

            // Get prefix
            prefix.Append(target).Append(year).Append(month);

            // Gen slip no
            result = GenSlipNo(slipNo + decimal.One, prefix.ToString(), digits);

            // Return value
            return result;
        }

        /// <summary>
        /// Convert slip no to MNumber
        /// </summary>
        /// <param name="target">Slip no</param>
        /// <returns>Slip no</returns>
        public static MNumber ToMNumber(string target)
        {
            // Local variable declaration
            MNumber result = null;
            var code = string.Empty;
            var year = string.Empty;
            var month = string.Empty;
            var strSlipNo = string.Empty;
            var slipNo = decimal.Zero;
            var digits = decimal.Zero;
            var notes = string.Empty;

            // Variable initialize
            result = new MNumber();
            strSlipNo = target.Substring(6);

            // Check param
            if (DataCheckHelper.IsNull(target)
                || target.Length < 10)
                throw new ParamInvalidException();

            // Get info
            code = target.Substring(0, 2);
            year = target.Substring(2, 2);
            month = target.Substring(4, 2);
            slipNo = Convert.ToDecimal(strSlipNo);
            digits = strSlipNo.Length;

            // Set value
            result.Code = code;
            result.Year = year;
            result.Month = month;
            result.SlipNo = slipNo;
            result.Digits = digits;
            result.Notes = notes;

            // Return value
            return result;
        }

        /// <summary>
        /// Get slip code
        /// </summary>
        /// <param name="target">Slip no</param>
        /// <returns>Slip code</returns>
        public static string GetSlipCode(string target)
        {
            // Return value
            return ToMNumber(target).Code;
        }

        /// <summary>
        /// Gen viewId
        /// </summary>
        /// <param name="slipNo">SlipNo</param>
        /// <param name="pass">Pass</param>
        /// <returns>String</returns>
        public static string GenViewId(string slipNo, string pass)
        {
            // Check data
            if (DataCheckHelper.IsNull(slipNo))
                throw new ParamInvalidException();

            var num = DataHelper.ConvertInputNumber(slipNo + pass);
            var hex10 = decimal.ToInt64(num.GetValueOrDefault(0));

            // Return value
            return hex10.ToString("x10");
        }
    }
}