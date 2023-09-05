using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals
{
    public class HRManualCategoryEditModel : EditModel<HRManualCategory>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
