using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.ConfirmUserParams
{
    public class ConfirmUserParamsBody
    {
        [JsonProperty("uploading")]
        public UserParamsUploading Uploading { get; set; }
    }
}
