using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Pipedrive.Converters
{
    public class WebhookNullConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token == null || token.Type == JTokenType.Null)
                return null;
            return token.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
