using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.CreateProducts
{
    public class ListItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("humanized")]
        public string Humanized { get; set; }
    }
}
