using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Тип доступа к разделу портфолио
    /// </summary>
    public enum PortfolioAccessType
    {
        None = 1, //Нет доступа
        WatchOnly = 2, //Только просмотр 
        CanUpdateWithoutDeletion = 3, //Редактирование без удаления
        FullAccess = 4, //Полный доступ
    }
}
