﻿namespace Pipedrive.CustomFields
{
    // long
    public class LongCustomField : ICustomField
    {
        public long Value { get; set; }

        public LongCustomField(long value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
