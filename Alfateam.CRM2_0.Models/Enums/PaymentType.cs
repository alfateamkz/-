using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Способ оплаты
    /// </summary>
    public enum PaymentType
    {
        Card = 1, //На карту
        Cashless = 2, //Без.нал. на РС
        Cash = 3, //Наличные
        Exchange = 4, //На счет обменника/биржы
        Escrow = 5, //Безопасная сделка
    }
}
