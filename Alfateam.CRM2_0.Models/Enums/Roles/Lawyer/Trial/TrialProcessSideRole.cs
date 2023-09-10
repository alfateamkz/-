using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial
{
    /// <summary>
    /// Роль стороны судебного процесса
    /// </summary>
    public enum TrialProcessSideRole
    {
        Plaintiff = 1, //Истец
        Defendant = 2, //Ответчик


        Other = 999 //Прочая непредусмторенная сторона
    }
}
