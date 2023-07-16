using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Programs
{
    /// <summary>
    /// Модель многоуровневой реферальной программы
    /// </summary>
    public class MultiLevelReferralProgram : BaseReferralProgram
    {
        public List<MultiLevelReferralProgramLevel> Levels { get; set; } = new List<MultiLevelReferralProgramLevel>();
    }
}
