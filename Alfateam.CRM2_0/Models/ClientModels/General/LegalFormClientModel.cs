using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class LegalFormClientModel : ClientModel<LegalForm>
    {
        public string Title { get; set; }
    }
}
