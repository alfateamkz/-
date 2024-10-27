using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General
{
    public class UserRoleModel : AbsModel
    {
        /// <summary>
        /// Если да, то имеет доступ ко всем разделам админки
        /// </summary>
        public bool IsAlfateamDirector { get; set; }
        public List<RolePower> Powers { get; set; } = new List<RolePower>();


        public bool HasAccessToProduct(int productId, CommonRoleType roleType)
        {
            return Powers.Where(o => o is CommonRolePower).Cast<CommonRolePower>()
                         .Any(o => o.ProductId == productId && (o.Type == roleType || roleType == CommonRoleType.Owner));
        }
    }
}
