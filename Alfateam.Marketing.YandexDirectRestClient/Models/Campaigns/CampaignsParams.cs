using Alfateam.Marketing.YandexDirectRestClient.Enums.Campaigns;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Campaigns
{
    public class CampaignsParams<T>
    {
        [JsonProperty("method")]
        public CampaignsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
