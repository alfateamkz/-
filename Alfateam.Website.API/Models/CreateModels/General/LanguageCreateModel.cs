using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.CreateModels.General
{
    public class LanguageCreateModel : CreateModel<Language>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public bool IsRightToLeft { get; set; }


        public bool IsHidden { get; set; }


        public int MainLanguageId { get; set; }
    }
}
