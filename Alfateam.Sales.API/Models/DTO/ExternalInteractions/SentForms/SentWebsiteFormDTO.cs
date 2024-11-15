using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.SentForms;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms
{
    public class SentWebsiteFormDTO : DTOModelAbs<SentWebsiteForm>
    {
        public string UserAgent { get; set; }
        public string IP { get; set; }

        public List<SentWebsiteFormField> Fields { get; set; } = new List<SentWebsiteFormField>();
    }
}
