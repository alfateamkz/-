using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{
    public enum LegalCaseRequestResultType
    {
        Approved = 1, //Запрос на проверку согласован юристом
        Rejected = 2 //Запрос на проверку отклонен юристом
    }
}
