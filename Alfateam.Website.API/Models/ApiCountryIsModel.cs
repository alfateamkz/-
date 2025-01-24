using Newtonsoft.Json;

namespace Alfateam.Website.API.Models
{
    public class ApiCountryIsModel
    {
        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
