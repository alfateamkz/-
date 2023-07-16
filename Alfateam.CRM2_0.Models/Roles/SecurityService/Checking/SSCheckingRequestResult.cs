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
    /// Ответ на запрос на проверку службой безопасности
    /// </summary>
    public class SSCheckingRequestResult : AbsModel
    {
        public SSCheckingRequestResultType Type { get; set; }
        public string? Comment { get; set; }


        /// <summary>
        /// Инициированная проверка, если сотрудник СБ принял запрос на проверку
        /// </summary>
        public SSChecking? Checking { get; set; }

    }
}
