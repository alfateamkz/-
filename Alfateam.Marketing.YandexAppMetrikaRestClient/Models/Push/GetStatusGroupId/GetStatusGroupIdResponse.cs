using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.GetStatusGroupId
{
    public class GetStatusGroupIdResponse
    {
        [JsonProperty("transfer")]
        public PushTransfer Transfer { get; set; }
    }
}
