using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Тип блока алгоритма урегулирования конфликта
    /// </summary>
    public enum ConflictResolutionAlgorithmBlockType
    {
        Start = 1, //Начальный блок
        Information = 2, //Блок с информацией
        Condition = 3, //Условный блок
        End = 4 //Конечный блок
    }
}
