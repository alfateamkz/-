using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.UpdateApplication
{
    public class UpdateApplicationResponse
    {
        [JsonProperty("application")]
        public Application Application { get; set; }
    }
}
