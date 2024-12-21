using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadRemoveSingleLine
{
    public class UploadRemoveSingleLineQueryParams
    {
        /// <summary>
        /// Дата в формате YYYY-MM-DD или диапазон дат в формате YYYY-MM-DD/YYYY-MM-DD.
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("UTMCampaign")]
        public string UTMCampaign { get; set; }

        [JsonProperty("UTMContent")]
        public string UTMContent { get; set; }

        [JsonProperty("UTMMedium")]
        public string UTMMedium { get; set; }

        [JsonProperty("UTMSource")]
        public string UTMSource { get; set; }

        [JsonProperty("UTMTerm")]
        public string UTMTerm { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("trafficSource")]
        public string TrafficSource { get; set; }

        [JsonProperty("trafficSourceDetail")]
        public string TrafficSourceDetail { get; set; }
    }
}
