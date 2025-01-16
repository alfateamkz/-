using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs
{
    public class ProductCatalogImageSettingsOperation
    {
        [JsonProperty("transformation_type")]
        public string TransformationType { get; set; }
    }
}
