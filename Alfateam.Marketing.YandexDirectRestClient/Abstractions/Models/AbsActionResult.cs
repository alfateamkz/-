using Alfateam.Marketing.YandexDirectRestClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Abstractions.Models
{
    public abstract class AbsActionResult
    {
        [JsonProperty("Warnings")]
        public List<ExceptionNotification> Warnings { get; set; } = new List<ExceptionNotification>();

        [JsonProperty("Errors")]
        public List<ExceptionNotification> Errors { get; set; } = new List<ExceptionNotification>();
    }
}
