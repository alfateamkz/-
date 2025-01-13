using Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdExtensions.Get
{
    public class AdExtensionsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public AdExtensionsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AdExtensionFieldName> FieldNames { get; set; } = new List<AdExtensionFieldName>() 
        {
            AdExtensionFieldName.Id,
            AdExtensionFieldName.Type,
            AdExtensionFieldName.Status,
            AdExtensionFieldName.StatusClarification,
            AdExtensionFieldName.Associated 
        };

        [JsonProperty("CalloutFieldNames")]
        public List<CalloutFieldName> CalloutFieldNames { get; set; } = new List<CalloutFieldName>()
        {
            CalloutFieldName.CalloutText,
        };

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
