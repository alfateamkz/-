using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.MeasurementProtocol.GenerateToken
{
    public class GenerateTokenResponse
    {
        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
