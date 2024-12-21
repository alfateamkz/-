using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.FindUserParamsById
{
    public class FindUserParamsByIdResponse
    {
        [JsonProperty("uploading")]
        public UserParamsUploading Uploading { get; set; }
    }
}
