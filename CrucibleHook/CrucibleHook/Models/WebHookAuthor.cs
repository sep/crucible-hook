using Newtonsoft.Json;

namespace CrucibleHook.Models
{
    public class WebHookAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}