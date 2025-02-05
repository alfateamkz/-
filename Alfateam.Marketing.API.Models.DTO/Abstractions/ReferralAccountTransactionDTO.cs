using Alfateam.Marketing.API.Models.DTO.Referral.Main.Transactions;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Referral.Main.Transactions;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ReferralAccountTransactionDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AdmissionReferralAccountTransactionDTO), "AdmissionReferralAccountTransaction")]
    [JsonKnownType(typeof(WithdrawalReferralAccountTransactionDTO), "WithdrawalReferralAccountTransaction")]
    public class ReferralAccountTransactionDTO : DTOModelAbs<ReferralAccountTransaction>
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
