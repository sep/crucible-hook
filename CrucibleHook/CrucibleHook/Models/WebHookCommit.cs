using System;
using Newtonsoft.Json;

namespace CrucibleHook.Models
{
    public class WebHookCommit
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("author")]
        public WebHookAuthor Author { get; set; }
    }
}