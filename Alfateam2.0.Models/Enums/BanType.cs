using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Вид бана
    /// </summary>
    public enum BanType
    {
        AdminPanel = 1, //Только в админ-панели
        All = 999 //Полная блокировка пользователя
    }
}
