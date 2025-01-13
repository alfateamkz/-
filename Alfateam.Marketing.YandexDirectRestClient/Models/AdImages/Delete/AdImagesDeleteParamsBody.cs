using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Delete
{
    public class AdImagesDeleteParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public AdImageIdsCriteria SelectionCriteria { get; set; }
    }
}
