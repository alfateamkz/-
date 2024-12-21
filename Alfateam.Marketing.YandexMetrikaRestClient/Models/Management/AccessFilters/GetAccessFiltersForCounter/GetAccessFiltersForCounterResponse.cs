using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters.GetAccessFiltersForCounter
{
    public class GetAccessFiltersForCounterResponse
    {
        [JsonProperty("access_filters")]
        public List<AccessFilterDto> AccessFilters { get; set; } = new List<AccessFilterDto>();
    }
}
