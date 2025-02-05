using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.General;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes.RouteStageExecutors
{
    public class RouteStageExecutorDepartmentDTO : RouteStageExecutorDTO
    {
        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }


        [ForClientOnly]
        public List<UserDTO> ExcludingUsers { get; set; } = new List<UserDTO>();
        [DTOFieldBindWith(typeof(User))]
        public List<int> ExcludingUsersIds { get; set; } = new List<int>();
    }
}
