using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.CreateApplication
{
    public class CreateApplicationBody
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("time_zone_name")]
        public string TimeZoneName { get; set; }

        [JsonProperty("hide_address")]
        public bool HideAddress { get; set; }

        [JsonProperty("gdpr_agreement_accepted")]
        public bool GDPRAgreementAccepted { get; set; }
    }
}
