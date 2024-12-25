using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.DataStream;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Data
{
    public class DataQueryParams
    {
        [JsonProperty("data_type")]
        public DataStreamDataType DataType { get; set; }

        [JsonProperty("stream_window_timestamp")]
        public int StreamWindowTimestamp { get; set; }
    }
}
