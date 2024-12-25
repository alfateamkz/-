using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream
{
    public class WithDataStreamSettingsBody
    {
        [JsonProperty("settings")]
        public DataStreamSettings Settings { get; set; }
    }
}
