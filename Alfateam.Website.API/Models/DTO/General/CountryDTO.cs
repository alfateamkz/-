using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class CountryDTO : DTOModel<Country>
    {
        public string Title { get; set; }
        public string Code { get; set; }




        [HiddenFromClient]
        public bool IsHidden { get; set; }

        [HiddenFromClient]
        public int OfficialMainLanguageId { get; set; }
        [HiddenFromClient]
        public List<int> LanguagesIds { get; set; } = new List<int>();

        [HiddenFromClient]
        public int MainLanguageId { get; set; }


        [HiddenFromClient]
        public int MainCurrencyId { get; set; }
        [HiddenFromClient]
        public List<int> Currencies { get; set; } = new List<int>();



        public override void FillDBModel(Country item, DBModelFillMode mode)
        {
            throw new NotSupportedException("Use Fill(Country item, List<Language> allLanguages, DBModelFillMode mode) instead");
        }
        public void FillDBModel(Country item, List<Language> allLanguages, DBModelFillMode mode)
        {
            base.FillDBModel(item, mode);

            //Удаляем удаленные на фронте
            for (int i = item.Languages.Count - 1; i > -1; i--)
            {
                var lang = item.Languages[i];
                if (!LanguagesIds.Any(o => o == lang.Id))
                {
                    item.Languages.Remove(lang);
                }
            }

            foreach (var id in LanguagesIds)
            {
                if (!item.Languages.Any(o => o.Id == id))
                {
                    item.Languages.Add(allLanguages.FirstOrDefault(o => o.Id == id));
                }
            }
        }
    }
}
