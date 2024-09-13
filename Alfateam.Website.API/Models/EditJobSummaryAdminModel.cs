using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models
{
    public class EditJobSummaryAdminModel : DTOModel<JobSummary>
    {
        public JobSummaryStatus Status { get; set; } = JobSummaryStatus.Active;
        public string? Note { get; set; }
    }
}
