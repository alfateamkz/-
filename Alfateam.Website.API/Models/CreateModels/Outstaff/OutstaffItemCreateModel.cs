using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.CreateModels.Outstaff
{
    public class OutstaffItemCreateModel : CreateModel<OutstaffItem>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}
