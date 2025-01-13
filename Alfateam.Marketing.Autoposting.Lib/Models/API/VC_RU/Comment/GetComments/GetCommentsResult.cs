using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment.GetComments
{
    public class GetCommentsResult
    {
        [JsonProperty("items")]
        public List<VC_RUComment> Items { get; set; } = new List<VC_RUComment>();
    }
}
