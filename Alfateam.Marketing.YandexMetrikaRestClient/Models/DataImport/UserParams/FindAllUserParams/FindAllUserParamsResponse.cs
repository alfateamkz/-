using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.FindAllUserParams
{
    public class FindAllUserParamsResponse
    {
        [JsonProperty("uploadings")]
        public List<UserParamsUploading> Uploadings { get; set; } = new List<UserParamsUploading>();
    }
}
