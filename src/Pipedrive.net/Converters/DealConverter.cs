using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pipedrive.Internal
{
    public class DealConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Deal);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var userDealFields = new Dictionary<string, IField>();
            foreach(var property in jObject.Properties())
            {
                if (property.Name.Length == 40)
                {
                    var child = property.Children().FirstOrDefault();
                    var linkedProperties = jObject
                        .Properties()
                        .Where(p => p.Name.StartsWith(property.Name))
                        .ToDictionary(t => t.Name, t => t.Value);
                    DateTime datetime;

                    switch (child.Type)
                    {
                        case JTokenType.String:
                            // Time/Time range
                            if (linkedProperties.Any(p => p.Key == $"{property.Name}_timezone_id"))
                            {
                                // Time range
                                if (linkedProperties.Any(p => p.Key == $"{property.Name}_until"))
                                {
                                    userDealFields.Add(property.Name, new TimeRangeField(
                                        TimeSpan.Parse((string)property.Value),
                                        TimeSpan.Parse((string)linkedProperties[$"{property.Name}_until"]),
                                        (int)linkedProperties[$"{property.Name}_timezone_id"]
                                        ));
                                }
                                // Time
                                else
                                {
                                    userDealFields.Add(property.Name, new TimeField(
                                        TimeSpan.Parse((string)property.Value),
                                        (int)linkedProperties[$"{property.Name}_timezone_id"]
                                        ));
                                }
                            // Date range
                            } else if (linkedProperties.Any(p => p.Key == $"{property.Name}_until"))
                            {
                                userDealFields.Add(
                                    property.Name,
                                    new DateRangeField(DateTime.Parse((string)property.Value),
                                    DateTime.Parse((string)linkedProperties[$"{property.Name}_until"])));
                            }
                            // Address
                            else if (linkedProperties.Any(p => p.Key == $"{property.Name}_formatted_address"))
                            {
                                userDealFields.Add(
                                    property.Name,
                                    new AddressField(
                                        (string)property.Value,
                                        (string)linkedProperties[$"{property.Name}_subpremise"],
                                        (string)linkedProperties[$"{property.Name}_street_number"],
                                        (string)linkedProperties[$"{property.Name}_route"],
                                        (string)linkedProperties[$"{property.Name}_sublocality"],
                                        (string)linkedProperties[$"{property.Name}_locality"],
                                        (string)linkedProperties[$"{property.Name}_admin_area_level_1"],
                                        (string)linkedProperties[$"{property.Name}_admin_area_level_2"],
                                        (string)linkedProperties[$"{property.Name}_country"],
                                        (string)linkedProperties[$"{property.Name}_postal_code"],
                                        (string)linkedProperties[$"{property.Name}_formatted_address"]
                                    )
                                );
                            }
                            else if (DateTime.TryParseExact((string)property.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime))
                            {
                                userDealFields.Add(property.Name, new DateField(datetime));
                            }
                            else
                            {
                                userDealFields.Add(property.Name, new StringField((string)property.Value));
                            }
                            break;
                        case JTokenType.Float:
                            // Monetary
                            if (linkedProperties.Any(p => p.Key == $"{property.Name}_currency"))
                            {
                                userDealFields.Add(property.Name, new MonetaryField((decimal)property.Value, (string)linkedProperties[$"{property.Name}_currency"]));
                            }
                            // Decimal
                            else
                            {
                                userDealFields.Add(property.Name, new DecimalField((decimal)property.Value));
                            }
                            break;
                        case JTokenType.Integer:
                            userDealFields.Add(property.Name, new IntField((int)property.Value));
                            break;
                        case JTokenType.Object:
                            // User
                            if (((JObject)child).Properties().Any(p => p.Name == "has_pic"))
                            {
                                userDealFields.Add(property.Name, property.Value.ToObject<UserSummary>());
                            }
                            // Organization
                            if (((JObject)child).Properties().Any(p => p.Name == "people_count"))
                            {
                                userDealFields.Add(property.Name, property.Value.ToObject<OrganizationSummary>());
                            }
                            // Person
                            if (((JObject)child).Properties().Any(p => p.Name == "phone"))
                            {
                                userDealFields.Add(property.Name, property.Value.ToObject<PersonSummary>());
                            }
                            break;
                    }
                }
            }
            Deal model = new Deal();
            serializer.Populate(jObject.CreateReader(), model);
            model.UserDealFields = userDealFields;
            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}
