using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Outstaff;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ProductModifierDTO : DTOModel<ProductModifier>
    {
        public string Title { get; set; }



        /// <summary>
        /// Если Type == Color, то все Options должны быть типа ColorModifierItem
        /// </summary>
        public ProductModifierType Type { get; set; } = ProductModifierType.Combobox;
        public bool IsRequired { get; set; }
        public bool AllowMultipleSelection { get; set; }



        [ForClientOnly]
        public List<ProductModifierItemDTO> Options { get; set; } = new List<ProductModifierItemDTO>();




        public int MainLanguageId { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int ShopProductId { get; set; }



        public ProductModifierDTO CreateDTOWithLocalization(ProductModifier item, int langId, int countryId, int currencyId)
        {
            var dto = (ProductModifierDTO)this.CreateDTOWithLocalization(item, langId);
            dto.Options = new ProductModifierItemDTO().CreateDTOsWithLocalization(item.Options, langId, countryId, currencyId);

            return dto;
        }
        public List<ProductModifierDTO> CreateDTOsWithLocalization(List<ProductModifier> items, int langId, int countryId, int currencyId)
        {
            var models = new List<ProductModifierDTO>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, langId, countryId, currencyId));
            }
            return models;
        }
    }
}
