using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters.DeleteAccessFilter
{
    public class DeleteAccessFilterQueryParams
    {
        [JsonProperty("delete_grants")]
        public int DeleteGrants { get; set; }
    }
}
