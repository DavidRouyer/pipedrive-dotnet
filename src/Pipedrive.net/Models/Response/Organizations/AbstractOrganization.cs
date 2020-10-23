using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public abstract class AbstractOrganization<TUser, TPicture>
    {
        public long Id { get; set; }

        [JsonProperty("company_id")]
        public long CompanyId { get; set; }

        [JsonProperty("owner_id")]
        public TUser OwnerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("open_deals_count")]
        public long OpenDealsCount { get; set; }

        [JsonProperty("related_open_deals_count")]
        public long RelatedOpenDealsCount { get; set; }

        [JsonProperty("closed_deals_count")]
        public long ClosedDealsCount { get; set; }

        [JsonProperty("related_closed_deals_count")]
        public long RelatedClosedDealsCount { get; set; }

        [JsonProperty("email_messages_count")]
        public long EmailMessagesCount { get; set; }

        [JsonProperty("people_count")]
        public long PeopleCount { get; set; }

        [JsonProperty("activities_count")]
        public long ActivitiesCount { get; set; }

        [JsonProperty("done_activities_count")]
        public long DoneActivitiesCount { get; set; }

        [JsonProperty("undone_activities_count")]
        public long UndoneActivitiesCount { get; set; }

        [JsonProperty("reference_activities_count")]
        public long ReferenceActivitiesCount { get; set; }

        [JsonProperty("files_count")]
        public long FilesCount { get; set; }

        [JsonProperty("notes_count")]
        public long NotesCount { get; set; }

        [JsonProperty("followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty("won_deals_count")]
        public long WonDealsCount { get; set; }

        [JsonProperty("related_won_deals_count")]
        public long RelatedWonDealsCount { get; set; }

        [JsonProperty("lost_deals_count")]
        public long LostDealsCount { get; set; }

        [JsonProperty("related_lost_deals_count")]
        public long RelatedLostDealsCount { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("category_id")]
        public long? CategoryId { get; set; }

        [JsonProperty("picture_id")]
        public TPicture PictureId { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("first_char")]
        public char FirstChar { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("next_activity_date")]
        public string NextActivityDate { get; set; }

        [JsonProperty("next_activity_time")]
        public string NextActivityTime { get; set; }

        [JsonProperty("next_activity_id")]
        public long? NextActivityId { get; set; }

        [JsonProperty("last_activity_id")]
        public long? LastActivityId { get; set; }

        [JsonProperty("last_activity_date")]
        public string LastActivityDate { get; set; }

        [JsonProperty("timeline_last_activity_time")]
        public string TimelineLastActivityTime { get; set; }

        [JsonProperty("timeline_last_activity_time_by_owner")]
        public string TimelineLastActivityTimeByOwner { get; set; }

        [JsonProperty("label")]
        public long? Label { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address_subpremise")]
        public string AddressSubpremise { get; set; }

        [JsonProperty("address_street_number")]
        public string AddressStreetNumber { get; set; }

        [JsonProperty("address_route")]
        public string AddressRoute { get; set; }

        [JsonProperty("address_sublocality")]
        public string AddressSublocality { get; set; }

        [JsonProperty("address_locality")]
        public string AddressLocality { get; set; }

        [JsonProperty("address_admin_area_level_1")]
        public string AddressAdminAreaLevel1 { get; set; }

        [JsonProperty("address_admin_area_level_2")]
        public string AddressAdminAreaLevel2 { get; set; }

        [JsonProperty("address_country")]
        public string AddressCountry { get; set; }

        [JsonProperty("address_postal_code")]
        public string AddressPostalCode { get; set; }

        [JsonProperty("address_formatted_address")]
        public string AddressFormattedAddress { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("cc_email")]
        public string CcEmail { get; set; }
    }
}
