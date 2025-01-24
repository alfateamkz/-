using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.DTO.Abstractions;
using Alfateam.Administration.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.General
{
    public class UserRoleModelDTO : DTOModelAbs<UserRoleModel>
    {
        [Description("Если да, то имеет доступ ко всем разделам админки")]
        public bool IsAlfateamDirector { get; set; }
        public List<RolePowerDTO> Powers { get; set; } = new List<RolePowerDTO>();

    }
}
