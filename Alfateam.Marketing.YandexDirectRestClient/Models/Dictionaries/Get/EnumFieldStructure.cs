using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class EnumFieldStructure
    {
        [JsonProperty("Values")]
        public List<EnumFieldStructureItem> Values { get; set; } = new List<EnumFieldStructureItem>();
    }
}
