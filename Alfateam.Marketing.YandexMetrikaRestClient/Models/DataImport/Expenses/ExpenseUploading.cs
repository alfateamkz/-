using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses
{
    public class ExpenseUploading
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("source_quantity")]
        public int SourceQuantity { get; set; }

        [JsonProperty("status")]
        public ExpenseUploadingStatus Status { get; set; }

        [JsonProperty("type")]
        public ExpenseUploadingType Type { get; set; }
    }
}
