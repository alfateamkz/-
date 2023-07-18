using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Services
{
    /// <summary>
    /// Тип, описывающий варианты цены за услугу
    /// </summary>
    public enum ServicePriceType
    {
        MinimumPrice = 1, //Стоимость услуги от ...
        FixedPrice = 2, //Фиксированная стоимость услуги (например, регистрация аккаунта разработчика apple)
        Monthly = 3, //Ежемесячная оплата (например, поддержка сайта)
        Weekly = 4, //Понедельная оплата (например, поддержка сайта)
        Hourly = 5, //Почасовая оплата (например, аутстафф/почасовка)
    }
}
