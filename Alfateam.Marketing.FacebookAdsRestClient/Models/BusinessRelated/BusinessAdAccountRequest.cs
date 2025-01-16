using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class BusinessAdAccountRequest
    {
        [JsonProperty("permitted_tasks")]
        public List<string> PermittedTasks { get; set; } = new List<string>();
    }
}
