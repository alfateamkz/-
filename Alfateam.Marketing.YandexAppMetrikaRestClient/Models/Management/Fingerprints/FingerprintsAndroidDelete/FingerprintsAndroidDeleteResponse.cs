using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints.FingerprintsAndroidDelete
{
    public class FingerprintsAndroidDeleteResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
