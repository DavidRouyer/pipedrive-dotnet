using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Pipedrive.Internal
{
    public class DealUpdateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDealUpdateEntity).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IDealUpdateEntity dealUpdateEntity = null;

            var jObject = JObject.Load(reader);

            foreach (var property in jObject.Properties())
            {
                if (property.Name == "object")
                {
                    var dataProperty = jObject.Properties().Where(p => p.Name == "data");
                    var dataObject = dataProperty.Children().FirstOrDefault();
                    switch ((string)property.Value)
                    {
                        case "activity":
                            dealUpdateEntity = dataObject.ToObject<Activity>();
                            break;
                        case "note":
                            dealUpdateEntity = dataObject.ToObject<Note>();
                            break;
                        case "mailMessage":
                            dealUpdateEntity = dataObject.ToObject<MailMessage>();
                            break;
                        case "file":
                            dealUpdateEntity = dataObject.ToObject<File>();
                            break;
                        case "dealChange":
                            dealUpdateEntity = dataObject.ToObject<DealChange>();
                            break;
                    }
                    break;
                }
            }

            DealUpdateFlow model = (DealUpdateFlow)Activator.CreateInstance(objectType);
            serializer.Populate(jObject.CreateReader(), model);
            model.Data = dealUpdateEntity;

            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
