using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Модель объекта транспорта
    /// </summary>
    public enum TransportType
    {
        Car = 1, //Автомобиль
        Motorcycle = 2, //Мотоцикл
        Truck = 3, //Грузовой автомобиль
        Bus = 4, //Автобус
        Bicycle = 5, //Велосипед
        Scooter = 6, //Скутер
        Airplane = 7, //Самолет
        Helicopter = 8, //Вертолет
        Van = 9, //Микроавтобус
        Ship = 10, //Корабль
        Boat = 11, //Лодка
        Yacht = 12, //Яхта



        Other = 999 //Иной тип транспорта
    }
}
