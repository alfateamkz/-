using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class PricingMatrixDTO : DTOModel<PricingMatrix>
    {
        public List<PricingMatrixItem> Costs { get; set; } = new List<PricingMatrixItem>();

        public override bool IsValid()
        {
            return base.IsValid();
        }

        public override void FillDBModel(PricingMatrix matrix, DBModelFillMode mode)
        {
            //Удаляем удаленные на фронте элементы
            for (int i = matrix.Costs.Count - 1; i > -1; i--)
            {
                var item = matrix.Costs[i];
                if (!Costs.Any(o => o.Id == item.Id))
                {
                    matrix.Costs.Remove(item);
                }
            }

            //Добавляем новые или редактируем текущие элементы
            foreach (var costItem in Costs)
            {
                var matrixCostItem = Costs.FirstOrDefault(o => o.Id == costItem.Id);
                if (matrixCostItem == null)
                {
                    matrix.Costs.Add(costItem);
                }
                else
                {
                    matrixCostItem.Costs.Clear();

                    matrixCostItem.Country = costItem.Country;
                    matrixCostItem.CountryId = costItem.CountryId;
                    matrixCostItem.Costs = costItem.Costs;
                }
            }
        }
    }
}
