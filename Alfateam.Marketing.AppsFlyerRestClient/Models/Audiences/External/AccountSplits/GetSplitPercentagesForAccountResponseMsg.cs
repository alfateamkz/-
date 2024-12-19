using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AccountSplits
{
    public class GetSplitPercentagesForAccountResponseMsg
    {
        [JsonProperty("connections")]
        public List<GetSplitPercentagesForAccountResponseConnection> Connections { get; set; } = new List<GetSplitPercentagesForAccountResponseConnection>();
    }
}
