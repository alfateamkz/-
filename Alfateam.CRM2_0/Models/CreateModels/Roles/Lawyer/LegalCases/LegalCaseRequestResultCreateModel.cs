using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases
{
    public class LegalCaseRequestResultCreateModel : CreateModel<LegalCaseRequestResult>
    {
        public LegalCaseRequestResultType Type { get; set; }
        public string? Comment { get; set; }
    }
}
