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
        Waiting = 1, //В ожидании
        Sent = 2, //Отправлен получателю
        Delivered = 3, //Доставлен получателю
        Canceled = 4, //Отклонен получателем
        Rejected = 5 //Отклонен админом
    }
}
