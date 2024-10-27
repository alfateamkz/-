using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.General;
using Alfateam.Website.API.Abstractions;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General
{
    public class DepartmentDTO : DTOModelAbs<Department>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }


        [ForClientOnly]
        public List<DepartmentDTO> SubDepartments { get; set; } = new List<DepartmentDTO>();





        [ForClientOnly]
        [Description("Головное ли подразделение. Если да, то оно не может быть удалено")]
        public bool IsRoot { get; set; }
    }
}
