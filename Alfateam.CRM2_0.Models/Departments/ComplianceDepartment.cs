using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General.Assessment.Risks;
using Alfateam.CRM2_0.Models.Roles.Compliance;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Roles.Compliance.Law;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Отдел комплаенса 
    /// </summary>
    public class ComplianceDepartment : Department
    {

        #region Appeals
        public List<Appeal> Appeals { get; set; } = new List<Appeal>();
        #endregion

        #region Conflicts

        #region Resolutions
        public List<ConflictResolutionAlgorithm> ConflictResolutionAlgorithms { get; set; } = new List<ConflictResolutionAlgorithm>();

        #endregion

        public List<Conflict> Conflicts { get; set; } = new List<Conflict>();

        #endregion

        #region Corruption
        public List<CorruptionCase> CorruptionCases { get; set; } = new List<CorruptionCase>();
        #endregion

        #region Fraud
        public List<FraudDescription> FraudDescriptions { get; set; } = new List<FraudDescription>();
        #endregion

        #region Law
        public List<ProhibitedService> ProhibitedServices { get; set; } = new List<ProhibitedService>();
        #endregion

        #region Risks
        public List<Risk> Risks { get; set; } = new List<Risk>();
        #endregion

        public List<ComplianceRequirements> ComplianceRequirements { get; set; } = new List<ComplianceRequirements>();
        public List<ComplianceRequirementsCategory> ComplianceRequirementsCategories { get; set; } = new List<ComplianceRequirementsCategory>();
    }
}
