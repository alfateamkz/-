using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Grants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants.GetGrants
{
    public class GetGrantsResponse
    {
        [JsonProperty("grants")]
        public List<CounterGrantEPerm> Grants { get; set; } = new List<CounterGrantEPerm>();
    }
}
