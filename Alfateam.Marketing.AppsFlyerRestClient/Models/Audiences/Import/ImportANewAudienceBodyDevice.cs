using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Import
{
    public class ImportANewAudienceBodyDevice
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("idfv")]
        public string Idfv { get; set; }

        [JsonProperty("idfa")]
        public string Idfa { get; set; }

        [JsonProperty("gaid")]
        public string Gaid { get; set; }

        [JsonProperty("oaid")]
        public string Oaid { get; set; }

        [JsonProperty("imei")]
        public string Imei { get; set; }

        [JsonProperty("cuid")]
        public string Cuid { get; set; }

        [JsonProperty("emails")]
        public string Emails { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("phone_e164")]
        public string PhoneE164 { get; set; }

        [JsonProperty("braze_id")]
        public string BrazeId { get; set; }

        [JsonProperty("amplitude_id")]
        public string AmplitudeId { get; set; }
    }
}
