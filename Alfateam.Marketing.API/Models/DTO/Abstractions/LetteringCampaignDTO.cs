using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.Lettering;
using Alfateam.Marketing.API.Models.DTO.Segments;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Lettering;
using Alfateam.Marketing.Models.Lettering.Items;
using Alfateam.Marketing.Models.Segments;
using Alfateam.SharedModels.Filters;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<LetteringCampaignDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(NotSMSLetteringCampaignDTO), "NotSMSLetteringCampaign")]
    [JsonKnownType(typeof(SMSLetteringCampaignDTO), "SMSLetteringCampaign")]
    public class LetteringCampaignDTO : DTOModelAbs<LetteringCampaign>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public LetteringStatus Status { get; set; }


        public string Title { get; set; }



        [ForClientOnly]
        public List<SegmentDTO> IncludedSegments { get; set; } = new List<SegmentDTO>();

        [ForClientOnly]
        public List<SegmentDTO> ExcludedSegments { get; set; } = new List<SegmentDTO>();



        public TimePeriod? SendOnlyBetweenTime { get; set; }




        [ForClientOnly]
        public List<LetteringSentResult> LetteringSentResults { get; set; } = new List<LetteringSentResult>();
    }
}
