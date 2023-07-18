using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Assessment.Risks
{
    /// <summary>
    /// Сущность оценки риска
    /// </summary>
    public class RiskAssessment : AbsModel
    {
        /// <summary>
        /// Вероятность наступления риска от 0 до 100
        /// </summary>
        public double Probability { get; set; }
        public List<RiskConsequence> Consequences { get; set; } = new List<RiskConsequence>();
        public string TotalEstimation { get; set; }

    }
}
