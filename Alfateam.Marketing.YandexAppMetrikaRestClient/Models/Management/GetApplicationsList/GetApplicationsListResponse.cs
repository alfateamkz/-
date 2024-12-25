using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetApplicationsList
{
    public class GetApplicationsListResponse
    {
        [JsonProperty("applications")]
        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
