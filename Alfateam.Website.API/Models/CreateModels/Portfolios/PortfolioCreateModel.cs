using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.CreateModels.Portfolios
{
    public class PortfolioCreateModel : CreateModel<Portfolio>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        public int CategoryId { get; set; }
        public int IndustryId { get; set; }



        public int MainLanguageId { get; set; }
    }
}
