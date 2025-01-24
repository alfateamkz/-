using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions;
using Alfateam.Telephony.Models.General;
using Alfateam.Telephony.Models.HLR.Numbers;
using Alfateam.Telephony.Models.HLR.Numbers.Types;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<HLRNumbersToCheck>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(HLRNumbersToCheckCategories), "HLRNumbersToCheckCategories")]
    [JsonKnownType(typeof(HLRNumbersToCheckList), "HLRNumbersToCheckList")]
    public class HLRNumbersToCheck : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public HLRNumbersToCheckByCountryType CheckByCountryType { get; set; } = HLRNumbersToCheckByCountryType.Disabled;
        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
