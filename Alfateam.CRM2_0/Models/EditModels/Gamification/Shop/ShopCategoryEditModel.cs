using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Shop;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Shop
{
    public class ShopCategoryEditModel : EditModel<ShopCategory>
    {
        public string Title { get; set; }
    }
}
