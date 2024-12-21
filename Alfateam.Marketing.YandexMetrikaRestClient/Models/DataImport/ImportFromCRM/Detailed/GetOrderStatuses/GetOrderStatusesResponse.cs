using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.GetOrderStatuses
{
    public class GetOrderStatusesResponse
    {
        [JsonProperty("order_statuses")]
        public List<OrderStatus> OrderStatuses { get; set; } = new List<OrderStatus>();
    }
}
