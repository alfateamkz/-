using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.EditModels.Outstaff
{
    public class OutstaffColumnMainEditModel : EditModel<OutstaffColumn>
    {
        public string Title { get; set; }
        public double Discount { get; set; }


        public int MainLanguageId { get; set; }
    }
}
