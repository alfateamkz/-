using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Refresh
{
    public class VC_RURefreshSuccess
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public VC_RURefreshSuccessData Data { get; set; }
    }
}
