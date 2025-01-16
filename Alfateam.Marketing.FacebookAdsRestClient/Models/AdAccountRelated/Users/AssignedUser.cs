using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users
{
    public class AssignedUser
    {
        [JsonProperty("permitted_tasks")]
        public List<string> PermittedTasks { get; set; } = new List<string>();

        [JsonProperty("tasks")]
        public List<string> Tasks { get; set; } = new List<string>();
    }
}
