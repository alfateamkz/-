using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Manuals
{
    public class HRManualClientModel : ClientModel<HRManual>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public HRManualCategoryClientModel Category { get; set; }
    }
}
