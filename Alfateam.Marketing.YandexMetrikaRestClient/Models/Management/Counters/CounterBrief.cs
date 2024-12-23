using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters.CounterFull;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class CounterBrief
    {
        [JsonProperty("activity_status")]
        public CounterFullActivityStatus ActivityStatus { get; set; }

        [JsonProperty("code_options")]
        public CodeOptionsE CodeOptions { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("filters")]
        public List<FilterE> Filters { get; set; } = new List<FilterE>();

        [JsonProperty("gdpr_agreement_accepted")]
        public bool GDPRAgreementAccepted { get; set; }

        [JsonProperty("goals")]
        public List<GoalE> Goals { get; set; } = new List<GoalE>();

        [JsonProperty("grants")]
        public List<CounterGrantE> Grants { get; set; } = new List<CounterGrantE>();

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("labels")]
        public List<Label> Labels { get; set; } = new List<Label>();

        [JsonProperty("mirrors2")]
        public List<CounterMirrorE> Mirrors2 { get; set; } = new List<CounterMirrorE>();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("operations")]
        public List<OperationE> Operations { get; set; } = new List<OperationE>();

        [JsonProperty("owner_login")]
        public string OwnerLogin { get; set; }

        [JsonProperty("permission")]
        public CounterFullPermission Permission { get; set; }

        [JsonProperty("site2")]
        public CounterMirrorE Site2 { get; set; }

        [JsonProperty("source")]
        public CounterFullSource Source { get; set; }

        [JsonProperty("status")]
        public CounterFullStatus Status { get; set; }

        [JsonProperty("time_zone_name")]
        public string TimeZoneName { get; set; }

        [JsonProperty("time_zone_offset")]
        public int TimeZoneOffset { get; set; }

        [JsonProperty("type")]
        public CounterFullType Type { get; set; }

        [JsonProperty("webvisor")]
        public WebvisorOptions Webvisor { get; set; }
    }
}
