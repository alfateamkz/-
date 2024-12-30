using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.AddAccess
{
    public class AddAccessBody
    {
        [JsonProperty("grant")]
        public AddAccessBodyGrant Grant { get; set; }
    }
}
