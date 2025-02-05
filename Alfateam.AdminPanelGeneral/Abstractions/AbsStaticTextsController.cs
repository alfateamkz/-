using Alfateam.AdminPanelGeneral.API.Models;

namespace Alfateam.AdminPanelGeneral.API.Abstractions
{
    public abstract class AbsStaticTextsController : AbsController
    {
        public AbsStaticTextsController(ControllerParams @params) : base(@params)
        {
        }

        public int? TextsSetId => ParseIntValueFromHeader("TextsSetId");
        public int? TextsSetLanguageZoneId => ParseIntValueFromHeader("TextsSetLanguageZoneId");
    }
}
