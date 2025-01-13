using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Add
{
    public class CreativesAddParamsBody
    {
        [JsonProperty("Creatives")]
        public List<CreativeAddItem> Creatives { get; set; } = new List<CreativeAddItem>();
    }
}
