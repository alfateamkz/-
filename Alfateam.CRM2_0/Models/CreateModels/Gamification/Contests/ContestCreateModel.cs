using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Contests
{
    public class ContestCreateModel : CreateModel<Contest>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);
    }
}
