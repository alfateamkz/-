using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.LegalCases
{
    public class LegalCaseClientModel : ClientModel<LegalCase>
    {  
        public User CreatedBy { get; set; }


        public LegalCaseRole Role { get; set; } = LegalCaseRole.Plaintiff;
        public LegalCaseProcedure Procedure { get; set; } = LegalCaseProcedure.PreTrial;


        public User? SecondSide { get; set; }

        public string CaseInfo { get; set; }
    }
}
