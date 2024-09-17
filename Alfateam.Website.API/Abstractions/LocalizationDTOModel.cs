using Alfateam2._0.Models.Abstractions;

namespace Alfateam.Website.API.Abstractions
{
    public class LocalizationDTOModel<T> : DTOModel<T> where T : LocalizableModel, new()
    {
        public int LanguageEntityId { get; set; }
    }
}
