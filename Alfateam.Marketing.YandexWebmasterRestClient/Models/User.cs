using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models
{
    public class User
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}
