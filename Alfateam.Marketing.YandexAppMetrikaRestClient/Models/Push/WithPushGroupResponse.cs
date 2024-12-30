using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push
{
    public class WithPushGroupResponse
    {
        [JsonProperty("group")]
        public PushGroup Group { get; set; }
    }
}
