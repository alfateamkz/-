using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.General;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes.AfterDocSigning
{
    public class AfterDocSigningMoveToDepartmentDTO : AfterDocSigningActionDTO
    {
        [ForClientOnly]
        public Department To { get; set; }
        public int ToId { get; set; }
    }
}
