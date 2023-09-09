using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Сущность судебного заседания
    /// </summary>
    public class TrialHearing : AbsModel
    {
        public Judge Judge { get; set; }
        public int JudgeId { get; set; }


        public Court Court { get; set; }
        public int CourtId { get; set; }


        public DateTime Date { get; set; }



        public TrialHearingResult? Result { get; set; }
        public int? ResultId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? LitigationId { get; set; }

    }
}
