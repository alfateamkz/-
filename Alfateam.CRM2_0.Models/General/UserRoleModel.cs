using Alfateam.CRM2_0.Models.Abstractions;
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
    }
}
