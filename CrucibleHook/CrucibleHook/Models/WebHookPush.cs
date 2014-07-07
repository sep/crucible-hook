using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrucibleHook.Models
{
    public class WebHookPush
    {
        [JsonProperty("before")]
        public string CommitHashBefore { get; set; }

        [JsonProperty("after")]
        public string CommitHashAfter { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("repository")]
        public WebHookRepository Repository { get; set; }

        [JsonProperty("commits")]
        public IEnumerable<WebHookCommit> Commits { get; set; }

        [JsonProperty("total_commits_count")]
        public int TotalCommitCount { get; set; }
    }
}