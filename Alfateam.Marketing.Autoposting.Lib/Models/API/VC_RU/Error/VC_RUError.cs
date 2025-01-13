using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Error
{
    public class VC_RUError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("info")]
        public VC_RUErrorInfo Info { get; set; }
    }
}
