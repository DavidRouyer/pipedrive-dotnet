using Newtonsoft.Json;

namespace Pipedrive
{
    public class SimpleDeal
    {
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("status")]
        public DealStatus Status { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("owner")]
        public SearchOwner Owner { get; set; }

        [JsonProperty("stage")]
        public SearchStage Stage { get; set; }

        [JsonProperty("person")]
        public SearchPerson Person { get; set; }

        [JsonProperty("organization")]
        public SearchOrganization Organization { get; set; }

        [JsonProperty("notes")]
        public string[] Notes { get; set; }

        [JsonProperty("cc_email")]
        public string CcEmail { get; set; }
    }

    public class SearchOwner
    {
        public long Id { get; set; }
    }

    public class SearchStage
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class SearchPerson
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class SearchOrganization
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
