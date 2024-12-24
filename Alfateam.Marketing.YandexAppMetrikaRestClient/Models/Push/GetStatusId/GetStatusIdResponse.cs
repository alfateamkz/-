using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.GetStatusId
{
    public class GetStatusIdResponse
    {
        [JsonProperty("transfer")]
        public PushTransfer Transfer { get; set; }
    }
}
