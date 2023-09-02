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
    /// Выданная пользователю роль
    /// </summary>
    public class UserGivenRole : AbsModel
    {
        public UserRole Role { get; set; }
        public DateTime GivenAt { get; set; } = DateTime.UtcNow;
    }
}
