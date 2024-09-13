using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class LegalFormClientModel : ClientModel<LegalForm>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public LegalFormType Type { get; set; }
    }
}
