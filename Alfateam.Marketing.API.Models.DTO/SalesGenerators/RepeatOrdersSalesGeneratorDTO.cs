using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.SalesGenerators.Items;
using Alfateam.Marketing.Models.SalesGenerators.Items;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators
{
    public class RepeatOrdersSalesGeneratorDTO : SalesGeneratorDTO
    {
        public bool AlwaysSetResponsibleWhoWorkingNow { get; set; }
        public bool AlwaysCreateOrder { get; set; }
        public bool AssignOldManagerToCustomer { get; set; }
        public SGCreateOrderFromOldOrderDTO CreateOrderFromOldOrder { get; set; }


        public int? CRM_SalesFunnelId { get; set; }
    }
}
