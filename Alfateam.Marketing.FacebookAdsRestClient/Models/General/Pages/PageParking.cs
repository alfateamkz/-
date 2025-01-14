using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages
{
    public class PageParking
    {
        [JsonProperty("lot")]
        public bool Lot { get; set; }

        [JsonProperty("street")]
        public bool Street { get; set; }

        [JsonProperty("valet")]
        public bool Valet { get; set; }
    }
}
