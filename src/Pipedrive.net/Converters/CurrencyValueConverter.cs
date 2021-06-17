using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pipedrive.Internal
{
    public class CurrencyValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, decimal>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = new Dictionary<string, decimal>();

            Console.WriteLine(reader.TokenType);
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jObject = JObject.Load(reader);
                foreach (var property in jObject.Properties())
                {
                    values.Add(property.Name, property.Value.ToObject<decimal>());
                }
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                JArray.Load(reader);
            }

            return values;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
