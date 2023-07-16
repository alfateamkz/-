using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals
{
    /// <summary>
    /// Тип источника обращения в службу комплаенс
    /// </summary>
    public enum AppealSource
    {
        Internal = 1, //От сотрудника
        Public = 2, //Из внешнего источника
    }
}
