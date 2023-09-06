using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Отдел рекрутинга 
    /// </summary>
    public class HRDepartment : Department
    {

        #region JobVacancies
        public List<JobVacancy> JobVacancies { get; set; } = new List<JobVacancy>();
        #endregion

        #region Manuals
        public List<HRManual> HRManuals { get; set; } = new List<HRManual>();
        public List<HRManualCategory> HRManualCategories { get; set; } = new List<HRManualCategory>();
        #endregion

        #region Questionnaires
        public List<HRQuestionnaireCategory> HRQuestionnaireCategories { get; set; } = new List<HRQuestionnaireCategory>();
        public List<HRQuestionnaire> HRQuestionnaires { get; set; } = new List<HRQuestionnaire>();

        #endregion


        public List<Candidate> Candidates { get; set; } = new List<Candidate>();
        public List<CandidateCall> CandidateCalls { get; set; } = new List<CandidateCall>();
    }
}
