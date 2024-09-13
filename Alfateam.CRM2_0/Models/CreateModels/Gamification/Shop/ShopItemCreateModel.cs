using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Shop;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop
{
    public class ShopItemCreateModel : CreateModel<ShopItem>
    {
        public ShopItemType Type { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }


        public double Price { get; set; }
        public double Rating { get; set; }


        public int CategoryId { get; set; }
    }
}
