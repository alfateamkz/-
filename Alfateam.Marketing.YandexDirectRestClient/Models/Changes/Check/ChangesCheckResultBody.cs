using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.Check
{
    public class ChangesCheckResultBody
    {
        [JsonProperty("Modified")]
        public CheckResponseModified Modified { get; set; }

        [JsonProperty("NotFound")]
        public CheckResponseIds NotFound { get; set; }

        [JsonProperty("Unprocessed")]
        public CheckResponseIds Unprocessed { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
