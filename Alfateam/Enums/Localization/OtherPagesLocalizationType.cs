using System.ComponentModel;

namespace Alfateam.Enums.Localization
{
    public enum OtherPagesLocalizationType
    {
        [Description("Новости")]
        NewsPageLocalization = 1,
        [Description("Портфолио")]
        PortfolioPageLocalization = 2,
        [Description("Политика конфидециальности")]
        PrivacyPageLocalization = 3,
        [Description("Услуги")]
        ServicesPageLocalization = 4
    }
}
