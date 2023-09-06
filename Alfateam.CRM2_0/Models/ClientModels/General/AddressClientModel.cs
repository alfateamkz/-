using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class AddressClientModel : ClientModel<Address>
    {
        public CountryClientModel Country { get; set; }

        public string State { get; set; }
        public string? District { get; set; }


        public string City { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set; }
    }
}
