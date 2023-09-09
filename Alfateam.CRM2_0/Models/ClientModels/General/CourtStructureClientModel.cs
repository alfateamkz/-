using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class CourtStructureClientModel : ClientModel<CourtStructure>
    {
        public CountryClientModel Country { get; set; }
        public string Title { get; set; }
    }
}
