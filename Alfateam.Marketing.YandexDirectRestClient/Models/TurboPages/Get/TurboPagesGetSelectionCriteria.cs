using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.TurboPages.Get
{
    public class TurboPagesGetSelectionCriteria : IdsCriteria
    {
        [JsonProperty("BoundWithHrefs")]
        public List<string> BoundWithHrefs { get; set; } = new List<string>();
    }
}
