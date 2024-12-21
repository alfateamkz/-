using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations
{
    public class WithOperationEBody
    {
        [JsonProperty("operation")]
        public OperationE Operation { get; set; }
    }
}
