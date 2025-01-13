using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class IdsCriteria
    {
        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();
    }
}
