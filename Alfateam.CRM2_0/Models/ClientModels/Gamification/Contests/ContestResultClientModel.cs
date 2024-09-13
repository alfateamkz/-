using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Contests
{
    public class ContestResultClientModel : ClientModel<ContestResult>
    {
        public string Comment { get; set; }
        public List<ContestWinnerClientModel> Winners { get; set; } = new List<ContestWinnerClientModel>();
    }
}
