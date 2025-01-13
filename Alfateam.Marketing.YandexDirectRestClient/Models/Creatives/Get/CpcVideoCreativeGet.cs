using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Get
{
    public class CpcVideoCreativeGet
    {
        [JsonProperty("Duration")]
        public int Duration { get; set; }
    }
}
