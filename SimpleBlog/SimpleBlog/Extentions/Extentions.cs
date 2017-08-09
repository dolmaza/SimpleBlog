using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleBlog.Extentions
{
    public static class Extentions
    {
        public static string Shorten(this string str, int maxLength)
        {
            if (str.Length > maxLength)
            {
                str = $"{str.Substring(0, maxLength)} ...";
            }
            return str;
        }

        public static string StripHtml(this string str)
        {
            str = Regex.Replace(str, "<[^>]*(>|$)", string.Empty);
            return str;
        }

        public static decimal? ToDecimal(this string str)
        {
            decimal? dcm = null;
            if (str != null)
            {
                if (str.Contains(","))
                {
                    str = str.Replace(",", ".");
                }
                dcm = decimal.Parse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }
            return dcm;
        }

        //public static string ToJson(this object obj)
        //{
        //    try
        //    {
        //        var js = new JavaScriptSerializer();
        //        var json = js.Serialize(obj);
        //        return json;

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }


        //}

        public static DateTime? ToDateTime(this string str)
        {
            var date = string.IsNullOrEmpty(str) ? (DateTime?)null : DateTime.Parse(str);

            return date;
        }

        public static string ToMD5(this string input)
        {
            // step 1, calculate MD5 hash from input

            var md5 = MD5.Create();

            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            var hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            var sb = new StringBuilder();

            foreach (var h in hash)
            {
                sb.Append(h.ToString("X2"));
            }

            return sb.ToString();

        }

    }
}