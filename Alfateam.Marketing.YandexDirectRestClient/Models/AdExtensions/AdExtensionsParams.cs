using Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdExtensions
{
    public class AdExtensionsParams<T>
    {
        [JsonProperty("method")]
        public AdExtensionsMethod Method { get; set; }
        
        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
