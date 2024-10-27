using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General.RolePowers
{
    public class CommonRolePower : RolePower
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }



        public CommonRoleType Type { get; set; }
    }
}
