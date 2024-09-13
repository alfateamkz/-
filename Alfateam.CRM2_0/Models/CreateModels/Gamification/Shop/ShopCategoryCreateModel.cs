using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Shop;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop
{
    public class ShopCategoryCreateModel : CreateModel<ShopCategory>
    {
        public string Title { get; set; }
    }
}
