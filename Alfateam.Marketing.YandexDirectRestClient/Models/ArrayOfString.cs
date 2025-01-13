using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class ArrayOfString
    {
        [JsonProperty("Items")]
        public List<string> Items { get; set; } = new List<string>();
    }
}
