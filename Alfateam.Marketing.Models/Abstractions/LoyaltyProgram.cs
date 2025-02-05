using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{
    public class LoyaltyProgram : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }


        public Currency BaseCurrency { get; set; }
        public int BaseCurrencyId { get; set; }


        public LoyaltyProgramType Type { get; set; }
    }
}
