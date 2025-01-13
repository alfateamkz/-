using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Delete
{
    public class AdImagesDeleteResultBody
    {
        [JsonProperty("DeleteResults")]
        public List<AdImageActionResult> DeleteResults { get; set; } = new List<AdImageActionResult>();
    }
}
