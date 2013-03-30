using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MiBo.Domain.Common.Helper
{
    public static class DataCheckHelper
    {
        /// <summary>
        /// Check required input (Guid).
        /// </summary>
        /// <param name="data">Guid</param>
        /// <returns>True/False</returns>
        public static bool IsNull(Guid data)
        {
            return (data == Guid.Empty);
        }

        /// <summary>
        /// Check required input (String).
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>True/False</returns>
        public static bool IsNull(string data)
        {
            return string.IsNullOrWhiteSpace(data);
        }

        /// <summary>
        /// Check required input (DateTime).
        /// </summary>
        /// <param name="data">DateTime?</param>
        /// <returns>True/False</returns>
        public static bool IsNull(DateTime? data)
        {
            return (data == null || data.HasValue == false);
        }

        /// <summary>
        /// Check required input (Decimal).
        /// </summary>
        /// <param name="data">DateTime?</param>
        /// <returns>True/False</returns>
        public static bool IsNull(decimal? data)
        {
            return (data == null || data.HasValue == false);
        }

        /// <summary>
        /// Check required input (Boolean).
        /// </summary>
        /// <param name="data">Boolean?</param>
        /// <returns>True/False</returns>
        public static bool IsNull(bool? data)
        {
            return (data == null || data.HasValue == false);
        }

        /// <summary>
        /// Check required input (Stream).
        /// </summary>
        /// <param name="data">Stream</param>
        /// <returns>True/False</returns>
        public static bool IsNull(Stream data)
        {
            return (data == null || data == Stream.Null);
        }

        /// <summary>
        /// Check required input (ICollection).
        /// </summary>
        /// <param name="data">ICollection</param>
        /// <returns>True/False</returns>
        public static bool IsNull(ICollection data)
        {
            return (data == null || data.Count <= 0);
        }

        /// <summary>
        /// Check required input (ICollection Generic).
        /// </summary>
        /// <param name="data">ICollection</param>
        /// <returns>True/False</returns>
        public static bool IsNull<T>(ICollection<T> data)
        {
            return (data == null || data.Count <= 0);
        }

        /// <summary>
        /// Check valid guid.
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>True/False</returns>
        public static bool IsGuid(string data)
        {
            // Local variable declaration
            var temp = Guid.Empty;

            // Check
            var tryParse = Guid.TryParse(data, out temp);

            // Return value
            return tryParse;
        }

        /// <summary>
        /// Check valid date.
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>True/False</returns>
        public static bool IsDate(string data)
        {
            // Local variable declaration
            var temp = DateTime.MinValue;

            // Check
            var tryParse = DateTime.TryParse(data, out temp);

            // Return value
            return tryParse;
        }

        /// <summary>
        /// Check valid number.
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>True/False</returns>
        public static bool IsNumber(string data)
        {
            // Local variable declaration
            var temp = decimal.Zero;

            // Check
            var tryParse = decimal.TryParse(data, out temp);

            // Return value
            return tryParse;
        }

        /// <summary>
        /// Check valid email.
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>True/False</returns>
        public static bool IsEmail(string data)
        {
            // Local variable declaration
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            // Return value
            return regex.IsMatch(data);
        }
    }
}