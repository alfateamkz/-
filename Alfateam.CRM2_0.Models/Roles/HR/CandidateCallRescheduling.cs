using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR
{
    /// <summary>
    /// Сущность, описывающая перенос созвона
    /// </summary>
    public class CandidateCallRescheduling : AbsModel
    {
        public DateTime OldPlannedTime { get; set; }
        public DateTime NewPlannedTime { get; set; }

        public string? Comment { get; set; }
    }
}
