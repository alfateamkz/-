using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.ListPartners
{
    public class ListPartnersResponsePartners
    {
        [JsonProperty("total_rows")]
        public int TotalRows { get; set; }

        [JsonProperty("partners")]
        public List<Partner> Partners { get; set; } = new List<Partner>();
    }
}
