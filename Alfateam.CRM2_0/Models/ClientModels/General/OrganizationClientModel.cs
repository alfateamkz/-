using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class OrganizationClientModel : ClientModel<Organization>
    {
        public string Title { get; set; }
        public Address LegalAddress { get; set; }
        public string LegalInfo { get; set; }



        public TimeZoneClientModel TimeZone { get; set; }


        public CountryClientModel Country { get; set; }
        public LegalFormClientModel LegalForm { get; set; }
        public TaxSystemClientModel TaxSystem { get; set; }
    }
}
