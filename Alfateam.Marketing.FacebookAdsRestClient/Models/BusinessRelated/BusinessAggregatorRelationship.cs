using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Applications;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class BusinessAggregatorRelationship
    {
        [JsonProperty("ad_accounts")]
        public List<AdAccount> AdAccounts { get; set; } = new List<AdAccount>();

        [JsonProperty("application")]
        public Application Application { get; set; }

        [JsonProperty("system_user")]
        public SystemUser SystemUser { get; set; }
    }
}
