using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases
{
    public class LegalCaseResultCreateModel : CreateModel<LegalCaseResult>
    {
        public string Decision { get; set; }
        public string Comment { get; set; }
    }
}
