using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR
{
    /// <summary>
    /// Модель решения, вынесенного после собеседования
    /// </summary>
    public class CandidateInterviewDecision : AbsModel
    {
        public CandidateInterviewDecisionType Type { get; set; } 
        public string Comment { get; set; }
    }
}
