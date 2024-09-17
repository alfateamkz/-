using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffItemGradeDTO : DTOModel<OutstaffItemGrade>
    {
        public string Title { get; set; }
        public List<OutstaffItemGradeColumnDTO> Prices { get; set; } = new List<OutstaffItemGradeColumnDTO>();


        public int MainLanguageId { get; set; }




        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int OutstaffItemId { get; set; }

        public static OutstaffItemGradeDTO Create(OutstaffItemGrade item, int? langId, int? countryId)
        {

            var model = new OutstaffItemGradeDTO();

            model.Id = item.Id;
            model.Title = item.Title;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            model.Prices = OutstaffItemGradeColumnDTO.CreateItems(item.Prices, langId, countryId);

            return model;
        }
        public static List<OutstaffItemGradeDTO> CreateItems(List<OutstaffItemGrade> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffItemGradeDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
