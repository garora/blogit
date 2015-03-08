using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace BlogIT.Utility
{
    public static class Utilities
    {
        #region DateComparisonResult enum

        public enum DateComparisonResult
        {
            Earlier = -1,
            Later = 1,
            TheSame = 0
        };

        #endregion

        /// <summary>
        ///     Convert Enum to Generic List
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns></returns>
        public static List<T> EnumToList<T>()
        {
            return Enum.GetValues(typeof (T)).Cast<T>().ToList();
        }

        public static string GetDateTimeForDisplay(DateTime? date)
        {
            if (date == null)
                return string.Empty;

            TimeSpan diff = DateTime.Now - date.Value;

            return diff.TotalDays < 1
                ? diff.Hours + "hrs " + diff.Minutes + "min ago"
                : date.Value.ToShortDateString() + " " + date.Value.ToShortTimeString();
        }

        public static string GetDateTimeForDisplay(DateTime date1, DateTime date2)
        {
            int oldMonth = date2.Month;
            while (oldMonth == date2.Month)
            {
                date1 = date1.AddDays(-1);
                date2 = date2.AddDays(-1);
            }

            int years = 0, months = 0, days = 0, hours = 0, minutes = 0, seconds = 0, milliseconds = 0;

            // getting number of years
            while (date2.CompareTo(date1) >= 0)
            {
                years++;
                date2 = date2.AddYears(-1);
            }
            date2 = date2.AddYears(1);
            years--;

            // getting number of months and days
            oldMonth = date2.Month;
            while (date2.CompareTo(date1) >= 0)
            {
                days++;
                date2 = date2.AddDays(-1);
                if ((date2.CompareTo(date1) >= 0) && (oldMonth != date2.Month))
                {
                    months++;
                    days = 0;
                    oldMonth = date2.Month;
                }
            }
            date2 = date2.AddDays(1);
            days--;

            TimeSpan difference = date2.Subtract(date1);

            //var result = string.Format("{0} years {1} month {2} days", years, months, days);
            string result = string.Empty;

            if (years > 0)
                result = string.Format("{0} years,", years);
            if (months > 0)
                result += string.Format(" {0} months, and", months);
            if (days > 0)
                result += string.Format(" {0} days ago", days);

            /*
            result =
                            "Difference: " +
                            years + " years" +
                            ", " + months + " months" +
                            ", " + days + " days" +
                            ", " + difference.Hours + " hours" +
                            ", " + difference.Minutes + " minutes" +
                            ", " + difference.Seconds + " seconds" +
                            ", " + difference.Milliseconds + " milliseconds";
                        */
            if (string.IsNullOrEmpty(result.Trim()))
                result = "now";

            return result;
        }

        /// <summary>
        ///     Return absolute month difference between two dates irrespective if difference is -ve
        /// </summary>
        /// <param name="startDateTime"> </param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public static int MonthDifference(this DateTime startDateTime, DateTime endDateTime)
        {
            return Math.Abs((startDateTime.Month - endDateTime.Month) + 12*(startDateTime.Year - endDateTime.Year));
        }

        public static string GetDisplayUser(string user)
        {
            return string.IsNullOrEmpty(user) ? "[anonymous]" : user;
        }

        public static string GetDisplayCategoryName(string catName)
        {
            return string.IsNullOrEmpty(catName) ? "[undefined]" : catName;
        }

        /// <summary>
        ///     Remove all special characters
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string originalString)
        {
            var newString = new StringBuilder();
            foreach (
                char cToCheck in
                    originalString.Where(
                        chr =>
                            (chr >= '0' && chr <= '9') || (chr >= 'A' && chr <= 'Z') ||
                            (chr >= 'a' && chr <= 'z') | chr == '.' || chr == '_' || chr == ' '))
            {
                newString.Append(cToCheck);
            }
            return newString.ToString();
        }


        /// <summary>
        ///     Format Date in the format of "ddddd MMMM dd, yyyy"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime? date)
        {
            string newDate = string.Empty;
            if (date.HasValue)
                newDate = Convert.ToDateTime(date).ToString("ddddd MMMM dd, yyyy", CultureInfo.InvariantCulture);
            return newDate;
        }

        /// <summary>
        ///     Format date in specified format make sure format string should verify IFormatProvider
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime? date, string format)
        {
            string newDate = string.Empty;
            if (date.HasValue)
                newDate = Convert.ToDateTime(date).ToString(format, CultureInfo.InvariantCulture);
            return newDate;
        }

        /// <summary>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="checkToday"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime date, bool checkToday = false)
        {
            string formattedDate = date.ToString("ddddd MMM dd,yyyy", CultureInfo.InvariantCulture);
            string result = formattedDate;
            if (checkToday)
            {
                DateComparisonResult compareDates = CompareDates(DateTime.Today, date);

                switch (compareDates)
                {
                    case DateComparisonResult.TheSame:
                        result = "Today";
                        break;

                    case DateComparisonResult.Earlier:
                        result = formattedDate;
                        break;
                    case DateComparisonResult.Later:
                        result = formattedDate;
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="dtString"></param>
        /// <returns></returns>
        public static DateTime ParseDate(string dtString)
        {
            return DateTime.ParseExact(dtString, "ddd dd-MMM-yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string FormatException(Exception ex)
        {
            string message = ex.Message;

            //Add the inner exception if present (showing only the first 50 characters of the first exception)
            if (ex.InnerException != null)
            {
                if (message.Length > 50)
                    message = message.Substring(0, 50);

                message += "...->" + ex.InnerException.Message;
            }

            return message;
        }

        /// <summary>
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static DateComparisonResult CompareDates(DateTime fromDate, DateTime toDate)
        {
            return (DateComparisonResult) fromDate.CompareTo(toDate);
        }

        /// <summary>
        ///     Check for Valid Session use for different places
        ///     where need of session variables
        /// </summary>
        /// <returns></returns>
        //public static bool IsValidSession()
        //{
        //    var sessionManager = new SessionManager();
        //    object validSession = sessionManager.GetSessionItem(SessionKey.ValidUser);
        //    return (validSession != null);
        //}
        public static string GenerateActivationKey()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }

        public static string GenerateCaptchaKey()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }

        /// <summary>
        ///     Use this to add unique name string for attachments
        /// </summary>
        /// <returns></returns>
        public static string GenerateUniqueStringForAttachment()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }

        #region "IList To DataSet Conversion"

        /// <summary>
        ///     Converts List for sepcific type to Dataset
        /// </summary>
        /// <typeparam name="T">Type of Entity for a table exists in DB </typeparam>
        /// <param name="list">List of Generic collection for Type T</param>
        /// <returns>DataSet based on supplied Generic List</returns>
        public static DataSet ToDataSet<T>(IEnumerable<T> list)
        {
            Type elementType = typeof (T);
            var ds = new DataSet();
            var t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T 
            foreach (PropertyInfo propInfo in elementType.GetProperties())
            {
                Type colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, colType);
            }

            //go through each property on T and add each value to the table 
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (PropertyInfo propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        #endregion

        #region Conversion methods

        public static string ObjectToString(this object obj)
        {
            return Convert.ToString(obj);
        }

        public static Int32 ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        #endregion

        #region BreadCrumbs

        public static string CreateFullAnchorTag(List<BreadCrumb> breadCrumbs)
        {
            var stringBuilder = new StringBuilder();
            foreach (BreadCrumb breadCrumb in breadCrumbs)
            {
                stringBuilder.AppendFormat("<a href='{0}'>{1}</a>", breadCrumb.Url, breadCrumb.Title);
                stringBuilder.Append(breadCrumb.Seprator);
            }
            return stringBuilder.ToString();
        }

        #endregion
    }

    public static class StringExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(this string s, out Guid result)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            var format = new Regex(
                "^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            Match match = format.Match(s);
            if (match.Success)
            {
                result = new Guid(s);
                return true;
            }
            result = Guid.Empty;
            return false;
        }

        /// <summary>
        ///     Removed 3-charactes,positioned at the last (.aspx)
        /// </summary>
        /// <param name="oldText"></param>
        /// <returns></returns>
        public static string RemoveExtensionOfPageUrl(this string oldText)
        {
            return oldText.LastIndexOf('.') > 0 ? oldText.Remove(oldText.LastIndexOf('.')) : oldText;
        }

        //public static string UrlDecode(this string urlEncode)
        //{
        //    return HttpUtility.UrlDecode(urlEncode);
        //}
        //public static string UrlDecode(this string urlEncode, string toReplace)
        //{
        //    return HttpUtility.UrlDecode(urlEncode).Replace(toReplace, " ");
        //}
        //public static string UrlEncode(this string plainText)
        //{
        //    return HttpUtility.UrlDecode(plainText);
        //}
        /// <summary>
        ///     Get the plain text from urlencoded text
        /// </summary>
        /// <param name="urlEncode"></param>
        /// <returns></returns>
        /// <summary>
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        /// <summary>
        ///     Replace white spaces with '_'
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceBlankWitUnderscore(this string text)
        {
            return text.Replace(" ", "_");
        }
    }

    public static class StringHelper
    {
        public static string FirstCharToUpper(string inputString)
        {
            var sb = new StringBuilder();
            if (inputString.Length > 0)
            {
                sb.Append(inputString.Substring(0, 1).ToUpper())
                    .Append(inputString.Substring(1, inputString.Length - 1));
            }
            return sb.ToString();
        }

        public static string FirstCharToLower(string inputString)
        {
            var sb = new StringBuilder();
            if (inputString.Length > 0)
            {
                sb.Append(inputString.Substring(0, 1).ToLower())
                    .Append(inputString.Substring(1, inputString.Length - 1));
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Case Insensitive String Replace
        /// </summary>
        public static string StringReplace(string text, string oldValue, string newValue)
        {
            int iPos = text.ToLower().IndexOf(oldValue.ToLower());
            string retval = "";
            while (iPos != -1)
            {
                retval += text.Substring(0, iPos) + newValue;
                text = text.Substring(iPos + oldValue.Length);
                iPos = text.ToLower().IndexOf(oldValue.ToLower());
            }
            if (text.Length > 0)
                retval += text;
            return retval;
        }

        /// <summary>
        ///     Converts an object from DBNULL to NULL
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static object ConvertFromDatabase(object o)
        {
            if (o == DBNull.Value) return null;
            return o;
        }

        /// <summary>
        ///     Converts an object from NULL to DBNULL
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static object ConvertToDatabase(object o)
        {
            if (o == null) return DBNull.Value;
            return o;
        }

        #region String Match

        public static bool Match(object s1, string s2, bool ignoreCase)
        {
            if (s1 == null)
                if (s2 == null) return true;
                else return false;
            if (s2 == null) return false;
            if (s1.ToString().Length != s2.Length) return false;
            if (s1.ToString().Length == 0) return true;

            return (String.Compare(s1.ToString(), s2, ignoreCase) == 0);
        }

        public static bool Match(string s1, string s2, bool ignoreCase)
        {
            if (s1 == null)
                if (s2 == null) return true;
                else return false;
            if (s2 == null) return false;
            if (s1.Length != s2.Length) return false;
            if (s1.Length == 0) return true;

            return (String.Compare(s1, s2, ignoreCase) == 0);
        }

        public static bool Match(string s1, string s2)
        {
            return Match(s1, s2, true);
        }

        #endregion

        #region Variable Case Conversion

        public static string MakeValidDatabaseCaseVariableName(string inputString)
        {
            string pascalCase = MakeValidPascalCaseVariableName(inputString);
            return PascalCaseToDatabase(pascalCase);
        }

        public static string MakeValidCamelCaseVariableName(string inputString)
        {
            string camelCase = MakeValidPascalCaseVariableName(inputString);
            if (camelCase.Length > 0)
            {
                camelCase = camelCase.Insert(0, camelCase[0].ToString().ToLower());
                camelCase = camelCase.Remove(1, 1);
            }
            return camelCase;
        }

        public static string MakeValidPascalCaseVariableName(string inputString)
        {
            var output = new StringBuilder();
            string regexp = "[A-Z,a-z,0-9]+";
            MatchCollection matches = Regex.Matches(inputString, regexp);
            foreach (Match match in matches)
            {
                string appendString = match.Value;
                appendString = appendString.Insert(0, appendString[0].ToString().ToUpper());
                appendString = appendString.Remove(1, 1);
                output.Append(appendString);
            }
            string returnVal = output.ToString();
            returnVal = returnVal.TrimStart(new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'});
            if (returnVal.Length < 0)
                throw new Exception("Cannot turn string( " + inputString + " ) into a valid variable name");
            return returnVal;
        }

        public static string DatabaseNameToCamelCase(string databaseName)
        {
            databaseName = databaseName.ToLower();
            string regexp = "_.";
            var digitregex = new Regex(regexp);
            string parameterName = digitregex.Replace(databaseName, ReplaceWithUpper);
            return parameterName;
        }

        public static string DatabaseNameToPascalCase(string databaseName)
        {
            string pascalCase = DatabaseNameToCamelCase(databaseName);
            if (pascalCase.Length > 0)
            {
                pascalCase = pascalCase.Insert(0, pascalCase[0].ToString().ToUpper());
                pascalCase = pascalCase.Remove(1, 1);
            }
            return pascalCase;
        }

        public static string PascalCaseToDatabase(string pascalCase)
        {
            var digitregex = new Regex("(?<caps>[A-Z])");
            string parameterName = digitregex.Replace(pascalCase, "_$+");
            parameterName = parameterName.ToLower().TrimStart('_');
            return parameterName;
        }

        public static string CamelCaseToDatabase(string camelCase)
        {
            return PascalCaseToDatabase(camelCase);
        }

        private static string ReplaceWithUpper(Match m)
        {
            string character = m.ToString().TrimStart('_');
            return character.ToUpper();
        }

        #endregion

        #region File Path Conversions

        public static string EnsureDirectorySeperatorAtEnd(string directory)
        {
            if (!(directory.EndsWith(Path.DirectorySeparatorChar.ToString())))
            {
                directory += Path.DirectorySeparatorChar;
            }
            return directory;
        }

        #endregion

        #region byte array conversions

        public static MemoryStream StringToMemoryStream(string str)
        {
            var ms = new MemoryStream(StringToByteArray(str));
            return ms;
        }

        public static String MemoryStreamToString(MemoryStream memStream)
        {
            return ByteArrayToString(memStream.GetBuffer(), (int) memStream.Length);
        }

        public static Byte[] StringToByteArray(string str)
        {
            var enc = new UTF8Encoding();
            return enc.GetBytes(str);
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }


        public static string ByteArrayToString(byte[] byteArray)
        {
            var enc = new UTF8Encoding();
            return enc.GetString(byteArray, 0, byteArray.Length);
        }

        public static string ByteArrayToString(byte[] byteArray, Encoding encoder)
        {
            return encoder.GetString(byteArray, 0, byteArray.Length);
        }

        public static string ByteArrayToString(byte[] byteArray, int length)
        {
            var enc = new UTF8Encoding();
            return enc.GetString(byteArray, 0, length);
        }

        #endregion
    }

    /// <summary>
    ///     Helper class to encode reserverd keywords of SQL server to use with Nhibernate entities
    ///     http://msdn.microsoft.com/en-us/library/aa258313%28v=sql.80%29.aspx
    /// </summary>
    public static class EncodeSqlReservered
    {
        /// <summary>
        ///     Reserver keywords encoded with Braces
        /// </summary>
        /// <param name="keywordToEncode"> Reserved keyword like Group, User, server</param>
        /// <returns></returns>
        public static string EncodeKeywordWithBraces(string keywordToEncode)
        {
            return string.Format("[{0}]", keywordToEncode);
        }

        #region Extension Methods

        /// <summary>
        ///     Supplied keyword string encoded with braces eg. Group - > [Group]
        /// </summary>
        /// <param name="keywordToEncode">Keyword</param>
        /// <returns></returns>
        public static string EncodeToBraces(this string keywordToEncode)
        {
            return string.Format("[{0}]", keywordToEncode);
        }

        #endregion
    }

    public class PagingInfo
    {
        private readonly long _mCurrentPage;
        private readonly long _mPageSize;

        public PagingInfo(long pPageSize, long pCurrentPage)
        {
            _mPageSize = pPageSize;
            _mCurrentPage = pCurrentPage;
        }

        public static PagingInfo All
        {
            get { return new PagingInfo(0, 0); }
        }

        public long PageSize
        {
            get { return _mPageSize; }
        }

        public long CurrentPage
        {
            get { return _mCurrentPage; }
        }

        public long RowCount { get; set; }

        public long PagesCount
        {
            get { return (long) Math.Ceiling(RowCount/(double) PageSize); }
        }
    }

    /// <summary>
    ///     Static class with some entity related methods
    /// </summary>
    public static class EntityHelper
    {
        private const string NotvalidChars = ",;:\"'\\/<>&?=\t\r\n "; //  ,;:"'\/<>&?=

        /// <summary>
        ///     Check if the specified code can be used safely (doesn't contain special characters)
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="code"></param>
        public static void ValidateCode(string fieldName, string code)
        {
            if (code != null)
            {
                int index = code.LastIndexOfAny(NotvalidChars.ToCharArray());
                if (index >= 0)
                    throw new Exception();
            }
        }
    }

    public static class HibernateProfilerHelper
    {
        /// <summary>
        /// </summary>
        /// <param name="initialize"></param>
        public static void InitializeHibernateProfiler(bool initialize)
        {
            if (initialize)
                NHibernateProfiler.Initialize();
        }
    }

    public class BreadCrumb
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public string Seprator
        {
            get { return string.Format("<span class='{0}'></span>", "separator"); }
        }
    }
}