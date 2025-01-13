using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages
{
    public class AdImageIdsCriteria
    {
        [JsonProperty("AdImageHashes")]
        public List<string> AdImageHashes { get; set; } = new List<string>();
    }
}
