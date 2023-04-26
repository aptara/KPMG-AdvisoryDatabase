using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml.Serialization;

namespace AdvisoryDatabase.Framework.Common
{
    using System.Data;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;

    public enum DataType
    {
        Integer = 1,
        Long = 2,
        String = 3,
        DateTime = 4,
        Boolean = 5,
        Currency = 6,
        Decimal = 7
    }
    public static class Utility
    {
        #region "Common Helper Delegates"

        /// <summary>
        /// Represents generic method that works on the given operand.
        /// </summary>
        public delegate void Method<T>(T operand);

        /// <summary>
        /// Represents generic function that works on the given type of operand and
        /// returns result of same type. Example of such functions can be
        /// changing string case, squaring the number etc.
        /// </summary>
        public delegate T Func<T>(T operand);

        /// <summary>
        /// Represents generic function that works on the given type of operand
        /// and returns result of another given type.
        /// </summary>
        public delegate V Func<T, V>(T operand);

        /// <summary>
        /// Generic comparer function that will compare between t1 & t2.
        /// </summary>
        public delegate int ComparerFunc<T>(T t1, T t2);

        /// <summary>
        /// Finds the max item in the collection. if max items are repeted then it
        /// will return first one
        /// return the first one
        /// </summary>
        public static T FindMax<T>(IEnumerable<T> collection,
            ComparerFunc<T> comparer)
        {
            var enumerator = collection.GetEnumerator();
            T max;
            if (enumerator.MoveNext())
            {
                max = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    T t = enumerator.Current;
                    if (comparer(t, max) > 0)
                    {
                        // t is greater than max, update max
                        max = t;
                    }
                }
            }
            else
            {
                throw new ApplicationException("not a valid collection");
            }

            return max;
        }

        /// <summary>
        /// Finds the min item in the collection. if min items are repeated then it
        /// will return first one
        /// </summary>
        public static T FindMin<T>(IEnumerable<T> collection,
           ComparerFunc<T> comparer)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            T min;
            if (enumerator.MoveNext())
            {
                min = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    T t = enumerator.Current;
                    if (comparer(t, min) < 0)
                    {
                        // t is less that than min, update max
                        min = t;
                    }
                }
            }
            else
            {
                throw new ApplicationException("Not a valid collection");
            }

            return min;
        }

        #endregion "Common Helper Delegates"

        #region "For Each Functions"

        /// <summary>
        /// Performs the given operation on each element of the given collection
        /// </summary>
        public static void ForEach<T>(IEnumerable<T> collection, Method<T> operation)
        {
            foreach (var item in collection)
            {
                operation(item);
            }
        }

        /// <summary>
        /// Performs the given operation on each element of the given list and
        /// update the element with the result of the operation
        /// </summary>
        public static void ForEach<T>(IList<T> list, Func<T> operation)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = operation(list[i]);
            }
        }

        /// <summary>
        /// Performs the given operation on each element of the given array
        /// </summary>
        public static void ForEach<T>(T[] array, Method<T> operation)
        {
            foreach (T t in array)
            {
                operation(t);
            }
        }

        /// <summary>
        /// Performs the given operation on each element of the given array and
        /// update the element with the result of the operation
        /// </summary>
        public static void ForEach<T>(T[] array, Func<T> operation)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = operation(array[i]);
            }
        }

        #endregion "For Each Functions"

        #region "Helper Functions for IList"

        /// <summary>
        /// Returns the first occurrence of item that matched the given criteria from
        /// the given list. It returns default value (null for reference types) of T
        /// if no match is found.
        /// </summary>
        public static T Find<T>(this IList<T> list, Predicate<T> match)
        {
            var index = FindIndex(list, match);
            return index < 0 ? default(T) : list[index];
        }

        /// <summary>
        /// Returns the index of first occurrence of the item that matched the
        /// given criteria from the given list. It returns -1 if no match is found.
        /// </summary>
        public static int FindIndex<T>(this IList<T> list, Predicate<T> match)
        {
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                if (match(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the list of items that matched the given criteria
        /// from the given list.
        /// </summary>
        public static List<T> FindAll<T>(this IList<T> list, Predicate<T> match)
        {
            var result = new List<T>();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var item = list[i];
                if (match(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        #endregion "Helper Functions for IList"

        #region "Helper Functions for Array"

        /// <summary>
        /// Copies all elements of source array into the target array
        /// </summary>
        public static void CopyTo<T>(this T[] source, T[] target)
        {
            CopyTo(source, target, 0, 0, source.Length);
        }

        /// <summary>
        /// Copies all elements of source array into the target array
        /// starting at target index.
        /// </summary>
        public static void CopyTo<T>(this T[] source, T[] target, int targetIndex)
        {
            CopyTo(source, target, 0, targetIndex, source.Length);
        }

        /// <summary>
        /// Copies count number of elements from source array starting at source
        /// index to the target array starting at target index.
        /// </summary>
        public static void CopyTo<T>(this T[] source, T[] target, int sourceIndex,
            int targetIndex, int count)
        {
            var lastIndex = sourceIndex + count;
            for (int i = sourceIndex, j = targetIndex; i < lastIndex; i++, j++)
            {
                target[j] = source[i];
            }
        }

        /// <summary>
        /// Removes the element at the specified index from the given array and
        /// returns the result as new array.
        /// </summary>
        public static T[] RemoveAt<T>(T[] array, int index)
        {
            var result = new T[array.Length - 1];
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (i != index)
                {
                    result[j] = array[i];
                    j++;
                }
            }
            return result;
        }

        /// <summary>
        /// Adds the given element into the given array at the given index. If index
        /// is negative then the element will be appended. Returns the resultant
        /// array.
        /// </summary>
        /// <remarks>If source array is null/zero length array and append operation
        /// is requested then new array will be created and returned.</remarks>
        public static T[] AddAt<T>(T[] array, T element, int index)
        {
            if (index < 0)
            {
                if (null == array || 0 == array.Length)
                {
                    return new[] { element };
                }
                index = array.Length;
            }
            var result = new T[array.Length + 1];
            if (index > 0)
            {
                array.CopyTo(result, 0, 0, index);
            }
            result[index] = element;
            if (index < array.Length)
            {
                array.CopyTo(result, index, index + 1, array.Length - index);
            }
            return result;
        }

        #endregion "Helper Functions for Array"

        #region "Managing Comma Separated Strings"

        /// <summary>
        /// Splits the given string using comma as separator. Returns only
        /// non-empty values.
        /// </summary>
        public static string[] Split(string value)
        {
            return Split(value, ',');
        }

        /// <summary>
        /// Splits the given string using given separators. Returns only
        /// non-empty values.
        /// </summary>
        public static string[] Split(string value, params char[] separator)
        {
            var result = new List<string>();
            if (!string.IsNullOrEmpty(value))
            {
                var values = value.Split(separator);
                ForEach(values,
                    s => { s = s.Trim(); if (s.Length > 0) result.Add(s); });
            }
            return result.ToArray();
        }

        /// <summary>
        /// Combines given set of values using comma.
        /// </summary>
        public static string Combine<T>(T[] values)
        {
            return Combine(values, ',');
        }

        /// <summary>
        /// Combines given values using given separators to form a string.
        /// </summary>
        /// <returns>Empty string if values are null or zero in length</returns>
        public static string Combine<T>(T[] values, params char[] separator)
        {
            if (null == values || 0 == values.Length)
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            ForEach(values,
                o =>
                {
                    if (result.Length > 0) result.Append(separator);
                    result.Append(o);
                });
            return result.ToString();
        }

        #endregion "Managing Comma Separated Strings"

        #region "Data Formatting & Validating"

        // Phone number can be 10(N)/ 3(N)-3(N)-4(N)
        public const string RegExPhone =
            @"^[0-9]{10}$|^[0-9]{3}-[0-9]{3}-[0-9]{4}$";

        public const string RegExExtension =
            @"^([0-9]{0,5})?$";

        // Phone number can be 10(X)/ 3(X)-3(X)-4(X)
        public const string RegExPhoneAlpha =
            @"^[a-zA-Z0-9]{10}$|^[a-zA-Z0-9]{3}-[a-zA-Z0-9]{3}-[a-zA-Z0-9]{4}$";

        public const string RegExEmail =
            @"^[\w!#$%&'*+/=?^`{|}~-]+(?:\.[\w!#$%&'*+/=?^`{|}~-]+)*" +
            "@" +
            @"(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?$";

        public const string FormatDate = "MM-ddd-yyyy";
        public const string FormatDateTime = "MM-dd-yyyy hh:mm:ss tt";
        public const string FormatTime = "hh:mm:ss tt";
        public const string FormatCurrency = "#,0.00";
        public const string FormatDateMonYear = "MMM yyyy";

        /// <summary>
        /// Format for name in [Last Name], [First Name] format
        /// </summary>
        public const string FormatName1 = "{0}, {1}";

        /// <summary>
        /// Format for name in [First Name] [Last Name] format
        /// </summary>
        public const string FormatName2 = "{0} {1}";

        public const string RegExTime = @"^((0?[1-9]|1[012])(:[0-5]\d){0,2}" +
            @"(\ [APap](M|m)))$|^([01]\d|2[0-3])(:[0-5]\d){0,2}$" +
            @"|^0?0:0?[0-5]\d{0,2} [Aa][Mm]$";

        public const string RegExDate = @"^(?:(?:(?:0?[13578]|1[02])(\/)31)\1|" +
        @"(?:(?:0?[1,3-9]|1[0-2])(\/)(?:29|30)\2))(?:(?:1[0-9]|[2-9]\d)" +
        @"?\d{2})$|^(?:0?2(\/)29\3(?:00|(?:(?:1[0-9]|[2-9]\d)?(?:0[48]|" +
        @"[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|" +
        @"^(?:(?:0?[1-9])|(?:1[0-2]))(\/)(?:0?[1-9]|1\d|2[0-8])\4" +
        @"(?:(?:1[0-9]|[2-9]\d)?\d{2})$";

        public const string RegExUrl = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=" +
            @"]*)?|([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?";

        public const string PlaceholderFormatDate = "{0:MM/dd/yyyy}";

        public const string PlaceholderFormatDateTime =
            "{0:MM/dd/yyyy hh:mm:ss tt}";

        public const string PlaceholderFormatTime = "{0:hh:mm:ss tt}";
        public const string PlaceholderFormatCurrency = "{0:#,0.00}";
        public const string PlaceholderFormatCurrencyDollar = "{0:$#,0.00}";


        public const string PlaceholderFormatDateMonYear = "{0:MMM yyyy}";
        public static readonly DateTime MinDate = new DateTime(1783, 1, 1);
        public static readonly DateTime MaxDate = new DateTime(9999, 12, 31);

        public const string PhoneNumberSeparator = "-";

        /// <summary>
        /// Formats the given value based on the given data type. Currency is
        /// formatted with $ sign appended.
        /// </summary>
        public static string Format(DataType dataType, object value)
        {
            if (null == value || DBNull.Value == value)
            {
                return string.Empty;
            }
            switch (dataType)
            {
                case DataType.DateTime:
                    return string.Format(PlaceholderFormatDate, value);

                case DataType.Currency:
                    return string.Format(PlaceholderFormatCurrencyDollar, value);

                case DataType.Boolean:
                    return true.Equals(value) ? "Yes" : "No";

                default:
                    return value.ToString();
            }
        }

        /// <summary>
        /// Formats the given date into the application's default date format.
        /// </summary>
        public static string Format(DateTime date)
        {
            return date.ToString(FormatDate);
        }

        public static string FormatToMonYear(DateTime date)
        {
            return date.ToString(FormatDateMonYear);
        }

        /// <summary>
        /// Formats the given currency into the application's default currency format.
        /// </summary>
        public static string Format(Decimal currency)
        {
            return currency.ToString(FormatCurrency);
        }

        /// <summary>
        /// Formats the given valid phone number
        /// </summary>
        public static string FormatPhoneNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return string.Empty;
            }
            if (number.Contains(PhoneNumberSeparator))
            {
                number = number.Replace(PhoneNumberSeparator, string.Empty);
            }
            if (number.Length == 10)
            {
                var result = new StringBuilder();
                result.Append(number.Substring(0, 3));
                result.Append(PhoneNumberSeparator);
                result.Append(number.Substring(3, 3));
                result.Append(PhoneNumberSeparator);
                result.Append(number.Substring(6));
                number = result.ToString();
            }
            return number;
        }


        public static string FormatZipCode(string zipCode)
        {
            const string Sep = "-";

            if (string.IsNullOrEmpty(zipCode))
            {
                return string.Empty;
            }
            if (zipCode.Contains(Sep))
            {
                zipCode = zipCode.Replace(Sep, string.Empty);
            }
            if (zipCode.Length == 9)
            {
                zipCode = zipCode.Insert(5, Sep);
            }

            return zipCode;
        }

        #region "Validations"

        public static bool ValidateDate(ref string dateValue)
        {
            if (string.IsNullOrEmpty(dateValue))
            {
                return false;
            }
            var r = new Regex(RegExDate);
            if (r.IsMatch(dateValue.Trim()))
            {
                DateTime dtmDate = Convert.ToDateTime(dateValue);
                dateValue = dtmDate.ToString(FormatDate);
                return (dtmDate >= MinDate && dtmDate <= MaxDate);
            }
            return false;
        }

        /// <summary>
        ///  This function will validate for currency value
        ///  format as well as will verify whether the given value falls under the
        ///  passed Precision and Scale.
        /// </summary>
        public static bool ValidateCurrencyValue(
            int precision, int scale, string value)
        {
            value = value.Replace(",", "");
            if (scale == 0)
            {
                var objNumericePattern =
                    new Regex(@"^\d{1,8}$|^\d{1,3},\d{3}$|^\d{1,2},\d{3},\d{3}$");
                if (objNumericePattern.IsMatch(value) == false)
                    return false;
            }
            if (scale == 0 && value.IndexOf(".", StringComparison.Ordinal) != -1)
                return false;
            if (scale == 0)
            {
                return (value.Length <= precision);
            }
            var objPositivePattern = new Regex(@"^\d{1," +
                (precision - scale) + @"}(\.\d{1," + scale + @"})?$");
            return objPositivePattern.IsMatch(value);
        }

        /// <summary>
        /// this method validated number or decimal upto 2 scale
        /// </summary>
        public static bool IsValidNumber(string value)
        {
            var numberPattern = new Regex(
                @"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3})*(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|0(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$");
            return numberPattern.IsMatch(value);
        }

        /// <summary>
        /// Determines whether the specified value is integer.
        /// </summary>
        public static bool IsInteger(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            // Enumerate through each character and check
            // if its a decimal digit or not.
            return !value.Where((t, i) => !char.IsDigit(value, i)).Any();
        }



        /// <summary>
        /// Checks if given string contains alpha-numeric data
        /// </summary>
        public static bool IsAlphanumeric(string value, bool allowSpace)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            // Enumerate through each character and check
            // if its a letter or digit.
            return value.All(c => char.IsLetterOrDigit(c) || (allowSpace && c == ' '));
        }



        /// <summary>
        /// Validate if Email Address input string is in correct format
        /// </summary>
        /// <param name="email">Email Address to be validated</param>
        /// <returns>true in case of valid email address</returns>
        public static bool ValidateEmailAddress(string email)
        {
            var regularExpr = new Regex(RegExEmail);
            return regularExpr.IsMatch(email);
        }

        /// <summary>
        /// Validates phone number
        /// </summary>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            var regularExpr = new Regex(RegExPhone);
            return regularExpr.IsMatch(phoneNumber);
        }

        /// <summary>
        /// This method take a comma separate string of email ids and returns comma
        /// separated string of only "invalid" email ids.
        /// </summary>
        /// <returns></returns>
        public static string GetInvalidEmailIds(string emailIds)
        {
            return GetInvalidValues(emailIds, RegExEmail);
        }

        public static string GetInvalidFaxNumbers(string faxNumbers)
        {
            return GetInvalidValues(faxNumbers, RegExPhone);
        }

        private static string GetInvalidValues(string values,
            string regularExpression)
        {
            const char Delimiter = ',';
            var regularExpr = new Regex(regularExpression);
            var invalidValues = new StringBuilder();

            string[] valuesList = values.Split(Delimiter);
            foreach (string t in valuesList)
            {
                string value = t.Trim();
                if (value.Length != 0 && !regularExpr.IsMatch(value))
                {
                    // Invalid value
                    if (valuesList.Length > 0)
                    {
                        invalidValues.Append(Delimiter);
                    }
                    invalidValues.Append(value);
                }
            }
            return invalidValues.ToString();
        }

        #endregion "Validations"

        #endregion "Data Formatting & Validating"



        #region "DataTable Related"

        /// <summary>
        /// Selects distinct values of the given column from the given source
        /// data table. For each distinct value of given column, the first row
        /// (by index) is kept while all other rows for same column value will
        /// be deleted.
        /// </summary>
        public static void SelectDistinct(DataTable source,
            string columnName)
        {
            var index = source.Columns.IndexOf(columnName);
            var distictValues = new Dictionary<object, int>();
            var indicesToRemove = new List<int>();
            var rows = source.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                var value = row[index];
                // Check if value exists or not
                if (distictValues.ContainsKey(value))
                {
                    indicesToRemove.Add(i);
                }
                else
                {
                    distictValues.Add(value, i);
                }
            }
            // Remove duplicate rows, we must traverse in reverse order
            for (var i = indicesToRemove.Count - 1; i >= 0; i--)
            {
                rows.RemoveAt(indicesToRemove[i]);
            }
        }

        /// <summary>
        /// Finds the first occurrence of row within the data table where the given
        /// column name contains the given value. Returns null if no such row
        /// is found.
        /// </summary>
        /// <remarks>This is intended to be a faster alternative when primary key is
        /// not set so one need use Rows.Select method to do a simple lookup.
        /// </remarks>
        public static DataRow Find(this DataTable source, string columnName,
            object value)
        {
            var columnIndex = source.Columns.IndexOf(columnName);
            var rows = source.Rows;
            var count = rows.Count;
            for (int i = 0; i < count; i++)
            {
                var row = rows[i];
                if (row[columnIndex].Equals(value))
                {
                    return row;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds all rows within the data table that satisfy the given predicate
        /// </summary>
        /// <remarks>This is intended to be a faster alternative when table has less
        /// rows and Rows.Select method can be overhead.
        /// </remarks>
        public static T[] FindAll<T>(this DataTable source, Predicate<T> predicate)
            where T : DataRow
        {
            var result = new List<T>();
            var rows = source.Rows;
            var count = rows.Count;
            for (int i = 0; i < count; i++)
            {
                var row = rows[i] as T;
                if (predicate(row))
                {
                    result.Add(row);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Converts the given data table into another table by mapping given
        /// source columns to given destination columns.
        /// </summary>
        /// <typeparam name="T">Destination data table type (allows to generate
        /// typed data table</typeparam>
        public static T ConvertTable<T>(DataTable source, string[] destinationColumns,
            string[] sourceColumns) where T : DataTable, new()
        {
            var result = new T();
            ConvertTable(result, source, sourceColumns, destinationColumns);
            return result;
        }

        /// <summary>
        /// Converts the given data table into another table by mapping given
        /// source columns to given destination columns.
        /// </summary>
        public static void ConvertTable(DataTable destination, DataTable source,
            string[] destinationColumns, string[] sourceColumns)
        {
            destination.Rows.Clear();

            // Find column indices
            var sourceIndices = new int[sourceColumns.Length];
            var destIndices = new int[destinationColumns.Length];
            for (int i = 0; i < sourceIndices.Length; i++)
            {
                sourceIndices[i] = source.Columns.IndexOf(sourceColumns[i]);
                destIndices[i] = destination.Columns.IndexOf(destinationColumns[i]);
            }
            // Convert rows one by one
            var rows = source.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                var dest = destination.NewRow();
                var src = rows[i];
                for (int j = 0; j < sourceIndices.Length; j++)
                {
                    dest[destIndices[j]] = src[sourceIndices[j]];
                }
                destination.Rows.Add(dest);
            }
        }

        #endregion "DataTable Related"

        #region "Other"

        /// <summary>
        /// Generates unique name
        /// </summary>
        public static string GetUniqueName()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Converts given string to appropriate data type
        /// </summary>
        public static object ConvertTo(string value, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.String:
                    return value;

                case DataType.Boolean:
                    return Convert.ToBoolean(value);

                case DataType.Currency:
                case DataType.Decimal:
                    return Convert.ToDecimal(value);

                case DataType.Integer:
                    return Convert.ToInt32(value);

                case DataType.Long:
                    return Convert.ToInt64(value);
            }
            return value;
        }

        #endregion "Other"

        #region "Random Number Generation"

        // Will be executed as if in static contractor
        private static readonly Random RandomNumber = new Random();

        private static readonly object RandomSyncLock = new object();

        /// <summary>
        /// Returns a non-negative random number.
        /// </summary>
        public static int GetRandom()
        {
            lock (RandomSyncLock)
            {
                return RandomNumber.Next();
            }
        }

        /// <summary>
        /// Returns a non-negative random number less than or equal to given
        /// upper bound.
        /// </summary>
        public static int GetRandom(int maxValue)
        {
            lock (RandomSyncLock)
            {
                return RandomNumber.Next(maxValue);
            }
        }

        #endregion "Random Number Generation"

        #region "Serialize and Deserialize object" 

        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                // Create a Type array.




                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringBuilder builder = new StringBuilder();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                using (XmlWriter stringWriter = XmlWriter.Create(builder, settings))
                {
                    serializer.Serialize(stringWriter, dataToSerialize);
                    return builder.ToString();
                }

            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion "Serialize and Deserialize object"

        public static string GetConfigKey(string key)
        {
            var val = ConfigurationManager.AppSettings[key];
            if (null != val)
            {
                return val;
            }
            return "";
        }
    }
}
