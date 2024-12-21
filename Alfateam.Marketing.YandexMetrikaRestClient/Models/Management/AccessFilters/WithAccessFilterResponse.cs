using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters
{
    public class WithAccessFilterResponse
    {
        [JsonProperty("access_filter")]
        public AccessFilterDto AccessFilter { get; set; }
    }
}
