using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Get
{
    public class SmartCreativeGet
    {
        [JsonProperty("CreativeGroupId")]
        public long CreativeGroupId { get; set; }

        [JsonProperty("CreativeGroupName")]
        public string CreativeGroupName { get; set; }

        [JsonProperty("BusinessType")]
        public BusinessTypeEnum BusinessType { get; set; }
    }
}
