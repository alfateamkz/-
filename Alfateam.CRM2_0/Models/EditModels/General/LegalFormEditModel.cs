using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.EditModels.General
{
    public class LegalFormEditModel : EditModel<LegalForm>
    {
        public string Title { get; set; }
    }
}
