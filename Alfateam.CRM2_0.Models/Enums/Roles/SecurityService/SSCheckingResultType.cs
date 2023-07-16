using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.SecurityService
{
    /// <summary>
    /// Вид результата проверки службой безопасности
    /// </summary>
    public enum SSCheckingResultType
    {
        Passed = 1, //Проверка пройдена
        NotPassed = 2, //Проверка не пройдена

    }
}
