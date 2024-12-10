using Alfateam.Marketing.Models.SalesGenerators.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.Items
{
    public class SGResponsibleCRMUserItemDTO : DTOModelAbs<SGResponsibleCRMUserItem>
    {
        public int CRM_UserId { get; set; }
        public int Order { get; set; }
    }
}
