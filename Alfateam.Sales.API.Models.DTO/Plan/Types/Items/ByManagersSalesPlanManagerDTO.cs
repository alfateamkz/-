using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Plan.Types.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Plan.Types.Items
{
    public class ByManagersSalesPlanManagerDTO : DTOModelAbs<ByManagersSalesPlanManager>
    {
        [ForClientOnly]
        public UserDTO Manager { get; set; }
        [HiddenFromClient]
        public int ManagerId { get; set; }


        public double Value { get; set; }
    }
}
