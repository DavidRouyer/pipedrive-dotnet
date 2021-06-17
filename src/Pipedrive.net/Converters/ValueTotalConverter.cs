using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pipedrive.Internal
{
    public class ValueTotalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, ValueTotal>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = new Dictionary<string, ValueTotal>();

            var jObject = JObject.Load(reader);
            foreach (var property in jObject.Properties())
            {
                values.Add(property.Name, property.Value.ToObject<ValueTotal>());
            }

            return values;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
