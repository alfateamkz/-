using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations.GetOperations
{
    public class GetOperationsResponse
    {
        [JsonProperty("operations")]
        public List<OperationE> Operations { get; set; } = new List<OperationE>();
    }
}
