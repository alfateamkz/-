using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffItemDTO : DTOModel<OutstaffItem>
    {
        public string Title { get; set; }
        public List<OutstaffItemGradeDTO> Grades { get; set; } = new List<OutstaffItemGradeDTO>();


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int OutstaffMatrixId { get; set; }


        public static OutstaffItemDTO Create(OutstaffItem item, int? langId, int? countryId)
        {

            var model = new OutstaffItemDTO();
            model.Id = item.Id;

            model.Grades = OutstaffItemGradeDTO.CreateItems(item.Grades, langId, countryId);

            return model;
        }
        public static List<OutstaffItemDTO> CreateItems(List<OutstaffItem> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffItemDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
