using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class PublisherOptions
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("schema")]
        public PublisherOptionsSchema Schema { get; set; }

        [JsonProperty("schema_options")]
        public List<PublisherOptionsSchema> SchemaOptions { get; set; } = new List<PublisherOptionsSchema>();
    }
}
