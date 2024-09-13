using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.CreateModels.Outstaff
{
    public class OutstaffItemGradeCreateModel : CreateModel<OutstaffItemGrade>
    {
        public string Title { get; set; }


        public int MainLanguageId { get; set; }
    }
}
