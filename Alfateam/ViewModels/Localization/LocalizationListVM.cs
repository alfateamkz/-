using Alfateam.Database.Models;

namespace Triggero.Web.ViewModels.Localization
{
    public class LocalizationListVM<T>
    {
        public List<T> Items { get; set; }
        public Language CurrentLanguage { get; set; }
    }
}
