using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints.FingerprintsAndroidPost
{
    public class FingerprintsAndroidPostBodyData
    {
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }
    }
}
