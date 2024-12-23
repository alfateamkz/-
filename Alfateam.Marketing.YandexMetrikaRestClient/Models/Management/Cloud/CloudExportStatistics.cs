using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Cloud
{
    public class CloudExportStatistics
    {
        [JsonProperty("bytes_per_second_by_day")]
        public long BytesPerSecondByDay { get; set; }

        [JsonProperty("bytes_per_second_by_hour")]
        public long BytesPerSecondByHour { get; set; }

        [JsonProperty("bytes_per_second_by_month")]
        public long BytesPerSecondByMonth { get; set; }

        [JsonProperty("bytes_per_second_by_week")]
        public long BytesPerSecondByWeek { get; set; }

        [JsonProperty("bytes_per_second_by_year")]
        public long BytesPerSecondByYear { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
