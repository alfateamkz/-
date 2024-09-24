using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.DTO.HR
{
    public class JobSummaryDTO : DTOModel<JobSummary>
    {
        [DTOFieldFor(DTOFieldForType.UpdateOnly)]
        public JobSummaryStatus Status { get; set; } = JobSummaryStatus.Active;


        public string Name { get; set; }
        public string Surname { get; set; }
        public string AboutInfo { get; set; }

        [ForClientOnly]
        public string? CVPath { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string CreatedByFingerprint { get; set; }


        [DTOFieldFor(DTOFieldForType.UpdateOnly)]
        public string? Note { get; set; }
    }
}
