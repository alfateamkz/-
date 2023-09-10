using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases
{
    /// <summary>
    /// Юридическое дело
    /// Используется для ведения случаев, где были нарушены права одной из сторон или как пример, произошла мошенническая ситуация
    /// </summary>
    public class LegalCase : AbsModel
    {
        /// <summary>
        /// Кем создано юридическое дело
        /// </summary>
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }



        /// <summary>
        /// Наша роль в деле
        /// </summary>
        public LegalCaseRole Role { get; set; } = LegalCaseRole.Plaintiff;


        /// <summary>
        /// Порядок ведения дела
        /// </summary>
        public LegalCaseProcedure Procedure { get; set; } = LegalCaseProcedure.PreTrial;

        /// <summary>
        /// Судебные процессы
        /// </summary>
        public List<Litigation> Litigations { get; set; } = new List<Litigation>();




        /// <summary>
        /// С кем возникла спорная ситуация (клиент, работник или контрагент)
        /// </summary>
        public User? SecondSide { get; set; }
        public int SecondSideId { get; set; }


        /// <summary>
        /// Суть дела
        /// </summary>
        public string CaseInfo { get; set; }


        /// <summary>
        /// Документы, составление в ходе ведения дела
        /// </summary>
        public List<Document> Documents { get; set; } = new List<Document>();

        
        public LegalCaseResult? Result { get; set; }
        public int? ResultId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LawDepartmentId { get; set; }

    }
}
