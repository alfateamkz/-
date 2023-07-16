using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring
{
    /// <summary>
    /// Модель варианта ответа на вопрос скоринга
    /// Используется классом ScoringOptionsQuestion
    /// </summary>
    public class ScoringQuestionOption : AbsModel
    {
        public string Title { get; set; }
        public double Score { get; set; }
    }
}
