using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        public NewUser(string name, string email, bool activeFlag)
        {
            this.Name = name;
            this.Email = email;
            this.ActiveFlag = activeFlag;
        }
    }
}
