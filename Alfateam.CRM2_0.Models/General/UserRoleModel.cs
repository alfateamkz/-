using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность модели ролей пользователя
    /// </summary>
    public class UserRoleModel : AbsModel
    {
        public List<UserGivenRole> GivenRoles { get; set; } = new List<UserGivenRole>();
        public bool HasRole(UserRole role)
        {
            return GivenRoles.Any(o => o.Role == role);
        }
    }
}
