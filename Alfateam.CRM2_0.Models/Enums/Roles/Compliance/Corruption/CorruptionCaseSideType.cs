using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Corruption
{
    /// <summary>
    /// Тип стороны коррупционного инцидента
    /// </summary>
    public enum CorruptionCaseSideType
    {
        Bribetakers = 1, //Те, кто берут взятку
        Bribegivers = 2, //Те, кто дают взятку
        Compliance = 3, //Комплаенс служба


        Other = 999 //Иная сторона
    }
}
