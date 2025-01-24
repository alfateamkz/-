using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters
{
    public class UserActionsSearchFilter : SearchFilter
    {
        public int? UserId { get; set; }
    }
}
