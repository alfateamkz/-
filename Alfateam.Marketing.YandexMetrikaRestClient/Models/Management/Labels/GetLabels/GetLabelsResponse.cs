using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels.GetLabels
{
    public class GetLabelsResponse
    {
        [JsonProperty("labels")]
        public List<Label> Labels { get; set; } = new List<Label>();
    }
}
