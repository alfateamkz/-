using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class LegalFormCreateModel : CreateModel<LegalForm>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public LegalFormType Type { get; set; }
    }
}
