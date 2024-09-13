using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Contests
{
    public class ContestPlacesCreateModel : CreateModel<ContestPlaces>
    {
        /// <summary>
        /// Первое значение места. Если SecondValue == null, то нет диапазона и имеется единственное место
        /// Если есть - значит есть диапазон мест. Например: с 5 по 10 место
        /// </summary>
        public int FirstValue { get; set; }
        public int? SecondValue { get; set; }


        public ContestPrizeCreateModel Prize { get; set; }
        public double Coins { get; set; }
        public double Rating { get; set; }

        public override ContestPlaces Create()
        {
            var entity = base.Create();
            entity.Prize = new ContestPrizeCreateModel().Create();

            return entity;
        }

        public override bool IsValid()
        {
            var isValid = base.IsValid();

            if (Prize == null) return false;
            isValid &= Prize.IsValid();

            return isValid;
        }
    }
}
