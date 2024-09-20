namespace Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems
{
    public class ColorModifierItemDTO : ProductModifierItemDTO
    {
        public override string Discriminator => "ColorModifierItem";

        public string ColorHex { get; set; }
    }
}
