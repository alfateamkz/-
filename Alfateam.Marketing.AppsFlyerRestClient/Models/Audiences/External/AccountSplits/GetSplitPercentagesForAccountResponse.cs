using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AccountSplits
{
    public class GetSplitPercentagesForAccountResponse
    {
        [JsonProperty("message")]
        public GetSplitPercentagesForAccountResponseMsg Message { get; set; }
    }
}
