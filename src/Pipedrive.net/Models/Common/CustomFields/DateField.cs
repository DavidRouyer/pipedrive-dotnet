using System;

namespace Pipedrive.CustomFields
{
    public class DateField : IField
    {
        public DateTime Value { get; set; }

        public DateField(DateTime value)
        {
            Value = value;
        }
    }
}
