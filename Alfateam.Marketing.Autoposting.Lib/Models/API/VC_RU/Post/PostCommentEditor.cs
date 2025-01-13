using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostCommentEditor
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
