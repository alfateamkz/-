using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Contests
{
    public class ContestWinnerCreateModel : CreateModel<ContestWinner>
    {
        public int UserId { get; set; }
        public int Place { get; set; }
    }
}
