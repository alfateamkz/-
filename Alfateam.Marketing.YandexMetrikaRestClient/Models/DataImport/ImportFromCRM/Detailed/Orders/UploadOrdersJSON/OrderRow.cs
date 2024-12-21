using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersJSON
{
    public class OrderRow
    {
        [JsonProperty("client_type")]
        public OrderRowClientType ClientType { get; set; }

        [JsonProperty("client_uniq_id")]
        public string ClientUniqId { get; set; }

        [JsonProperty("create_date_time")]
        public DateTime CreateDateTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("order_status")]
        public string OrderStatus { get; set; }

        [JsonProperty("attribute_values")]
        public List<List<string>> AttributeValues { get; set; } = new List<List<string>>();

        [JsonProperty("cost")]
        public double Cost { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("finish_date_time")]
        public DateTime FinishDateTime { get; set; }

        [JsonProperty("goals")]
        public List<CdpGoalExternal> Goals { get; set; } = new List<CdpGoalExternal>();

        [JsonProperty("products")]
        public List<int> Products { get; set; } = new List<int>();

        [JsonProperty("revenue")]
        public double Revenue { get; set; }

        [JsonProperty("update_date_time")]
        public DateTime UpdateDateTime { get; set; }
    }
}
