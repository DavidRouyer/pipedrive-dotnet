
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
namespace Pipedrive.Converters
{
    public class WebhookNullConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token == null || token.Type == JTokenType.Null)
            {
                return null;
            }

            return token.ToObject(objectType);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
