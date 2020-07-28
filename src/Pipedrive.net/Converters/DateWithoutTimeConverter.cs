using Newtonsoft.Json.Converters;

namespace Pipedrive.Converters
{
    class DateWithoutTimeConverter : IsoDateTimeConverter
    {
        public DateWithoutTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
