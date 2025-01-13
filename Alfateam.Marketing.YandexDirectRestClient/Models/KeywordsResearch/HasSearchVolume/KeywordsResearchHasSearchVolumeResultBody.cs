using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.HasSearchVolume
{
    public class KeywordsResearchHasSearchVolumeResultBody
    {
        [JsonProperty("HasSearchVolumeResults")]
        public List<HasSearchVolumeItem> HasSearchVolumeResults { get; set; } = new List<HasSearchVolumeItem>();
    }
}
