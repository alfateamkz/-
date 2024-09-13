using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Contests
{
    public class ContestResultCreateModel : CreateModel<ContestResult>
    {
        public string Comment { get; set; }
        public List<ContestWinnerCreateModel> Winners { get; set; } = new List<ContestWinnerCreateModel>();



        public override ContestResult Create()
        {
            var result = base.Create();
            result.Winners = ContestWinnerCreateModel.CreateItemsFromModels(Winners).ToList();

            return result;
        }
    }
}
