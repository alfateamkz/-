using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Отдел маркетинга
    /// </summary>
    public class MarketingDepartment : Department
    {

        #region Referral
        public List<BaseReferralProgram> ReferralPrograms { get; set; } = new List<BaseReferralProgram>();
        #endregion

        public List<AdCampaign> AdCampaigns { get; set; } = new List<AdCampaign>(); 

    }
}
