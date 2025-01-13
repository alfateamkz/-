using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.CheckCampaigns
{
    public class ChangesCheckCampaignsParamsBody
    {
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
