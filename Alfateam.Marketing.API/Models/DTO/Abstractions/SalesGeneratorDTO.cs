using Alfateam.Marketing.API.Models.DTO.SalesGenerators;
using Alfateam.Marketing.API.Models.DTO.SalesGenerators.Items;
using Alfateam.Marketing.API.Models.DTO.Segments;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.SalesGenerators;
using Alfateam.Marketing.Models.SalesGenerators.Items;
using Alfateam.Marketing.Models.Segments;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SalesGeneratorDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(RepeatLeadsSalesGeneratorDTO), "RepeatLeadsSalesGenerator")]
    [JsonKnownType(typeof(RepeatOrdersSalesGeneratorDTO), "RepeatOrdersSalesGenerator")]
    public class SalesGeneratorDTO : DTOModelAbs<SalesGenerator>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }

        public List<SegmentDTO> IncludedSegments { get; set; } = new List<SegmentDTO>();
        public List<SegmentDTO> ExcludedSegments { get; set; } = new List<SegmentDTO>();

        public SalesGeneratorStartOptionsDTO StartOptions { get; set; }




        public List<SGResponsibleCRMUserItemDTO> ResponsibleCRMUsersQueue { get; set; } = new List<SGResponsibleCRMUserItemDTO>();
        public string TaskForManagerText { get; set; }
    }
}
