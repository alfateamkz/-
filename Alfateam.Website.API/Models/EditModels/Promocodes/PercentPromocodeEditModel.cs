namespace Alfateam.Website.API.Models.EditModels.Promocodes
{
    public class PercentPromocodeEditModel : PromocodeEditModel
    {
        public override string Discriminator => "PercentPromocode";

        public double Percent { get; set; }
    }
}
