namespace Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems
{
    public class SimpleModifierItemDTO : ProductModifierItemDTO
    {
        public override string Discriminator => "SimpleModifierItem";
    }
}
