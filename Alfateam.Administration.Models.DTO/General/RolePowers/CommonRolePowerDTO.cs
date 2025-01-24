using Alfateam.Administration.Models.DTO.Abstractions;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.General;
using Alfateam.Core.Attributes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.General.RolePowers
{
    public class CommonRolePowerDTO : RolePowerDTO
    {

        [ForClientOnly]
        public ProductDTO Product { get; set; }

        [HiddenFromClient]
        public int ProductId { get; set; }


        
        public CommonRoleType Type { get; set; }
    }
}
