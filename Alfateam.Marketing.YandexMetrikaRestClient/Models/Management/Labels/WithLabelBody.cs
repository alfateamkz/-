using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels
{
    public class WithLabelBody
    {
        [JsonProperty("label")]
        public Label Label { get; set; }
    }
}
