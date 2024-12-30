using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.MeasurementProtocol.DeleteToken
{
    public class DeleteTokenResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
