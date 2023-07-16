using Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring.Questions
{
    /// <summary>
    /// Модель вопроса скоринга, которая подразумевает отсутствие или наличие признака
    /// Или ответ на вопрос да/нет
    /// </summary>
    public class ScoringYesNoQuestion : ScoringQuestion
    { 
        public string Title { get; set; }
        public double YesScore { get; set; }
        public double NoScore { get; set; }
    }
}
