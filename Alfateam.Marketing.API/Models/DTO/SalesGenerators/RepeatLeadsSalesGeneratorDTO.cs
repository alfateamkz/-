using Alfateam.Marketing.API.Models.DTO.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators
{
    public class RepeatLeadsSalesGeneratorDTO : SalesGeneratorDTO
    {
        public bool AlwaysSetResponsibleWhoWorkingNow { get; set; }
        public bool AlwaysCreateLead { get; set; }
        public bool AssignOldManagerToLead { get; set; }
    }
}
