using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Financier
{
    /// <summary>
    /// Статус модели ценообразования
    /// </summary>
    public enum PricingModelStatus
    {
        Actual = 1, //Текущая модель
        Reseacrh = 2, //Исследование модели цен
        ApprovedForFuture = 3, //Утверджено на будущее
        Rejected = 4, //Отклонена
        Old = 5, //Ценообразование стало неактуальным, используется другая модель
    }
}
