using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases
{
    public class LegalCaseCreateModel : CreateModel<LegalCase>
    {
        public LegalCaseRole Role { get; set; } = LegalCaseRole.Plaintiff;
        public int SecondSideId { get; set; }

        public string CaseInfo { get; set; }
    }
}
