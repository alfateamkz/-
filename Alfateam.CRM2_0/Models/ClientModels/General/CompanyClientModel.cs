using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class CompanyClientModel : ClientModel<Company>
    {
        public LegalFormClientModel Country { get; set; }
        public LegalFormClientModel Form { get; set; }


        public string LegalName { get; set; }
        public string LegalInfo { get; set; }

        public AddressClientModel LegalAddress { get; set; }
        public AddressClientModel? ActualAddress { get; set; }
    }
}
