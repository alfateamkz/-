namespace Alfateam.Website.API.Models.DTO.Promocodes
{
    public class PercentPromocodeDTO : PromocodeDTO
    {
        public override string Discriminator => "PercentPromocode";

        public double Percent { get; set; }
    }
}
