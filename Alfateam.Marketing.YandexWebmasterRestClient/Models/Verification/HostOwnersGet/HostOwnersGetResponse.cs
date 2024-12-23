using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification.HostOwnersGet
{
    public class HostOwnersGetResponse
    {
        [JsonProperty("users")]
        public List<VerificationHostOwner> Users { get; set; } = new List<VerificationHostOwner>(); 
    }
}
