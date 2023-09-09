using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases
{
    /// <summary>
    /// Модель запроса на открытие юридического дела 
    /// </summary>
    public class LegalCaseRequest : AbsModel
    {

        /// <summary>
        /// Кто запросил дело
        /// </summary>
        public User From { get; set; }
        public int FromId { get; set; }
        

        /// <summary>
        /// С кем спор
        /// </summary>
        public User? SecondSide { get; set; }
        public int? SecondSideId { get; set; }




        /// <summary>
        /// Суть дела
        /// </summary>
        public string CaseInfo { get; set; }




        /// <summary>
        /// Результат запроса на открытие юридического дела
        /// </summary>
        public LegalCaseRequestResult? Result { get; set; }
        public int? ResultId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LawDepartmentId { get; set; }
    }
}
