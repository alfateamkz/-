using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring
{
    /// <summary>
    /// Модель вопроса результата скоринга
    /// </summary>
    public class SSCheckingScoringResultQuestion : AbsModel
    {
        /// <summary>
        /// Заголовок вопроса
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Доступные варианты ответа на вопрос скоринга на момент прохождения
        /// </summary>
        public List<SSCheckingScoringResultQAvailableOption> AvailableOptions { get; set; } = new();

        /// <summary>
        /// Ответ на вопрос
        /// </summary>
        public SSCheckingScoringResultAnswer Answer { get; set; }
    }
}
