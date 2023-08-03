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
        Paid = 2, //Оплачен
        InDelivery = 3, //В доставке
        Delivered = 4, //Доставлен
        Completed = 5, //Получен, заказ закрыт
        TakenByClient = 6, //Получен, но еще заказ не закрыт


        Canceled = 7, //Заказ отменен
        ReturnedByCustomer = 8, //Заказ возвращен клиентом
        ReturnedByDeliveryService = 9, //Заказ возвращен службой доставки(клиент не забрал)
    }
}
