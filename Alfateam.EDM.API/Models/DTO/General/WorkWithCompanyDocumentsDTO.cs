using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class WorkWithCompanyDocumentsDTO : DTOModelAbs<WorkWithCompanyDocuments>
    {
        public string FIO { get; set; }
        public string? Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? OtherInfo { get; set; }
    }
}
