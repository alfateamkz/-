using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.ExternalInteractions;
using Alfateam.Marketing.Models.Referral.Main.Transactions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{


    [JsonConverter(typeof(JsonKnownTypesConverter<ReferralAccountTransaction>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AdmissionReferralAccountTransaction), "AdmissionReferralAccountTransaction")]
    [JsonKnownType(typeof(WithdrawalReferralAccountTransaction), "WithdrawalReferralAccountTransaction")]
    public class ReferralAccountTransaction : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public DateTime Date { get; set; }


        
        public decimal Value { get; set; }
        public TransactionDirection Direction { get; set; }




        public string? Comment { get; set; }
    }
}
