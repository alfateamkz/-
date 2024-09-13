using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Contests
{
    public class ContestWinnerClientModel : ClientModel<ContestWinner>
    {
        public UserClientModel User { get; set; }
        public int Place { get; set; }
        public ContestPrizeClientModel Prize { get; set; }
    }
}
