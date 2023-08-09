using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.EditModels.Shop
{
    public class ShopProductCategoryMainEditModel : EditModel<ShopProductCategory>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}
