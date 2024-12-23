using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants
{
    public class WithCounterGrantEResponse
    {
        [JsonProperty("grant")]
        public CounterGrantE Grant { get; set; }
    }
}
