using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.API.Models.DTO.Tasks;
using Alfateam.Sales.API.Models.DTO.Tasks.CompletionCheck;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Tasks;
using Alfateam.Sales.Models.Tasks.CompletionCheck;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions.Tasks
{
    [JsonConverter(typeof(JsonKnownTypesConverter<UserTaskDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(SimpleUserTaskDTO), "SimpleUserTask")]
    [JsonKnownType(typeof(WithAmountUserTaskDTO), "WithAmountUserTask")]
    public class UserTaskDTO : DTOModelAbs<UserTask>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }



        [ForClientOnly]
        public UserDTO TaskFor { get; set; }

        [HiddenFromClient, DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int TaskForId { get; set; }




        public string Title { get; set; }
        public string? Description { get; set; }




        [ForClientOnly]
        public List<MarkedAsCompletedDTO> MarkedAsCompleted { get; set; } = new List<MarkedAsCompletedDTO>();
        [ForClientOnly]
        public List<TaskCompletionCheckResultDTO> CompletionCheckResults { get; set; } = new List<TaskCompletionCheckResultDTO>();


        [ForClientOnly]
        public UserTaskStatus Status { get; set; }
    }
}
