using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesPopular
{
    public class HostSearchQueriesPopularQueryParams
    {
        [JsonProperty("order_by")]
        public ApiQueryOrderField OrderBy { get; set; }

        [JsonProperty("query_indicator")]
        public ApiQueryIndicator QueryIndicator { get; set; }

        [JsonProperty("device_type_indicator")]
        public ApiDeviceTypeIndicator DeviceTypeIndicator { get; set; }

        [JsonProperty("date_from")]
        public DateTime DateFrom { get; set; }

        [JsonProperty("date_to")]
        public DateTime DateTo { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
