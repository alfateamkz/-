using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    public class SecurityServiceDepartment : AbsModel
    {

        #region Checking
        public List<SSChecking> SSCheckings { get; set; } = new List<SSChecking>();
        public List<SSCheckingRequest> SSCheckingRequests { get; set; } = new List<SSCheckingRequest>();
        #endregion

        #region Scoring
        public List<ScoringModel> ScoringModels { get; set; } = new List<ScoringModel>();
        #endregion

    }
}
