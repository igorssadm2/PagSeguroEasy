
using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace msShop.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    internal static class PagSeguroUtil
    {

        /// <summary>
        /// Truncate a String and add final end chars to them
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        /// <param name="endChars"></param>
        /// <returns></returns>
        public static string TruncateValue(string value, int limit, string endChars)
        {
            if (!value.Equals(null) && value.Length > limit)
                value = value.Substring(0, limit - endChars.Length) + endChars;
            return value;
        }

        /// <summary>
        /// Remove extra spaces from String
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveExtraSpaces(string value)
        {
            return value.Replace("( +)", " ").Trim();
        }
        
        /// <summary>
        /// Format a String dropping extra spaces and truncate value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="limit"></param>
        /// <param name="endChars"></param>
        /// <returns></returns>
        public static string FormatString(string value, int limit, string endChars)
        {
            return PagSeguroUtil.TruncateValue(PagSeguroUtil.RemoveExtraSpaces(value), limit, endChars);
        }

        /// <summary>
        /// Get only numbers from a string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetOnlyNumbers(String value)
        {
            return Regex.Replace(value, @"\D+", string.Empty);
        }

        /// <summary>
        /// Format a decimal number, just two decimal places
        /// </summary>
        /// <param name="numeric"></param>
        /// <returns></returns>
        public static string DecimalFormat(decimal numeric) 
        {
            return string.Format("{0:0.00}", numeric).Replace(",", ".");
        }

        /// <summary>
        /// Check if var is empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(PagSeguroUtil.RemoveExtraSpaces(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDateXml(DateTime date)
        {
            return XmlConvert.ToString(date, XmlDateTimeSerializationMode.Utc);
        }
    }
}
