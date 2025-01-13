using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment
{
    public class VC_RUCommentEntry
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subsiteId")]
        public int SubsiteId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
