﻿using System;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(DealUpdateConverter))]
    public class DealUpdateFlow
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public IDealUpdateEntity Data { get; set; }
    }
}
