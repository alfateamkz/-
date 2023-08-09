using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.EditModels.General
{
    public class CountryMainEditModel : EditModel<Country>
    {
        public string Title { get; set; }
        public string Code { get; set; }


        public bool IsHidden { get; set; }


        public int OfficialMainLanguageId { get; set; }
        public List<int> LanguagesIds { get; set; } = new List<int>();


        public int MainLanguageId { get; set; }

        public override void Fill(Country item)
        {
            base.Fill(item);

            //TODO: заполнение, удаление языков из модельки
        }
    }
}
