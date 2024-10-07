using Alfateam.EDM.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO
{
    public class CounterpartyGroupDTO : DTOModelAbs<CounterpartyGroup>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
