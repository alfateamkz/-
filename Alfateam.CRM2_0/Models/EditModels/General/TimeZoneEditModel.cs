using Alfateam.CRM2_0.Abstractions;

namespace Alfateam.CRM2_0.Models.EditModels.General
{
    public class TimeZoneEditModel : EditModel<Alfateam.CRM2_0.Models.General.TimeZone>
    {
        public string Title { get; set; }
        public TimeSpan Offset { get; set; }
    }
}
