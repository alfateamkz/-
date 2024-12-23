using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants
{
    public class WithCounterGrantEBody
    {
        [JsonProperty("grant")]
        public CounterGrantE Grant { get; set; }
    }
}
