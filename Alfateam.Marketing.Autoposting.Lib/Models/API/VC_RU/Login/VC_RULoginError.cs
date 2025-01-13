using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Login
{
    public class VC_RULoginError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public VC_RUError Error { get; set; }
    }
}
