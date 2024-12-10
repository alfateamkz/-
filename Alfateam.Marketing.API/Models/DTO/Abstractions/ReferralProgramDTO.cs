using Alfateam.Marketing.API.Models.DTO.Referral;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Referral;
using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ReferralProgramDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(MLMNetworkReferralProgramDTO), "MLMNetworkReferralProgram")]
    [JsonKnownType(typeof(MultiLevelReferralProgramDTO), "MultiLevelReferralProgram")]
    [JsonKnownType(typeof(SimpleReferralProgramDTO), "SimpleReferralProgram")]
    public class ReferralProgramDTO : DTOModelAbs<ReferralProgram>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
