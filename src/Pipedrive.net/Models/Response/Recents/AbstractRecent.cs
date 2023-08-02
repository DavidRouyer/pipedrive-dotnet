using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Pipedrive.Models.Response.Recents
{
    public abstract class AbstractRecent<TData>
    {
        public long Id { get; set; }
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}
