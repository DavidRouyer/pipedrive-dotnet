using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("default_currency")]
        public string DefaultCurrency { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("lang")]
        public int Lang { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("activated")]
        public bool Activated { get; set; }

        [JsonProperty("last_login")]
        [JsonConverter(typeof(ZeroDateConverter))]
        public DateTime? LastLogin { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }

        [JsonProperty("signup_flow_variation")]
        public string SignupFlowVariation { get; set; }

        [JsonProperty("has_created_company")]
        public bool HasCreatedCompany { get; set; }

        [JsonProperty("is_admin")]
        public int IsAdmin { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("timezone_offset")]
        public string TimezoneOffset { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("is_you")]
        public bool IsYou { get; set; }

        [JsonProperty("company_id")]
        public string CompanyId { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName{ get; set; }

        [JsonProperty("company_domain")]
        public string CompanyDomain { get; set; }

        public UserUpdate ToUpdate()
        {
            return new UserUpdate
            {
                Name = Name,
                Email = Email,
                ActiveFlag = ActiveFlag
            };
        }
    }
}
