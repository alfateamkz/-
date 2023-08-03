using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Тип доступа к разделу магазина
    /// </summary>
    public enum ShopAccessType
    {
        None = 1, //Нет доступа
        WatchOnly = 2, //Только просмотр
        Handling = 3, //Обработка заказов
        ProductEditing = 4, //Управление товарными позициями
        FullAccess = 5, //Полный доступ
    }
}
