using AutoMapper;
using System;
using System.Globalization;

namespace BL.infrastructure
{
    internal class DateTimeToStringConverter : ITypeConverter<DateTime, string>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            object objDateTime = source;
            DateTime dateTime;
            if (!string.IsNullOrEmpty(source) && !string.IsNullOrWhiteSpace(source))
            {
                return default(DateTime);
            }
            if (objDateTime == null)
            {
                return default(DateTime);
            }

            if (DateTime.TryParseExact(objDateTime.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else if (DateTime.TryParseExact(objDateTime.ToString(), "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else if (DateTime.TryParse(objDateTime.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            return default(DateTime);
        }

        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            if (source != null)
            {
                return source.ToString("dd/MM/yyyy");
            }
            else
            {
                return string.Empty;
            }
        }
    }

}