using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Статус заказа в магазине
    /// </summary>
    public enum ShopOrderStatus
    {
        Basket = 1, //Заказ как "корзина"
        Unpaid = 2, //Оплачен
        Paid = 3, //Оплачен
        InDelivery = 4, //В доставке
        Delivered = 5, //Доставлен
        Completed = 6, //Получен, заказ закрыт
        TakenByClient = 7, //Получен, но еще заказ не закрыт


        Canceled = 8, //Заказ отменен
        ReturnedByCustomer = 9, //Заказ возвращен клиентом
        ReturnedByDeliveryService = 10, //Заказ возвращен службой доставки(клиент не забрал)
    }
}
