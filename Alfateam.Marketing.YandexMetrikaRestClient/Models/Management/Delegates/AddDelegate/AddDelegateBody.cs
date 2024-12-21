using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.AddDelegate
{
    public class AddDelegateBody
    {
        [JsonProperty("delegate")]
        public DelegateE Delegate { get; set; }
    }
}
