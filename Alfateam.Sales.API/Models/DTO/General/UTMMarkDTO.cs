using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class UTMMarkDTO : DTOModelAbs<UTMMark>
    {
        public string Source { get; set; }
        public string Medium { get; set; }
        public string Campaign { get; set; }


        public string? Content { get; set; }
        public string? Term { get; set; }
    }
}
