using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.CreateModels.HR
{
    public class JobSummaryCreateModel : CreateModel<JobSummary>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AboutInfo { get; set; }
        public string? CVPath { get; set; }


        public string CreatedByFingerprint { get; set; }


        public string? Note { get; set; }
    }
}
