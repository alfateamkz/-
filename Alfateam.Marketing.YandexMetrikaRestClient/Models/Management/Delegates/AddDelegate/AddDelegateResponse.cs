using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.AddDelegate
{
    public class AddDelegateResponse
    {
        [JsonProperty("delegates")]
        public List<DelegateE> Delegates { get; set; } = new List<DelegateE>();
    }
}
