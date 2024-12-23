using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters.GetFilters
{
    public class GetFiltersQueryParams
    {
        [JsonProperty("callback")]
        public string Callback { get; set; }
    }
}
