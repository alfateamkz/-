using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.SavedAudiences;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.SavedAudiences
{
    public class SavedAudience
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account")]
        public AdAccount Account { get; set; }

        [JsonProperty("approximate_count_lower_bound")]
        public int ApproximateCountLowerBound { get; set; }

        [JsonProperty("approximate_count_upper_bound")]
        public int ApproximateCountUpperBound { get; set; }

        [JsonProperty("delete_time")]
        public DateTime DeleteTime { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("page_deletion_marked_delete_time")]
        public int PageDeletionMarkedDeleteTime { get; set; }

        [JsonProperty("permission_for_actions")]
        public AudiencePermissionForActions PermissionForActions { get; set; }

        [JsonProperty("run_status")]
        public SavedAudienceRunStatus RunStatus { get; set; }

        [JsonProperty("sentence_lines")]
        public List<object> SentenceLines { get; set; }= new List<object>(); //TODO: find structure

        [JsonProperty("targeting")]
        public Targeting Targeting { get; set; }

        [JsonProperty("time_created")]
        public DateTime TimeCreated { get; set; }

        [JsonProperty("time_updated")]
        public DateTime TimeUpdated { get; set; }
    }
}
