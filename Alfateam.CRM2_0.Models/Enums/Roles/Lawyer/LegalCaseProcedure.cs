using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{
    /// <summary>
    /// Порядок юридического дела
    /// </summary>
    public enum LegalCaseProcedure
    {
        PreTrial = 1, //Досудебный
        Trial = 2, //Судебный


        Other = 999 //Иной
    }
}
