using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.StaticTextsConstructor
{
    public class StaticTextsSearchFilter : SearchFilter
    {
        public int? ParentTextId { get; set; }
    }
}
