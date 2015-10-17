using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    public static class Extensions
    {
        public static System.Boolean IsNumeric(this System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;
            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            } catch { }
            return false;
        }

        public static int ToInt(this object o)
        {
            return Convert.ToInt32(o);
        }

        public static Int64 ToInt64(this object o)
        {
            return Convert.ToInt64(o);
        }

        public static decimal ToDecimal(this object o)
        {
            try
            {
                return Convert.ToDecimal(o);
            }
            catch
            {
                return 0;
            }
        }

        public static float ToFloat(this object o)
        {
            return float.Parse(o.ToString());
        }

        public static bool ToBoolean(this object o)
        {
            bool retorno = false;
            Boolean.TryParse((o == null) ? "false" : o.ToString(), out retorno);
            return retorno;
        }

        public static DateTime ToDateTime(this object o)
        {
            DateTime retorno;
            if (!DateTime.TryParse(o.ToString(), new System.Globalization.CultureInfo("PT-br"), DateTimeStyles.None, out retorno))
            {
                return SqlDateTime.MinValue.ToDateTime();
            }
            return retorno;
        }

        public static string FirstCharToUpper(this string input)
        {
            if (!string.IsNullOrEmpty(input))
                return input[0].ToString().ToUpper() + input.Substring(1).ToLower();
            else return "";
        }

        public static string Right(this string value, int length)
        {
            return value.Substring(value.Length - length);
        }

        public static void AddNotExists<T>(this List<T> lst, T obj, string propriedade = "")
        {
            object v =
                propriedade == "" ?
                typeof(T).GetProperties().First().GetValue(obj, null)
                :
                typeof(T).GetProperty(propriedade).GetValue(obj, null);


            if (!lst.Exists(a => (propriedade == "" ?
                a.GetType().GetProperties().First().GetValue(a, null) :
                a.GetType().GetProperty(propriedade).GetValue(a, null)).Equals(v))) lst.Add(obj);
        }

        public static bool IsNotNull(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string SubstringMax(this string str, int startIndex, int length)
        {
            if (str.Length < startIndex)
                return str;
            if (str.Length < (startIndex + length))
                return str.Substring(startIndex);
            return str.Substring(startIndex, length);
        }

        public static string RemoveDiacritics(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            string normalized = str.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (char ch in normalized)
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    builder.Append(ch);
            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string LatinToAscii(this string inString)
        {
            var newStringBuilder = new StringBuilder();
            newStringBuilder.Append(inString.Normalize(NormalizationForm.FormKD)
                                            .Where(x => x < 128)
                                            .ToArray());
            return newStringBuilder.ToString();
        }

        public static string StripPunctuation(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public static double ToPorcentage(this int count, int total)
        {
            return (double)((double)count / (double)total) * (double)100;
        }

        public static string ToFriendlyUrl(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars           
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space   
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // cut and trim it   
            str = Regex.Replace(str, @"\s", "-"); // hyphens   

            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
