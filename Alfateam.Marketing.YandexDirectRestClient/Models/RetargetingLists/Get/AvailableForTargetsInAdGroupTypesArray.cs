using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Get
{
    public class AvailableForTargetsInAdGroupTypesArray
    {
        [JsonProperty("Items")]
        public List<AdGroupTypesEnum> Items { get; set; } = new List<AdGroupTypesEnum>();
    }
}
