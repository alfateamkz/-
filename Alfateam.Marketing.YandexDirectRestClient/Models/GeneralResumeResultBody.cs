using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class GeneralResumeResultBody
    {
        [JsonProperty("ResumeResults")]
        public List<ActionResult> ResumeResults { get; set; } = new List<ActionResult>();
    }
}
