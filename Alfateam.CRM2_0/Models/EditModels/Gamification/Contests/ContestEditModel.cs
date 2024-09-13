using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Contests
{
    public class ContestEditModel : EditModel<Contest>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    }
}
