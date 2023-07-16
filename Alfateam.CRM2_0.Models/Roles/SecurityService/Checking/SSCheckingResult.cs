using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking
{
    /// <summary>
    /// Модель результата проверки службой безопасности
    /// </summary>
    public class SSCheckingResult : AbsModel
    {
        public SSCheckingResultType Type { get; set; }


        
        public string Decision { get; set; }
        public string Comment { get; set; }

       
    }
}
