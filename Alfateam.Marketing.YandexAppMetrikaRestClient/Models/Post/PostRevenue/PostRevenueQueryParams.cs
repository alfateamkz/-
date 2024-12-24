using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Post;
using Newtonsoft.Json;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostRevenue
{
    public class PostRevenueQueryParams : PostAPIGeneralQueryParams
    {
        [JsonProperty("revenue_event_type")]
        public RevenueEventType RevenueEventType { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }
       
        [JsonProperty("payload")]
        public Dictionary<string,string> Payload { get; set; } = new Dictionary<string,string>();

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}
