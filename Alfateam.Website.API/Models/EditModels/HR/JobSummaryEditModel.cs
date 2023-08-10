using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.EditModels.HR
{
    public class JobSummaryEditModel : EditModel<JobSummary>
    {
        public JobSummaryStatus Status { get; set; } = JobSummaryStatus.Active;


        public string Name { get; set; }
        public string Surname { get; set; }
        public string AboutInfo { get; set; }
        public string? CVPath { get; set; }


        public string CreatedByFingerprint { get; set; }


        public string? Note { get; set; }
    }
}
