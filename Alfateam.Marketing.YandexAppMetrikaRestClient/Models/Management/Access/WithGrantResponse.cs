using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access
{
    public class WithGrantResponse
    {
        [JsonProperty("grant")]
        public Grant Grant { get; set; }
    }
}
