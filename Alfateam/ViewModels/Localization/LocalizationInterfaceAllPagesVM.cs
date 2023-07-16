using Triggero.Web.Models.Localization;

namespace Triggero.Web.ViewModels.Localization
{
    public class LocalizationInterfaceAllPagesVM
    {
        public List<LocalizationPageGroupItem> Groups { get; set; } = new List<LocalizationPageGroupItem>();
        public int? LanguageId { get; set; }
    }
}
