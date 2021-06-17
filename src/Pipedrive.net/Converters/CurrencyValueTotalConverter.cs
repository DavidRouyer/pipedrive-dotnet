using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pipedrive.Internal
{
    public class CurrencyValueTotalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, CurrencyValueTotal>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = new Dictionary<string, CurrencyValueTotal>();

            var jObject = JObject.Load(reader);
            foreach (var property in jObject.Properties())
            {
                values.Add(property.Name, property.Value.ToObject<CurrencyValueTotal>());
            }

            return values;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
