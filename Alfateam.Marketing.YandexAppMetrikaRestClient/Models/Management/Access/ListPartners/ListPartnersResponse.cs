using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.ListPartners
{
    public class ListPartnersResponse
    {
        [JsonProperty("partners")]
        public ListPartnersResponsePartners Partners { get; set; }
    }
}
