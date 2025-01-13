using Alfateam.Marketing.YandexDirectRestClient.Abstractions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class ActionResult : AbsActionResult
    {
        [JsonProperty("Id")]
        public long Id { get; set; }
    }
}
