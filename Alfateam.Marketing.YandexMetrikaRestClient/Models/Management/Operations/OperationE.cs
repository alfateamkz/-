using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations
{
    public class OperationE
    {
        [JsonProperty("action")]
        public OperationEAction Action { get; set; }

        [JsonProperty("attr")]
        public OperationEAttr Attr { get; set; }

        [JsonProperty("status")]
        public OperationEStatus Status { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
