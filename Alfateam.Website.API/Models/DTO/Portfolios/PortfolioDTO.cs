using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.DTO.Portfolios
{
    public class PortfolioDTO : AvailabilityDTOModel<Portfolio>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }



        public string Slug => SlugHelper.GetLatynSlug(Title);


        [ForClientOnly]
        public PortfolioCategoryDTO Category { get; set; }
        [ForClientOnly]
        public PortfolioIndustryDTO Industry { get; set; }


        public int CategoryId { get; set; }
        public int IndustryId { get; set; }



  
    }
}
