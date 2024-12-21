using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat
{
    public class StatGeneralResponse
    {
        [JsonProperty("contains_sensitive_data")]
        public bool ContainsSensitiveData { get; set; }

        [JsonProperty("data_lag")]
        public int DataLag { get; set; }

        [JsonProperty("sample_share")]
        public double SampleShare { get; set; }

        [JsonProperty("sample_size")]
        public long SampleSize { get; set; }

        [JsonProperty("sample_space")]
        public long SampleSpace { get; set; }

        [JsonProperty("sampled")]
        public bool Sampled { get; set; }

        [JsonProperty("total_rows")]
        public long TotalRows { get; set; }

        [JsonProperty("total_rows_rounded")]
        public bool TotalRowsRounded { get; set; }

        [JsonProperty("totals")]
        public List<double> Totals { get; set; } = new List<double>();
    }
}
