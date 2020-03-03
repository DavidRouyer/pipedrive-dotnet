﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class NewOrganization : IEntityWithCustomFields
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; } = Visibility.shared;

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewOrganization(string name)
        {
            this.Name = name;
        }
    }
}
