using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.SecurityService
{
    public enum SSCheckingRequestResultType
    {
        Approved = 1, //Запрос на проверку согласован сотрудником СБ
        Rejected = 2 //Запрос на проверку отклонен сотрудником СБ
    }
}
