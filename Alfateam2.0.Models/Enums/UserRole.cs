using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Тип роли пользователя
    /// </summary>
    public enum UserRole
    {
        User = 1, //Обычный пользователь сайта
        Admin = 2, //Пользователь с доступом в администраторскую панель
        Owner = 3 //Владелец сайта
    }
}
