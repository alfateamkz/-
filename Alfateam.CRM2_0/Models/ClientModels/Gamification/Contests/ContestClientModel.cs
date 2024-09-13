using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Contests
{
    public class ContestClientModel : ClientModel<Contest>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public ContestResultClientModel? Result { get; set; }
    }
}
