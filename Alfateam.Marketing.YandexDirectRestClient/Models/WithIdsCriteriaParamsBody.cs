using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class WithIdsCriteriaParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public IdsCriteria SelectionCriteria { get; set; }
    }
}
