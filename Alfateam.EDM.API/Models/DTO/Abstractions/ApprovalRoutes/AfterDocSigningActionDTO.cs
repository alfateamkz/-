using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes.AfterDocSigning;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AfterDocSigningActionDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AfterDocSigningMoveToDepartmentDTO), "AfterDocSigningMoveToDepartment")]
    [JsonKnownType(typeof(AfterDocSigningNotifyUsersDTO), "AfterDocSigningNotifyUsers")]
    public class AfterDocSigningActionDTO : DTOModelAbs<AfterDocSigningAction>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        /// <summary>
        /// Автоматическое поле, указывает на маршрут согласование
        /// </summary>
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int ApprovalRouteId { get; set; }
    }
}
