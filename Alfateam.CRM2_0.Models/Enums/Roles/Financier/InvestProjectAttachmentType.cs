using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Financier
{
    /// <summary>
    /// Тип вложения к инвест проекту
    /// </summary>
    public enum InvestProjectAttachmentType
    {
        BusinessPlan = 1, //Бизнес-план
        Presentation = 2, //Презентация
        FinancialPlan = 3, //Финансовый план
        Documentation = 4, //Документация к проекту
        Information = 5, //Информация


        Other = 999 //Иное вложение
    }
}
