using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Grants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants
{
    public class AccessFiltersGrantE : CounterGrantE
    {
        [JsonProperty("access_filters")]
        public List<AccessFiltersShortE> AccessFilters { get; set; } = new List<AccessFiltersShortE>();
    }
}
