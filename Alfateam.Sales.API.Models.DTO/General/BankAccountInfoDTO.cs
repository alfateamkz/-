using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class BankAccountInfoDTO : DTOModelAbs<BankAccountInfo>
    {
        public string Title { get; set; }
        public string Bank { get; set; }
        public string AccountInfo { get; set; }
    }
}
