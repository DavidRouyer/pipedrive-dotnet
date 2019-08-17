using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class ActivityField
    {
        public long? Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        [JsonProperty("order_nr")]
        public int OrderNr { get; set; }

        [JsonProperty("field_type")]
        public string FieldType { get; set; }

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

        [JsonProperty("mandatory_flag")]
        public bool MandatoryFlag { get; set; }

        public IReadOnlyList<Option> Options { get; set; }
    }
}
