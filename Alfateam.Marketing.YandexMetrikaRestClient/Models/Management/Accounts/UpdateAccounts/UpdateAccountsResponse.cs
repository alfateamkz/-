using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Accounts.UpdateAccounts
{
    public class UpdateAccountsResponse
    {
        [JsonProperty("accounts")]
        public List<AccountE> Accounts { get; set; } = new List<AccountE>();
    }
}
