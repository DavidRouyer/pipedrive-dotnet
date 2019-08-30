using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Pipedrive.Internal
{
    public class RecentsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IRecentsEntity).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IRecentsEntity recentsEntity = null;

            var jObject = JObject.Load(reader);

            foreach (var property in jObject.Properties())
            {
                if (property.Name == "item")
                {
                    var dataProperty = jObject.Properties().Where(p => p.Name == "data");
                    var dataObject = dataProperty.Children().FirstOrDefault();
                    switch ((string)property.Value)
                    {
                        case "activity":
                            recentsEntity = dataObject.ToObject<Activity>();
                            break;

                        case "deal":
                            recentsEntity = dataObject.ToObject<DealRecent>();
                            break;
                    }
                    break;
                }
            }

            var model = (Recents)Activator.CreateInstance(objectType);
            serializer.Populate(jObject.CreateReader(), model);
            model.Data = recentsEntity;

            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
