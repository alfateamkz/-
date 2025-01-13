using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class GeneralSuspendResultBody
    {
        [JsonProperty("SuspendResults")]
        public List<ActionResult> SuspendResults { get; set; } = new List<ActionResult>();
    }
}
