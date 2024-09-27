using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class DepartmentDTO : DTOModelAbs<Department>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Address { get; set; }

        [ForClientOnly]
        public List<DepartmentDTO> SubDepartments { get; set; } = new List<DepartmentDTO>();


        /// <summary>
        /// Головное ли подразделение. Если да, то оно не может быть удалено
        /// </summary>
        [ForClientOnly]
        public bool IsRoot { get; set; }
    }
}
