using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General.Security
{
    public class DocumentsAccessDTO : DTOModelAbs<DocumentsAccess>
    {
        public DocumentsAccessType Type { get; set; }

        /// <summary>
        /// Используется, если Type == DocumentsAccessType.OnlySelectedDepartments
        /// </summary>
        [ForClientOnly]
        public List<DepartmentDTO> SelectedDepartments { get; set; } = new List<DepartmentDTO>();

        [DTOFieldBindWith(typeof(Department))]
        public List<int> SelectedDepartmentsIds { get; set; } = new List<int>();
    }
}
