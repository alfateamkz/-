using Alfateam.AdminPanelGeneral.API.Models;

namespace Alfateam.AdminPanelGeneral.API.Abstractions
{
    public abstract class AbsBlogController : AbsController
    {
        public AbsBlogController(ControllerParams @params) : base(@params)
        {
        }

        public int? BlogId => ParseIntValueFromHeader("BlogId");
        public int? BlogLanguageZoneId => ParseIntValueFromHeader("BlogLanguageZoneId");
    }
}
