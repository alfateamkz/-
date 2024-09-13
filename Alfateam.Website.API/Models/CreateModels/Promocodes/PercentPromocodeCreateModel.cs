namespace Alfateam.Website.API.Models.CreateModels.Promocodes
{
    public class PercentPromocodeCreateModel : PromocodeCreateModel
    {
        public override string Discriminator => "PercentPromocode";

        public double Percent { get; set; }
    }
}
