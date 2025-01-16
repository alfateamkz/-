using Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs
{
    public class StoreCatalogSettings
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }
    }
}
