using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostECommerce
{
    public class PostECommerceQueryParams : PostAPIGeneralQueryParams
    {
        [JsonProperty("ecom_event_type")]
        public EComEventType EComEventType { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("cart_item_quantity")]
        public int CartItemQuantity { get; set; }

        [JsonProperty("cart_item_price_currency")]
        public string CartItemPriceCurrency { get; set; }

        [JsonProperty("cart_item_price_value")]
        public int CartItemPriceValue { get; set; }

        [JsonProperty("actual_price_internal_currency")]
        public List<string> ActualPriceInternalCurrency { get; set; } = new List<string>();

        [JsonProperty("actual_price_internal_value")]
        public List<int> ActualPriceInternalValue { get; set; } = new List<int>();

        [JsonProperty("payload")]
        public Dictionary<string, string> Payload { get; set; } = new Dictionary<string, string>();

        [JsonProperty("product_category_path_1")]
        public string ProductCategoryPath1 { get; set; }

        [JsonProperty("product_category_path_2")]
        public string ProductCategoryPath2 { get; set; }

        [JsonProperty("product_category_path_3")]
        public string ProductCategoryPath3 { get; set; }

        [JsonProperty("product_category_path_4")]
        public string ProductCategoryPath4 { get; set; }

        [JsonProperty("product_category_path_5")]
        public string ProductCategoryPath5 { get; set; }

        [JsonProperty("product_category_path_6")]
        public string ProductCategoryPath6 { get; set; }

        [JsonProperty("product_category_path_7")]
        public string ProductCategoryPath7 { get; set; }

        [JsonProperty("product_category_path_8")]
        public string ProductCategoryPath8 { get; set; }

        [JsonProperty("product_category_path_9")]
        public string ProductCategoryPath9 { get; set; }

        [JsonProperty("product_category_path_10")]
        public string ProductCategoryPath10 { get; set; }

        [JsonProperty("original_price_currency")]
        public string OriginalPriceCurrency { get; set; }

        [JsonProperty("original_price_value")]
        public int OriginalPriceValue { get; set; }

        [JsonProperty("original_price_internal_currency")]
        public string OriginalPriceInternalCurrency { get; set; }

        [JsonProperty("original_price_internal_value")]
        public int OriginalPriceInternalValue { get; set; }

        [JsonProperty("product_payload")]
        public Dictionary<string, string> ProductPayload { get; set; } = new Dictionary<string, string>();

        [JsonProperty("product_promo_codes")]
        public List<string> ProductPromoCodes { get; set; } = new List<string>();

        [JsonProperty("product_sku")]
        public string ProductSKU { get; set; }

        [JsonProperty("screen_category_path_1")]
        public string ScreenCategoryPath1 { get; set; }

        [JsonProperty("screen_category_path_2")]
        public string ScreenCategoryPath2 { get; set; }

        [JsonProperty("screen_category_path_3")]
        public string ScreenCategoryPath3 { get; set; }

        [JsonProperty("screen_category_path_4")]
        public string ScreenCategoryPath4 { get; set; }

        [JsonProperty("screen_category_path_5")]
        public string ScreenCategoryPath5 { get; set; }

        [JsonProperty("screen_category_path_6")]
        public string ScreenCategoryPath6 { get; set; }

        [JsonProperty("screen_category_path_7")]
        public string ScreenCategoryPath7 { get; set; }

        [JsonProperty("screen_category_path_8")]
        public string ScreenCategoryPath8 { get; set; }

        [JsonProperty("screen_category_path_9")]
        public string ScreenCategoryPath9 { get; set; }

        [JsonProperty("screen_category_path_10")]
        public string ScreenCategoryPath10 { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("screen_payload")]
        public List<string> ScreenPayload { get; set; } = new List<string>();
    }
}
