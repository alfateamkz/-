using Alfateam.CRM2_0.Models.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Questionnaires
{
    /// <summary>
    /// Модель ответа на вопрос опросника для HR
    /// </summary>
    public class HRQuestionaireQuestionOption : AbsModel
    {
        public string Title { get; set; }
        public double Score { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        [JsonIgnore]
        public int HRQuestionaireOptionsQuestionId { get; set; }
    }
}
