using System;

namespace Pipedrive
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
