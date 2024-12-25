using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetCategories
{
    public class GetCategoriesResponse
    {
        [JsonProperty("data")]
        public List<ApplicationCategory> Data { get; set; } = new List<ApplicationCategory>();
    }
}
