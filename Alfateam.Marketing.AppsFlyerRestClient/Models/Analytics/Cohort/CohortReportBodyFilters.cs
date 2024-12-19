using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Analytics.Cohort
{
    public class CohortReportBodyFilters
    {

        [JsonProperty("ad_af")]
        public List<string> AdAf { get; set; } = new List<string>();
    
        [JsonProperty("ad_af_id")]
        public List<string> AdAfId { get; set; } = new List<string>();

        [JsonProperty("c")]
        public List<string> C { get; set; } = new List<string>();

        [JsonProperty("af_c_id")]
        public List<string> AfCId { get; set; } = new List<string>();

        [JsonProperty("af_channel")]
        public List<string> AfChannel { get; set; } = new List<string>();

        [JsonProperty("pid")]
        public List<string> Pid { get; set; } = new List<string>();

        [JsonProperty("af_sub1")]
        public List<string> AfSub1 { get; set; } = new List<string>();

        [JsonProperty("af_keywords")]
        public List<string> AfKeywords { get; set; } = new List<string>();

        [JsonProperty("af_prt")]
        public List<string> AfPrt { get; set; } = new List<string>();

        [JsonProperty("cohort_type")]
        public List<string> CohortType { get; set; } = new List<string>();
    
        [JsonProperty("site_id")]
        public List<string> SiteId { get; set; } = new List<string>();

        [JsonProperty("attributed_touch_type")]
        public List<string> AttributedTouchType { get; set; } = new List<string>();

        [JsonProperty("af_adset")]
        public List<string> AfAdset { get; set; } = new List<string>();

        [JsonProperty("af_adset_id")]
        public List<string> AfAdsetId { get; set; } = new List<string>();

        [JsonProperty("geo")]
        public List<string> Geo { get; set; } = new List<string>();

        [JsonProperty("date")]
        public List<string> Date { get; set; } = new List<string>();


        [JsonProperty("period")]
        public int Period { get; set; }
    }
}
