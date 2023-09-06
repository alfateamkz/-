using Alfateam.CRM2_0.Abstractions;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class TimeZoneCreateModel : CreateModel<Alfateam.CRM2_0.Models.General.TimeZone>
    {
        public string Title { get; set; }
        public TimeSpan Offset { get; set; }
    }
}
