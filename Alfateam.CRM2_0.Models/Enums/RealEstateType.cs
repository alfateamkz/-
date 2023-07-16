using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Тип объекта недвижимого имущества
    /// </summary>
    public enum RealEstateType
    {
        House = 1, //Дом
        Flat = 2, //Квартира
        Room = 3, //Комната
        Office = 4, //Офис
        Warehouse = 5, //Склад
        Commercial = 6, //Коммерческое помещение


        Other = 999 //Другой тип объекта
    }
}
