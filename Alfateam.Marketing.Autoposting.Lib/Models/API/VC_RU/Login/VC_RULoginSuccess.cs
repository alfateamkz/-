using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Login
{
    public class VC_RULoginSuccess
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public VC_RULoginSuccessData Data { get; set; }
    }
}
