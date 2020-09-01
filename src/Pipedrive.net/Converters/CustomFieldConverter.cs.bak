using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Pipedrive.CustomFields;

namespace Pipedrive.Internal
{
    public class CustomFieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IEntityWithCustomFields).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var customFields = new Dictionary<string, ICustomField>();

            var jObject = JObject.Load(reader);
            foreach (var property in jObject.Properties())
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
                                    customFields.Add(property.Name, new TimeRangeCustomField(
                                        TimeSpan.Parse((string)property.Value),
                                        TimeSpan.Parse((string)linkedProperties[$"{property.Name}_until"]),
                                        (int)linkedProperties[$"{property.Name}_timezone_id"]));
                                }

                                // Time
                                else
                                {
                                    customFields.Add(property.Name, new TimeCustomField(
                                        TimeSpan.Parse((string)property.Value),
                                        (int)linkedProperties[$"{property.Name}_timezone_id"]));
                                }
                            }

                            // Date range
                            else if (linkedProperties.Any(p => p.Key == $"{property.Name}_until"))
                            {
                                var startDate = (string)property.Value;
                                var endDate = (string)linkedProperties[$"{property.Name}_until"];
                                DateTime? fromDate = null;
                                DateTime? toDate = null;

                                if (!string.IsNullOrWhiteSpace(startDate) && startDate != "0000-00-00")
                                {
                                    if (DateTime.TryParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempFromDate))
                                    {
                                        fromDate = tempFromDate;
                                    }
                                }

                                if (!string.IsNullOrWhiteSpace(endDate) && endDate != "0000-00-00")
                                {
                                    if (DateTime.TryParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempToDate))
                                    {
                                        toDate = tempToDate;
                                    }
                                }

                                customFields.Add(
                                    property.Name,
                                    new DateRangeCustomField(fromDate, toDate));
                            }

                            // Address
                            else if (linkedProperties.Any(p => p.Key == $"{property.Name}_formatted_address"))
                            {
                                customFields.Add(
                                    property.Name,
                                    new AddressCustomField(
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
                                        (string)linkedProperties[$"{property.Name}_formatted_address"]));
                            }
                            else if (DateTime.TryParseExact((string)property.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime))
                            {
                                customFields.Add(property.Name, new DateCustomField(datetime));
                            }
                            else
                            {
                                customFields.Add(property.Name, new StringCustomField((string)property.Value));
                            }

                            break;
                        case JTokenType.Float:
                            // Monetary
                            if (linkedProperties.Any(p => p.Key == $"{property.Name}_currency"))
                            {
                                customFields.Add(property.Name, new MonetaryCustomField((decimal)property.Value, (string)linkedProperties[$"{property.Name}_currency"]));
                            }

                            // Decimal
                            else
                            {
                                customFields.Add(property.Name, new DecimalCustomField((decimal)property.Value));
                            }

                            break;
                        case JTokenType.Integer:
                            customFields.Add(property.Name, new LongCustomField((long)property.Value));
                            break;
                        case JTokenType.Object:
                            // User
                            if (((JObject)child).Properties().Any(p => p.Name == "has_pic"))
                            {
                                customFields.Add(property.Name, property.Value.ToObject<UserCustomField>());
                            }

                            // Organization
                            if (((JObject)child).Properties().Any(p => p.Name == "people_count"))
                            {
                                customFields.Add(property.Name, property.Value.ToObject<OrganizationCustomField>());
                            }

                            // Person
                            if (((JObject)child).Properties().Any(p => p.Name == "phone"))
                            {
                                customFields.Add(property.Name, property.Value.ToObject<PersonCustomField>());
                            }

                            break;
                        case JTokenType.Null:
                        case JTokenType.Undefined:
                            customFields.Add(property.Name, null);
                            break;
                    }
                }
            }

            IEntityWithCustomFields model = (IEntityWithCustomFields)Activator.CreateInstance(objectType);
            serializer.Populate(jObject.CreateReader(), model);
            model.CustomFields = customFields;

            return model;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = (JsonObjectContract)serializer
                .ContractResolver
                .ResolveContract(value.GetType());

            writer.WriteStartObject();

            foreach (var property in contract.Properties)
            {
                if (property.Ignored) continue;
                if (!ShouldSerialize(property, value)) continue;

                var property_name = property.PropertyName;
                var property_value = property.ValueProvider.GetValue(value);

                writer.WritePropertyName(property_name);
                if (property.Converter != null && property.Converter.CanWrite)
                {
                    property.Converter.WriteJson(writer, property_value, serializer);
                }
                else
                {
                    serializer.Serialize(writer, property_value);
                }
            }

            IDictionary<string, ICustomField> customFields = ((IEntityWithCustomFields)value).CustomFields;
            foreach (var field in customFields)
            {
                if (field.Value == null)
                {
                    writer.WritePropertyName(field.Key);
                    writer.WriteNull();
                }
                else
                {
                    switch (field.Value)
                    {
                        case StringCustomField s:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(s.Value);
                            break;
                        case LongCustomField i:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(i.Value);
                            break;
                        case DecimalCustomField d:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(d.Value);
                            break;
                        case DateCustomField d:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(d.Value);
                            break;
                        case TimeCustomField t:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(t.Value);
                            writer.WritePropertyName($"{field.Key}_timezone_id");
                            writer.WriteValue(t.TimezoneId);
                            break;
                        case MonetaryCustomField m:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(m.Value);
                            writer.WritePropertyName($"{field.Key}_currency");
                            writer.WriteValue(m.Currency);
                            break;
                        case TimeRangeCustomField tr:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(tr.StartTime);
                            writer.WritePropertyName($"{field.Key}_until");
                            writer.WriteValue(tr.EndTime);
                            writer.WritePropertyName($"{field.Key}_timezone_id");
                            writer.WriteValue(tr.TimezoneId);
                            break;
                        case DateRangeCustomField dr:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(dr.StartDate);
                            writer.WritePropertyName($"{field.Key}_until");
                            writer.WriteValue(dr.EndDate);
                            break;
                        case AddressCustomField a:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(a.Value);
                            writer.WritePropertyName($"{field.Key}_subpremise");
                            writer.WriteValue(a.Subpremise);
                            writer.WritePropertyName($"{field.Key}_street_number");
                            writer.WriteValue(a.StreetNumber);
                            writer.WritePropertyName($"{field.Key}_route");
                            writer.WriteValue(a.Route);
                            writer.WritePropertyName($"{field.Key}_sublocality");
                            writer.WriteValue(a.Sublocality);
                            writer.WritePropertyName($"{field.Key}_locality");
                            writer.WriteValue(a.Locality);
                            writer.WritePropertyName($"{field.Key}_admin_area_level_1");
                            writer.WriteValue(a.AdminAreaLevel1);
                            writer.WritePropertyName($"{field.Key}_admin_area_level_2");
                            writer.WriteValue(a.AdminAreaLevel2);
                            writer.WritePropertyName($"{field.Key}_country");
                            writer.WriteValue(a.Country);
                            writer.WritePropertyName($"{field.Key}_postal_code");
                            writer.WriteValue(a.PostalCode);
                            writer.WritePropertyName($"{field.Key}_formatted_address");
                            writer.WriteValue(a.FormattedAddress);
                            break;
                        case OrganizationCustomField org:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(org.Value);
                            break;
                        case PersonCustomField p:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(p.Value);
                            break;
                        case UserCustomField u:
                            writer.WritePropertyName(field.Key);
                            writer.WriteValue(u.Value);
                            break;
                    }
                }
            }

            writer.WriteEndObject();
        }

        private static bool ShouldSerialize(JsonProperty property, object instance)
        {
            return property.ShouldSerialize == null
                || property.ShouldSerialize(instance);
        }
    }
}
