using Alfateam.Database.Models.Abstractions;

namespace Triggero.Web.ViewModels.Localization
{
    public class LocalizationVM<T> where T: LocalizationModel, new()
    {
        public int Id { get; set; }
        public T Localization { get; set; } = new T();

    }
}
