using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Тип реюзабельной модели рисков
    /// </summary>
    public enum RisksModelType
    {
        Compliance = 1, //Комплаенс риски
        Financial = 2, //Финансовые риски
        Reputational = 3, //Репутационные риски


        Other = 999, //Иные риски
    }
}
