using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.CreateModels.General
{
    public class CountryCreateModel : CreateModel<Country>
    {
        public string Title { get; set; }
        public string Code { get; set; }


        public bool IsHidden { get; set; }


        public int OfficialMainLanguageId { get; set; }
        public List<int> LanguagesIds { get; set; } = new List<int>();


        public int MainLanguageId { get; set; }



        public int MainCurrencyId { get; set; }
        public List<int> Currencies { get; set; } = new List<int>();


        public override void Fill(Country item)
        {
            throw new NotSupportedException("Use Fill(Country item, List<Language> allLanguages) instead");
        }
        public void Fill(Country item, List<Language> allLanguages)
        {
            base.Fill(item);

            //Удаляем удаленные на фронте
            for(int i = item.Languages.Count-1;i > -1; i--)
            {
                var lang = item.Languages[i];
                if (!LanguagesIds.Any(o => o == lang.Id))
                {
                    item.Languages.Remove(lang);
                }
            }

            foreach(var id in LanguagesIds)
            {
                if(!item.Languages.Any(o => o.Id == id))
                {
                    item.Languages.Add(allLanguages.FirstOrDefault(o => o.Id == id));
                }
            }
        }
    }
}
