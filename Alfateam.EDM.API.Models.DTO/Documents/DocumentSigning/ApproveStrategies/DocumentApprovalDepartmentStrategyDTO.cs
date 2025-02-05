using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.General;
using System.ComponentModel;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.ApproveStrategies
{
    public class DocumentApprovalDepartmentStrategyDTO : DocumentApproveStrategyDTO
    {
        [ForClientOnly]
        public DepartmentDTO Department { get; set; }

        [HiddenFromClient]
        public int DepartmentId { get; set; }


        [Description("Если список пустой, то могут согласовывать документы все сотрудники подразделения")]
        [ForClientOnly]
        public List<UserDTO> AllowedUsers { get; set; } = new List<UserDTO>();

        [Description("Если список пустой, то могут согласовывать документы все сотрудники подразделения")]
        [HiddenFromClient, DTOFieldBindWith("AllowedUsers", typeof(User))]
        public List<int> AllowedUsersIds { get; set; } = new List<int>();
    }
}
