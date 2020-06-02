using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class DealField
    {
        public long? Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        [JsonProperty("order_nr")]
        public long OrderNr { get; set; }

        [JsonProperty("field_type")]
        public FieldType FieldType { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("edit_flag")]
        public bool EditFlag { get; set; }

        [JsonProperty("index_visible_flag")]
        public bool IndexVisibleFlag { get; set; }

        [JsonProperty("details_visible_flag")]
        public bool DetailsVisibleFlag { get; set; }

        [JsonProperty("add_visible_flag")]
        public bool AddVisibleFlag { get; set; }

        [JsonProperty("important_flag")]
        public bool ImportantFlag { get; set; }

        [JsonProperty("bulk_edit_allowed")]
        public bool BulkEditAllowed { get; set; }

        [JsonProperty("searchable_flag")]
        public bool SearchableFlag { get; set; }

        [JsonProperty("filtering_allowed")]
        public bool FilteringAllowed { get; set; }

        [JsonProperty("sortable_flag")]
        public bool SortableFlag { get; set; }

        [JsonProperty("use_field")]
        public string UseField { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("options")]
        public IReadOnlyList<Option> Options { get; set; }

        [JsonProperty("mandatory_flag")]
        public object MandatoryFlag { get; set; } // TODO: boolean or object like { "org_id": "<=0" }

        public DealFieldUpdate ToUpdate()
        {
            return new DealFieldUpdate
            {
                Name = Name,
                Options = Options
            };
        }
    }
}
