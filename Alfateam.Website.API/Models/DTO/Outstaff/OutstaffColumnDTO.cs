using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.Outstaff;
using Alfateam2._0.Models.Team;

namespace Alfateam.Website.API.Models.DTO.Outstaff
{
    public class OutstaffColumnDTO : DTOModel<OutstaffColumn>
    {
        public string Title { get; set; }
        public double Discount { get; set; }


        public int MainLanguageId { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int OutstaffMatrixId { get; set; }
    }
}
