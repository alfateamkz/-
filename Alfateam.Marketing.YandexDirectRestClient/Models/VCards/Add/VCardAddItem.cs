using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.VCards.Add
{
    public class VCardAddItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty("WorkTime")]
        public string WorkTime { get; set; }

        [JsonProperty("Phone")]
        public Phone Phone { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("House")]
        public string House { get; set; }

        [JsonProperty("Building")]
        public string Building { get; set; }

        [JsonProperty("Apartment")]
        public string Apartment { get; set; }

        [JsonProperty("InstantMessenger")]
        public InstantMessenger InstantMessenger { get; set; }

        [JsonProperty("ExtraMessage")]
        public string ExtraMessage { get; set; }

        [JsonProperty("ContactEmail")]
        public string ContactEmail { get; set; }

        [JsonProperty("Ogrn")]
        public string Ogrn { get; set; }

        [JsonProperty("MetroStationId")]
        public long MetroStationId { get; set; }

        [JsonProperty("PointOnMap")]
        public MapPoint PointOnMap { get; set; }

        [JsonProperty("ContactPerson")]
        public string ContactPerson { get; set; }
    }
}
