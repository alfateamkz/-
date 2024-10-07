using Alfateam.EDM.API.Models.DTO.ApprovalRoutes.RouteStageExecutors;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes
{
    [JsonConverter(typeof(JsonKnownTypesConverter<RouteStageExecutorDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(RouteStageExecutorDepartmentDTO), "RouteStageExecutorDepartment")]
    [JsonKnownType(typeof(RouteStageExecutorUsersDTO), "RouteStageExecutorUsers")]
    public class RouteStageExecutorDTO : DTOModelAbs<RouteStageExecutor>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
