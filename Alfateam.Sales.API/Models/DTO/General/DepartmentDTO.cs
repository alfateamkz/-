using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class DepartmentDTO : DTOModelAbs<Department>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }


        [ForClientOnly]
        public List<DepartmentDTO> SubDepartments { get; set; } = new List<DepartmentDTO>();




        [Description("Головное ли подразделение. Если да, то оно не может быть удалено")]
        [ForClientOnly]
        public bool IsRoot { get; set; }
    }
}
