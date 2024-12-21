using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.GetDelegates
{
    public class GetDelegatesResponse
    {
        [JsonProperty("delegates")]
        public List<DelegateE> Delegates { get; set; } = new List<DelegateE>();
    }
}
