using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Models.DTO
{
    public class PartnerDTO : DTOModel<Partner>
    {
        public string Title { get; set; }
        public string LogoPath { get; set; }
        public Content Content { get; set; }



        public int MainLanguageId { get; set; }
    }
}
