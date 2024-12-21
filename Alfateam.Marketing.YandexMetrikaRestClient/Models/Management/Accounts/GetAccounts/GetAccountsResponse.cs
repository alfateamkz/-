using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Accounts.GetAccounts
{
    public class GetAccountsResponse
    {
        [JsonProperty("accounts")]
        public List<AccountE> Accounts { get; set; } = new List<AccountE>();
    }
}
