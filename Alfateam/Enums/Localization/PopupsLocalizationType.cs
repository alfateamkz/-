using System.ComponentModel;

namespace Alfateam.Enums.Localization
{
    public enum PopupsLocalizationType
    {
        [Description("Заказ принят")]
        AcceptOrderPopupLocalization = 1,
        [Description("Звонок")]
        CallPopupLocalization = 2,
        [Description("Контакты")]
        ContactsPopupLocalization = 3,
        [Description("Карточка с портфолио")]
        PortfolioPopupLocalization = 4
    }
}
