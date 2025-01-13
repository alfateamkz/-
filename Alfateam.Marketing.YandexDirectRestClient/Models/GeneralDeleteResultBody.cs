using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class GeneralDeleteResultBody
    {
        [JsonProperty("DeleteResults")]
        public List<ActionResult> DeleteResults { get; set; } = new List<ActionResult>();
    }
}
