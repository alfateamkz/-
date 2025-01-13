using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.GetPost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Success
{
    public class VC_RUSuccessResponse<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
