using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Get
{
    public class AdImageSelectionCriteria
    {
        [JsonProperty("AdImageHashes")]
        public List<string> AdImageHashes { get; set; } = new List<string>();

        [JsonProperty("Associated")]
        public YesNoEnum Associated { get; set; }
    }
}
