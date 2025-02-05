using Alfateam.Sales.Models.Integrations.API;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Integrations.API
{
    public class AlfateamAPIRequestEntryDTO : DTOModelAbs<AlfateamAPIRequestEntry>
    {
        public string URL { get; set; }
        public string HTTPMethod { get; set; }
        public string Headers { get; set; }
        public string? Response { get; set; }




        public string IP { get; set; }
        public string? UserAgent { get; set; }
    }
}
