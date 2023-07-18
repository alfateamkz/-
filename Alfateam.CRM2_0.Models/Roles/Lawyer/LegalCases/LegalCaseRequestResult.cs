using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases
{
    /// <summary>
    /// Модель результата запроса на открытие юридического дела 
    /// </summary>
    public class LegalCaseRequestResult : AbsModel
    {
        public LegalCaseRequestResultType Type { get; set; }
        public string? Comment { get; set; }



        /// <summary>
        /// Инициированное дело, если юрист принял запрос на создание дела
        /// </summary>
        public LegalCase? LegalCase { get; set; }



    }
}
