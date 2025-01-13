using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.FileUpload
{
    public class VC_RUFileUploadResultFile
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public VC_RUFile Data { get; set; }
    }
}
