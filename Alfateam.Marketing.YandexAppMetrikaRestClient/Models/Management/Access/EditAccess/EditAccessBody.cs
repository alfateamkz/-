using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.EditAccess
{
    public class EditAccessBody
    {
        [JsonProperty("grant")]
        public EditAccessBodyGrant Grant { get; set; }
    }
}
