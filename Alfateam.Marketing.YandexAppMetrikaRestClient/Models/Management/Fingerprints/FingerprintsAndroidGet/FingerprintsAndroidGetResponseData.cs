using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints.FingerprintsAndroidGet
{
    public class FingerprintsAndroidGetResponseData
    {
        [JsonProperty("fingerprints")]
        public List<FingerprintModel> Fingerprints { get; set; } = new List<FingerprintModel>();
    }
}
