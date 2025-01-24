using Alfateam.Core;
using Alfateam.Telephony.Models.Calls;
using Alfateam.Telephony.Models.ExtLines;
using Alfateam.Telephony.Models.General.Numbers;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<TelephonyNumber>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ExternalNumber), "ExternalNumber")]
    [JsonKnownType(typeof(VirtualNumber), "VirtualNumber")]
    public class TelephonyNumber : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string PhoneNumber { get; set; }


        public List<BaseCall> Calls { get; set; } = new List<BaseCall>();
        public List<BaseSMS> SMSList { get; set; } = new List<BaseSMS>();







        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
