using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Diagnostics
{
    public class DiagnosticsResponse
    {
        [JsonProperty("problems")]
        public Dictionary<ApiSiteProblemTypeEnum, DiagnosticsResponseProblem> Problems { get; set; } = new Dictionary<ApiSiteProblemTypeEnum, DiagnosticsResponseProblem>();
    }
}
