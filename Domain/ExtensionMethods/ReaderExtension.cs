using System;
using System.Data.SqlClient;
using System.Globalization;

namespace Domain.ExtensionMethods
{
    public static class ReaderExtension
    {
        public static int IntValue(this SqlDataReader dataReader, string parameter, int defaultValue = 0)
        {
            return string.IsNullOrEmpty(dataReader.StringValue(parameter)) ? defaultValue : Convert.ToInt32(dataReader[parameter]);
        }

        public static long LongValue(this SqlDataReader dataReader, string parameter, long defaultValue = 0)
        {
            return string.IsNullOrEmpty(dataReader.StringValue(parameter)) ? defaultValue : Convert.ToInt64(dataReader[parameter]);
        }

        public static decimal DecimalValue(this SqlDataReader dataReader, string parameter, decimal defaultValue = 0)
        {
            return string.IsNullOrEmpty(dataReader.StringValue(parameter)) ? defaultValue : Convert.ToDecimal(dataReader[parameter]);
        }

        public static DateTime DateTimeValue(this SqlDataReader dataReader, string parameter, DateTime defaultValue = default)
        {
            return string.IsNullOrEmpty(dataReader.StringValue(parameter)) ?
                Convert.ToDateTime(defaultValue.ToStringDateTime(), CultureInfo.GetCultureInfo("es-DO")) :
                Convert.ToDateTime(dataReader[parameter], CultureInfo.GetCultureInfo("es-DO"));
        }

        public static string StringValue(this SqlDataReader dataReader, string parameter)
        {
            return dataReader[parameter].ToString();
        }
    }
}
