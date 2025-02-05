using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class DepartmentDTO : DTOModelAbs<Department>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

        [ForClientOnly]
        public List<Department> SubDepartments { get; set; } = new List<Department>();




        [ForClientOnly]
        [Description("Головное ли подразделение. Если да, то оно не может быть удалено")]
        public bool IsRoot { get; set; }
    }
}
