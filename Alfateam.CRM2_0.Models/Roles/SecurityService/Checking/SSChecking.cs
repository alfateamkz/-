using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking
{
    /// <summary>
    /// Модель проверки службой безопасности
    /// </summary>
    public class SSChecking : AbsModel
    {
        /// <summary>
        /// Тип проверки
        /// </summary>
        public SSCheckingType Type { get; set; } = SSCheckingType.First;

        /// <summary>
        /// Сотрудник СБ
        /// </summary>
        public User CheckedBy { get; set; }
        public int CheckedById { get; set; }



        /// <summary>
        /// Проверяемый человек
        /// </summary>
        public User CheckedPerson { get; set; }
        public int CheckedPersonId { get; set; }


        /// <summary>
        /// Информация, которую нужно проверить
        /// </summary>
        public SSCheckingData CheckingData { get; set; }
        public int CheckingDataId { get; set; }



        /// <summary>
        /// Результаты проверки контактных данных на принадлежность человеку
        /// </summary>
        public List<SSCheckingVerificationInfo> VerificationResults { get; set; } = new List<SSCheckingVerificationInfo>();

        /// <summary>
        /// Результаты скоринг-проверок
        /// </summary>
        public List<SSCheckingScoringResult> ScoringResults { get; set; } = new List<SSCheckingScoringResult>();

        /// <summary>
        /// Итоговый результат проверки
        /// </summary>
        public SSCheckingResult? Result { get; set; }
        public int? ResultId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SecurityServiceDepartmentId { get; set; }
    }
}
