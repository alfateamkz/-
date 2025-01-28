using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Files
{
    public abstract class VC_RUFile
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }
    }
}
