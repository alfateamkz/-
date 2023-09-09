using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.LegalCases
{
    public class LegalCaseEditModel : EditModel<LegalCase>
    {
        public LegalCaseRole Role { get; set; } = LegalCaseRole.Plaintiff;
        public int SecondSideId { get; set; }

        public string CaseInfo { get; set; }
    }
}
