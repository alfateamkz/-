using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class GeneralArchiveResultBody
    {
        [JsonProperty("ArchiveResults")]
        public List<ActionResult> ArchiveResults { get; set; } = new List<ActionResult>();
    }
}
