using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class LegalFormCreateModel : CreateModel<LegalForm>
    {
        public string Title { get; set; }
    }
}
