using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Shop;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Shop
{
    public class ShopCategoryClientModel : ClientModel<ShopCategory>
    {
        public string Title { get; set; }
    }
}
