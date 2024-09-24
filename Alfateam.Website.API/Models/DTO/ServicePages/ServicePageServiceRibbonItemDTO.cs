using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.ServicePages;

namespace Alfateam.Website.API.Models.DTO.ServicePages
{
    public class ServicePageServiceRibbonItemDTO : DTOModel<ServicePageServiceRibbonItem>
    {
        public string Title { get; set; }

    }
}
