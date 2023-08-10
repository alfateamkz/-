using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.EditModels.Outstaff
{
    public class OutstaffItemMainEditModel : EditModel<OutstaffItem>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}
