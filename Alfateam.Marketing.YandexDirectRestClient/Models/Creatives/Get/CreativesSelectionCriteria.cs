using Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Get
{
    public class CreativesSelectionCriteria : IdsCriteria
    {
        [JsonProperty("Types")]
        public List<CreativeTypeEnum> Types { get; set; } = Enum.GetValues<CreativeTypeEnum>().ToList();
    }
}
