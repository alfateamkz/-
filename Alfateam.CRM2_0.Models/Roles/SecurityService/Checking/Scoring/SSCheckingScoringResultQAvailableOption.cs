using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring
{
    /// <summary>
    /// Доступный вариант ответа на вопрос скоринга на момент прохождения
    /// Если вопрос типа Yes/No, то в модели SSCheckingScoringResultQuestion создаются 2 таких сущности 
    /// </summary>
    public class SSCheckingScoringResultQAvailableOption : AbsModel
    {
        public string OptionText { get; set; }
        public double Score { get; set; }
    }
}
