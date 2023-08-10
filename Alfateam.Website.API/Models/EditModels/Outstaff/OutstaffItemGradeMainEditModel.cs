using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.EditModels.Outstaff
{
    public class OutstaffItemGradeMainEditModel : EditModel<OutstaffItemGrade>
    {
        public string Title { get; set; }


        public int MainLanguageId { get; set; }
    }
}
