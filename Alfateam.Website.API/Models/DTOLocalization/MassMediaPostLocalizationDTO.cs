using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.DTOLocalization
{
    public class MassMediaPostLocalizationDTO : DTOModel<MassMediaPostLocalization>
    {

        public string Title { get; set; }
        public string ShortDescription { get; set; }
    }
}
