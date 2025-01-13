using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Add
{
    public class AdImagesAddResultBody
    {
        [JsonProperty("AddResults")]
        public List<AdImageActionResult> AddResults { get; set; } = new List<AdImageActionResult>();
    }
}
