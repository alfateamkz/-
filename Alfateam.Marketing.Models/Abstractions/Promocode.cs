using Alfateam.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{
    public class Promocode : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public string Code { get; set; }


        public DateTime NotBefore { get; set; }
        public DateTime? NotAfter { get; set; }



        public bool IsReusable { get; set; }
    }
}
