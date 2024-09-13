using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Gamification
{
    /// <summary>
    /// Статус заказа в системе геймификации
    /// </summary>
    public enum ShopOrderStatus
    {
        Basket = 1, //В раздумиях
        Waiting = 2, //В ожидании
        Sent = 3, //Отправлен получателю
        Delivered = 4, //Доставлен получателю
        Canceled = 5, //Отклонен получателем
        Rejected = 6 //Отклонен админом
    }
}
