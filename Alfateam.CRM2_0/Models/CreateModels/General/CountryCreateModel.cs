using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class CountryCreateModel : CreateModel<Country>
    {
        /// <summary>
        /// Название страны
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Название страны на официальном языке
        /// </summary>
        public string OriginalTitle { get; set; }
        /// <summary>
        /// Код страны
        /// </summary>
        public string Code { get; set; }
    }
}
