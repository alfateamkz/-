using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Тип сущности вещевого объекта
    /// </summary>
    public enum ThingType
    {
        Appliances = 1, //Бытовая техника
        ElectronicDevices = 2, //Электронные устройства
        Jewelry = 3, //Ювелирные украшения
        PreciousMetals = 4, //Драгоценные металлы
        Securities = 5, //Ценные бумаги



        Other = 999 //Прочее
    }
}
