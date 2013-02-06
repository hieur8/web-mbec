using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Resources;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Helper
{
    public static class DataHelper
    {
        /// <summary>
        /// Join string array with delimiter
        /// </summary>
        /// <param name="data">Array string</param>
        /// <param name="delimiter">delimiter</param>
        /// <returns>String</returns>
        public static string JoinStringArray(string[] data, string delimiter)
        {
            var result = new StringBuilder();
            foreach (var s in data)
            {
                if (!DataCheckHelper.IsNull(result.ToString()))
                    result.Append(delimiter);

                result.Append(s);
            }
            return result.ToString();
        }

        /// <summary>
        /// Trim string
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>String</returns>
        public static string Trim(string data)
        {
            return data.Trim();
        }

        /// <summary>
        /// Convert string to string
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>String</returns>
        public static string ToString(string data)
        {
            return (DataCheckHelper.IsNull(data)) ? string.Empty : data;
        }

        /// <summary>
        /// Convert object to string
        /// </summary>
        /// <param name="data">Object</param>
        /// <returns>String</returns>
        public static string ToString(object data)
        {
            return data == null ? string.Empty : data.ToString();
        }

        /// <summary>
        /// Convert guid to string
        /// </summary>
        /// <param name="data">Guid</param>
        /// <returns>String</returns>
        public static string ToString(Guid data)
        {
            return Convert.ToString(data);
        }

        /// <summary>
        /// Replace string ("\t") to string (" ")
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>String</returns>
        public static string ToSafetyStringForTab(string data)
        {
            return data.Replace("\t", " ");
        }

        /// <summary>
        /// Convert input string
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>String</returns>
        public static string ConvertInputString(string data)
        {
            return Trim(ToSafetyStringForTab(ToString(data)));
        }

        /// <summary>
        /// Convert input Guid
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>Guid</returns>
        public static Guid ConvertInputGuid(string data)
        {
            // Local variable declaration
            Guid result;
            // Try parse
            if (!Guid.TryParse(data, out result)) return Guid.Empty;
            // Return value
            return result;
        }

        /// <summary>
        /// Convert input number
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>Decimal?</returns>
        public static decimal? ConvertInputNumber(string data)
        {
            // Local variable declaration
            decimal result;
            var provider = Thread.CurrentThread.CurrentCulture;
            // Try parse
            if (!decimal.TryParse(data, NumberStyles.Any, provider, out result))
                return null;
            // Return value
            return result;
        }

        /// <summary>
        /// Convert input date
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>DateTime?</returns>
        public static DateTime? ConvertInputDate(string data)
        {
            // Local variable declaration
            DateTime result;
            var provider = Thread.CurrentThread.CurrentCulture;
            // Try parse
            if (!DateTime.TryParse(data, provider, DateTimeStyles.None, out result))
                return null;
            // Return value
            return result;
        }

        /// <summary>
        /// Convert input bool
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>Boolean?</returns>
        public static bool? ConvertInputBoolean(string data)
        {
            // Local variable declaration
            bool? result;
            // Check data
            if (data == bool.FalseString || data == "0")
                result = false;
            else if (data == bool.TrueString || data == "1")
                result = true;
            else result = null;
            // Return value
            return result;
        }

        /// <summary>
        /// Convert input stream
        /// </summary>
        /// <param name="target">Stream</param>
        /// <returns>Stream</returns>
        public static Stream ConvertInputStream(Stream data)
        {
            // Local variable declaration
            var result = Stream.Null;
            // Check data
            if (!DataCheckHelper.IsNull(data)) result = data;
            // Return value
            return result;
        }

        /// <summary>
        /// Convert input cart
        /// </summary>
        /// <param name="target">Cart</param>
        /// <returns>IList(CartItem)</returns>
        public static IList<CartItem> ConvertInputCart(object target)
        {
            if (target == null) return new List<CartItem>();
            try { return (IList<CartItem>)target; }
            catch (Exception) { return new List<CartItem>(); }
        }

        /// <summary>
        /// Convert output string with format
        /// </summary>
        /// <param name="format">String</param>
        /// <param name="data">String</param>
        /// <returns>String</returns>
        public static string ToString(string format, string data)
        {
            // Local variable declaration
            var result = string.Empty;
            var provider = Thread.CurrentThread.CurrentCulture;
            // Check data
            if (!DataCheckHelper.IsNull(data)) result = data;
            // Return value
            return string.Format(provider, format, result);
        }

        /// <summary>
        /// Convert output number
        /// </summary>
        /// <param name="format">String</param>
        /// <param name="data">Decimal</param>
        /// <returns>String</returns>
        public static string ToString(string format, decimal? data)
        {
            // Local variable declaration
            var result = decimal.Zero;
            var provider = Thread.CurrentThread.CurrentCulture;
            // Check data
            if (!DataCheckHelper.IsNull(data)) result = data.Value;
            // Return value
            return string.Format(provider, format, result);
        }

        /// <summary>
        /// Convert output date
        /// </summary>
        /// <param name="format">String</param>
        /// <param name="data">DateTime</param>
        /// <returns>String</returns>
        public static string ToString(string format, DateTime? data)
        {
            // Local variable declaration
            var provider = Thread.CurrentThread.CurrentCulture;
            // Check data
            if (DataCheckHelper.IsNull(data)) return string.Empty;
            // Return value
            return string.Format(provider, format, data);
        }

        /// <summary>
        /// Convert output bool
        /// </summary>
        /// <param name="data">Boolean?</param>
        /// <returns>String</returns>
        public static string ToString(bool? data)
        {
            // Check data
            if (DataCheckHelper.IsNull(data)) return string.Empty;
            // Return value
            return data.Value ? bool.TrueString : bool.FalseString;
        }

        /// <summary>
        /// Convert string to short string
        /// </summary>
        /// <param name="data">String</param>
        /// <param name="size">Int32</param>
        /// <returns>String</returns>
        public static string ToSubString(string data, int size)
        {
            // Local variable declaration
            var result = string.Empty;
            var index = int.MinValue;
            // Variable initialize
            result = Convert.ToString(data);
            // Check length
            if (result.Length < size) return data;
            // Get index word " " 
            index = result.IndexOf(" ", size, StringComparison.CurrentCulture);
            if (index < 0) index = size;
            // Convert
            return result.Substring(0, index);
        }

        /// <summary>
        /// Convert output currency
        /// </summary>
        /// <param name="data">Decimal</param>
        /// <param name="localeId">String</param>
        /// <returns>String currency</returns>
        public static string ToCurrencyByLocale(decimal? data, string localeId)
        {
            // Local variable declaration
            var culture = new CultureInfo(localeId);
            var format = Formats.ResourceManager.GetString("CURRENCY", culture);
            var value = decimal.Zero;
            // Check data
            if (!DataCheckHelper.IsNull(data))
                value = data.Value;
            // Return value
            return string.Format(culture, format, value);
        }

        /// <summary>
        /// Convert data input
        /// </summary>
        /// <param name="source">Object</param>
        /// <param name="target">Object</param>
        public static void ConvertInput(object source, object target)
        {
            // Get properties (source)
            var lSource = source.GetType().GetProperties().ToDictionary(p => p.Name);
            // Get properties (target)
            var lTarget = target.GetType().GetProperties().ToDictionary(p => p.Name);
            // Loop source
            foreach (var item in lSource)
            {
                // Check exist
                if (!lTarget.ContainsKey(item.Key)) continue;
                // Local variable declaration
                var s = item.Value;
                var t = lTarget[item.Key];
                // Get property value
                var newValue = GetProperty(source, s.Name);
                // Check null
                if (newValue == null) continue;
                // Check property type
                if (s.PropertyType != t.PropertyType)
                {
                    if (t.PropertyType == typeof(DateTime?))
                        newValue = ConvertInputDate(newValue.ToString());
                    else if (t.PropertyType == typeof(decimal?))
                        newValue = ConvertInputNumber(newValue.ToString());
                    else if (t.PropertyType == typeof(bool?))
                        newValue = ConvertInputBoolean(newValue.ToString());
                    else if (t.PropertyType == typeof(Guid))
                        newValue = ConvertInputGuid(newValue.ToString());
                    else if (t.PropertyType.IsClass)
                    {
                        var tmp = Activator.CreateInstance(t.PropertyType);
                        ConvertInput(newValue, tmp);
                        newValue = tmp;
                    }
                    else if (t.PropertyType.IsGenericType)
                    {
                        var gt = t.PropertyType.GetGenericArguments();
                        var gl = (IList)newValue;
                        var rs = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(gt[0]));
                        foreach (var gi in gl)
                        {
                            var tmp = Activator.CreateInstance(gt[0]);
                            ConvertInput(gi, tmp);
                            rs.Add(tmp);
                        }
                        newValue = rs;
                    }
                    else
                    {
                        try { newValue = Convert.ChangeType(newValue, t.PropertyType); }
                        catch (Exception) { continue; }
                    }
                }
                else
                {
                    if (t.PropertyType == typeof(string))
                        newValue = ConvertInputString(newValue.ToString());
                    else if (t.PropertyType == typeof(Stream))
                        newValue = ConvertInputStream((Stream)newValue);
                }
                // Set property value
                try { SetProperty(target, t.Name, newValue); }
                catch (Exception) { continue; }
            }
        }

        /// <summary>
        /// Convert data output
        /// </summary>
        /// <param name="source">Object</param>
        /// <param name="target">Object</param>
        public static void ConvertOutput(object source, object target)
        {
            // Get properties (source)
            var lSource = source.GetType().GetProperties().ToDictionary(p => p.Name);
            // Get properties (target)
            var lTarget = target.GetType().GetProperties().ToDictionary(p => p.Name);
            // Loop source
            foreach (var item in lSource)
            {
                // Check exist
                if (!lTarget.ContainsKey(item.Key)) continue;
                // Local variable declaration
                var s = item.Value;
                var t = lTarget[item.Key];
                // Get property value
                var newValue = GetProperty(source, s.Name);
                // Check null
                if (newValue == null) continue;
                // Check property type
                if (s.PropertyType != t.PropertyType)
                {
                    if (s.PropertyType == typeof(DateTime?))
                    {
                        var tmp = (DateTime?)newValue;
                        if (s.Name == "UpdateDate")
                            newValue = ToString(Formats.UPDATE_DATE, tmp);
                        else
                            newValue = ToString(Formats.DATE, tmp);
                    }
                    else if (s.PropertyType == typeof(decimal?))
                    {
                        var tmp = (decimal?)newValue;
                        newValue = ToString(Formats.NUMBER, tmp);
                    }
                    else if (s.PropertyType == typeof(bool?))
                    {
                        var tmp = (bool?)newValue;
                        newValue = ToString(tmp);
                    }
                    else if (s.PropertyType == typeof(Guid))
                    {
                        var tmp = (Guid)newValue;
                        newValue = ToString(tmp);
                    }
                    else if (s.PropertyType.IsClass)
                    {
                        var tmp = Activator.CreateInstance(t.PropertyType);
                        ConvertOutput(newValue, tmp);
                        newValue = tmp;
                    }
                    else if (s.PropertyType.IsGenericType)
                    {
                        var gt = t.PropertyType.GetGenericArguments();
                        var gl = (IList)newValue;
                        var rs = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(gt[0]));
                        foreach (var gi in gl)
                        {
                            var tmp = Activator.CreateInstance(gt[0]);
                            ConvertOutput(gi, tmp);
                            rs.Add(tmp);
                        }
                        newValue = rs;
                    }
                    else
                    {
                        newValue = ToString(newValue);
                    }
                }
                else
                {
                    if (s.PropertyType == typeof(string))
                        newValue = ToString(newValue.ToString());
                }

                // Set property value
                try { SetProperty(target, t.Name, newValue); }
                catch (Exception) { continue; }
            }
        }

        /// <summary>
        /// Copy object
        /// </summary>
        /// <param name="source">Object</param>
        /// <param name="target">Object</param>
        public static void CopyObject(object source, object target)
        {
            // Get properties (source)
            var lSource = source.GetType().GetProperties().ToDictionary(p => p.Name);
            // Get properties (target)
            var lTarget = target.GetType().GetProperties().ToDictionary(p => p.Name);
            // Check exist
            foreach (var item in lSource)
            {
                if (!lTarget.ContainsKey(item.Key)) continue;
                // Local variable declaration
                var s = item.Value;
                var t = lTarget[item.Key];
                // Get property value
                var newValue = GetProperty(source, s.Name);
                // Check null
                if (newValue == null) continue;
                // Check property type
                if (s.PropertyType != t.PropertyType)
                {
                    if (t.PropertyType == typeof(Guid))
                    {
                        Guid result;
                        if (!Guid.TryParse(newValue.ToString(), out result)) continue;
                        newValue = result;
                    }
                    else if (t.PropertyType.IsClass)
                    {
                        var tmp = Activator.CreateInstance(t.PropertyType);
                        CopyObject(newValue, tmp);
                        newValue = tmp;
                    }
                    else if (t.PropertyType.IsGenericType)
                    {
                        var gt = t.PropertyType.GetGenericArguments();
                        var gl = (IList)newValue;
                        var rs = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(gt[0]));
                        foreach (var gi in gl)
                        {
                            var tmp = Activator.CreateInstance(gt[0]);
                            CopyObject(gi, tmp);
                            rs.Add(tmp);
                        }
                        newValue = rs;
                    }
                    else
                    {
                        try { newValue = Convert.ChangeType(newValue, t.PropertyType); }
                        catch (Exception) { continue; }
                    }
                }
                // Set property value
                try { SetProperty(target, t.Name, newValue); }
                catch (Exception) { continue; }
            }
        }

        /// <summary>
        /// Get property
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="propertyName">String</param>
        public static object GetProperty(object obj, string propertyName)
        {
            // Local variable declaration
            var p = obj.GetType().GetProperty(propertyName);
            // Chech null
            if (p == null) return null;
            // Return value
            return p.GetGetMethod().Invoke(obj, null);
        }

        /// <summary>
        /// Set property
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="propertyName">String</param>
        /// <param name="newValue">Object</param>
        public static void SetProperty(object obj, string propertyName, object newValue)
        {
            // Local variable declaration
            var p = obj.GetType().GetProperty(propertyName);
            // Chech null
            if (p == null) return;
            // Setting value
            p.GetSetMethod().Invoke(obj, new[] { newValue });
        }

        /// <summary>
        /// Get Md5 Hash
        /// </summary>
        /// <param name="input">String</param>
        /// <returns>String</returns>
        public static string GetMd5Hash(string input)
        {
            // Local variable declaration
            MD5 md5Hasher = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Append string
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return value
            return sBuilder.ToString();
        }

        /// <summary>
        /// Get unique key
        /// </summary>
        /// <returns>String unique key</returns>
        public static string GetUniqueKey()
        {
            // Local variable declaration
            var now = DateTime.Now;
            var strUniqueKey = Convert.ToString(now.ToBinary());
            // Return value
            return GetMd5Hash(strUniqueKey);
        }

        /// <summary>
        /// Replace string
        /// </summary>
        /// <param name="data">String</param>
        /// <param name="size">Int32</param>
        /// <returns>String</returns>
        public static string Replace(string data, string oldValue, string newValue)
        {
            // Local variable declaration
            var result = Convert.ToString(data);
            // Return value
            return result.Replace(oldValue, newValue);
        }

        /// <summary>
        /// Get day of week
        /// </summary>
        /// <param name="data">String</param>
        /// <param name="add">Int32</param>
        /// <returns>Day of week</returns>
        public static string GetDayOfWeek(DateTime data, int add)
        {
            // Local variable declaration
            IFormatProvider provider = Thread.CurrentThread.CurrentCulture;
            // Check data
            if (DataCheckHelper.IsNull(data)) return string.Empty;
            // Variable initialize
            data = data.AddDays(add);
            // Return value
            return data.ToString("dddd", provider);
        }

        /// <summary>
        /// Get day of week
        /// </summary>
        /// <param name="data">String</param>
        /// <returns>Day of week</returns>
        public static string GetDayOfWeek(DateTime data)
        {
            // Return value
            return GetDayOfWeek(data, 0);
        }

        public static int GetDaysInMonth(int month, int year)
        {
            var date = new DateTime(year, month, 1);
            return date.AddMonths(1).AddDays(-1).Day;
        }

        /// <summary>
        /// Get first day of month
        /// </summary>
        /// <returns>First day of month</returns>
        public static DateTime GetFirstDayOfMonth()
        {
            // Get system date
            var currentDate = DateTime.Now;
            // Return value
            return new DateTime(currentDate.Year, currentDate.Month, 1); ;
        }

        /// <summary>
        /// Get first day of month
        /// </summary>
        /// <param name="data">Date</param>
        /// <returns>First day of month</returns>
        public static DateTime GetFirstDayOfMonth(DateTime data)
        {
            // Return value
            return new DateTime(data.Year, data.Month, 1);
        }

        /// <summary>
        /// Get last day of month
        /// </summary>
        /// <returns>Last day of month</returns>
        public static DateTime GetLastDayOfMonth()
        {
            // Get first day of month
            var firstDayOfMonth = GetFirstDayOfMonth();
            // Return value
            return firstDayOfMonth.AddMonths(1).AddDays(-1); ;
        }

        /// <summary>
        /// Get last day of month
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Last day of month</returns>
        public static DateTime GetLastDayOfMonth(DateTime data)
        {
            // Get first day of month
            var firstDayOfMonth = GetFirstDayOfMonth(data);
            // Return value
            return firstDayOfMonth.AddMonths(1).AddDays(-1); ;
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>String</returns>
        public static string ToStringWithZero(int data)
        {
            // Local variable declaration
            var result = string.Empty;

            // Variable initialize
            result = Convert.ToString(data);

            // Check month
            if (result.Length < 2) result = decimal.Zero + result;

            // Return value
            return result;
        }

        /// <summary>
        /// Convert IEnumerable to data table
        /// </summary>
        /// <param name="data">IEnumerable</param>
        /// <returns>Data table</returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            // Local variable declaration
            var dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            // Check data
            if (data == null) return dtReturn;
            // Loop data
            foreach (T rec in data)
            {
                // Use reflection to get property names, to create table, Only first time, others 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        var colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                var dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
}