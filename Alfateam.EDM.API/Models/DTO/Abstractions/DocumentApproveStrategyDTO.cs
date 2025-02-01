using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentApproveStrategyDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentApprovalDepartmentStrategyDTO), "DocumentApprovalDepartmentStrategy")]
    [JsonKnownType(typeof(DocumentApprovalRouteStrategyDTO), "DocumentApprovalRouteStrategy")]
    public class DocumentApproveStrategyDTO : DTOModelAbs<DocumentApproveStrategy>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string? Comment { get; set; }
    }
}
