using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Enums;

namespace Alfateam.Sales.API.Models.DTO.Invoices.RejectedInfo
{
    public class ByManagerInvoiceRejectedInfoDTO : InvoiceRejectedInfoDTO
    {
        [ForClientOnly]
        public UserDTO Manager { get; set; }


        public ByManagerInvoiceRejectedInfoType ReasonType { get; set; }
    }
}
