using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetSocialNetworks
{
    public class GetSocialNetworksResponse
    {
        [JsonProperty("social_networks")]
        public List<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();
    }
}
