using Alfateam.Marketing.Models.SalesGenerators.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.Items
{
    public class SGCreateOrderFromOldOrderDTO : DTOModelAbs<SGCreateOrderFromOldOrder>
    {
        public bool Create { get; set; }
        public int SetDaysAgo { get; set; }
    }
}
