using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters
{
    public class FilterE
    {
        [JsonProperty("action")]
        public FilterAction Action { get; set; }

        [JsonProperty("attr")]
        public FilterAttr Attr { get; set; }

        [JsonProperty("status")]
        public FilterStatus Status { get; set; }

        [JsonProperty("type")]
        public FilterType Type { get; set; }

        [JsonProperty("end_ip")]
        public string EndIP { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("start_ip")]
        public string StartIP { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("with_subdomains")]
        public bool WithSubDomains { get; set; }
    }
}
