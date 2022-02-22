using System;
using System.Globalization;

namespace Domain.ExtensionMethods
{
    public static class DateTimeExtension
    {
        public static string ToStringDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.GetCultureInfo("es-DO"));
        }
    }
}
