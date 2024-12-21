using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContactsJSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersJSON
{
    public class UploadOrdersJSONBody
    {
        [JsonProperty("orders")]
        public List<OrderRow> Orders { get; set; } = new List<OrderRow>();
    }
}
