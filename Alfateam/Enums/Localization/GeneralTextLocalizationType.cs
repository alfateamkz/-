using System.ComponentModel;

namespace Alfateam.Enums.Localization
{
    public enum GeneralTextLocalizationType
    {
        [Description("Калькулятор")]
        CalculatorLocalization = 1,
        [Description("Страницы ошибок и прочее")]
        ErrorPagesLocalization = 2,
        [Description("Главная страница")]
        MainPageLocalization = 3,
        [Description("Блок с картой")]
        MapBlockLocalization = 4,
        [Description("Общее")]
        SharedLocalization = 5
    }
}
