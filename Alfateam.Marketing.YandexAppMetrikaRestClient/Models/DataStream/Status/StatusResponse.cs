using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Status
{
    public class StatusResponse
    {
        [JsonProperty("status")]
        public DataStreamStatus Status { get; set; }
    }
}
