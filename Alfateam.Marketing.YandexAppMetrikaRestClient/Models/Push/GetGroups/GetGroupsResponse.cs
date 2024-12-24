using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.GetGroups
{
    public class GetGroupsResponse
    {
        [JsonProperty("groups")]
        public List<PushGroup> Groups { get; set; } = new List<PushGroup>();
    }
}
