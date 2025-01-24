using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.StaticTextsConstructor
{
    public class TextCategoriesSearchFilter : SearchFilter
    {
        public int? ParentCategoryId { get; set; }
    }
}
