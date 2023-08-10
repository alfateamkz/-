using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Outstaff
{
    public class OutstaffItemGradeLocalizationEditModel : LocalizationEditModel<OutstaffItemGradeLocalization>
    {
        public string Title { get; set; }
    }
}
