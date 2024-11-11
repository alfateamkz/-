using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums.LocalizationTexts;
using Alfateam.Website.API.Enums.LocalizationTexts.ClientCabinet;
using Alfateam.Website.API.Enums.LocalizationTexts.StaticPages;
using Alfateam.Website.API.Models;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Texts;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral;
using Alfateam2._0.Models.Localization.Texts.Common;
using Alfateam2._0.Models.Localization.Texts.HR;
using Alfateam2._0.Models.Localization.Texts.Invest;
using Alfateam2._0.Models.Localization.Texts.Portfolio;
using Alfateam2._0.Models.Localization.Texts.Shop;
using Alfateam2._0.Models.Localization.Texts.StaticPages;
using Alfateam2._0.Models.Localization.Texts.StaticPages.InnerLandings;
using Alfateam2._0.Models.Localization.Texts.Team;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Controllers.Admin.Localizations
{
    public class AdminInterfaceTextsStructureController : AbsAdminController
    {
        public AdminInterfaceTextsStructureController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetInterfaceTextsStructure")]
        public async Task<IEnumerable<AdminLocalizationPageStructureItem>> GetInterfaceTextsStructure(int languageId)
        {
            var items = new List<AdminLocalizationPageStructureItem>();

            SetStaticPagesGroup(items, languageId);
            SetClientCabinetPagesGroup(items, languageId);

            SetCommonPageItems(items, languageId);
            SetGeneralPageItems(items, languageId);
            SetHRPageItems(items, languageId);
            SetInvestPageItems(items, languageId);
            SetPortfolioPageItems(items, languageId);
            SetShopPageItems(items, languageId);
            SetTeamPageItems(items, languageId);

            return items;
        }







        #region ClientCabinet
        private void SetCCAuthItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Авторизация")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Код отправлен на почту", typeof(CCAuthCodeSentPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthCodeSentPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Восстановление пароля", typeof(CCAuthRestorePageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthRestorePageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Вход в аккаунт", typeof(CCAuthSignInPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthSignInPageTexts)
                    },
                     new AdminLocalizationPageStructureItem("Регистрация", typeof(CCAuthSignUpPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthSignUpPageTexts)
                    },
                }
            });
        }
        private void SetCCRefItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Реф. программа")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Страница счета", typeof(CCRefAccountPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefAccountPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Главная страница", typeof(CCRefMainPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefMainPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Мои счета", typeof(CCRefMyAccountsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefMyAccountsPageTexts)
                    },
                     new AdminLocalizationPageStructureItem("Вывод средств", typeof(CCRefWithdrawalPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefWithdrawalPageTexts)
                    },
                }
            });
        }
        private void SetClientCabinetItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Личный кабинет")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Информация", typeof(CCInfoPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCInfoPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Мои заказы", typeof(CCMyOrdersPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCMyOrdersPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Мои проекты", typeof(CCMyProjectsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCMyProjectsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Уведомления", typeof(CCNotificationsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCNotificationsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница заказа", typeof(CCOrderPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCOrderPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница проекта", typeof(CCProjectPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCProjectPageTexts)
                    },
                }
            });
        }


        private void SetClientCabinetPagesGroup(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            var item = new AdminLocalizationPageStructureItem("Личный кабинет");

            SetCCAuthItems(item.SubPages, languageId);
            SetCCRefItems(item.SubPages, languageId);
            SetClientCabinetItems(item.SubPages, languageId);

            items.Add(item);
        }

        #endregion

        #region StaticPages
        private void SetInnerLandingsItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Внутренние лендинги")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Качество и процесс работы", typeof(ILQualityAndPipelinePageTexts))
                    {
                        CommonMethodName = QueryStringBuider("InnerLandingsTexts", languageId, InnerLandingsTextsType.ILQualityAndPipelinePageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Реферальная программа", typeof(ILRefProgramPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("InnerLandingsTexts", languageId, InnerLandingsTextsType.ILRefProgramPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Работай с нами", typeof(ILWorkWithUsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("InnerLandingsTexts", languageId, InnerLandingsTextsType.ILWorkWithUsPageTexts)
                    },
                }
            });
        }
        private void SetStaticPagesItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Статические страницы")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("О нас", typeof(AboutUsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.AboutUsPageTexts),
                    },
                    new AdminLocalizationPageStructureItem("Корпоративная этика", typeof(CorporateCulturePageTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.CorporateCulturePageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Найти мой договор", typeof(FindMyAgreementPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.FindMyAgreementPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Противодействие мошенничеству", typeof(FraudCounteractionPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.FraudCounteractionPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Лендинг", typeof(LandingTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.LandingTexts)
                    },
                    new AdminLocalizationPageStructureItem("Политика конфедициальности", typeof(PrivacyPolicyPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.PrivacyPolicyPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Услуги", typeof(ServicesListPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.ServicesListPageTexts)
                    },
                }
            });
        }


        private void SetStaticPagesGroup(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            var item = new AdminLocalizationPageStructureItem("Статика");
           
            SetInnerLandingsItems(item.SubPages, languageId);
            SetStaticPagesItems(item.SubPages, languageId);

            items.Add(item);
        }

        #endregion

        private void SetCommonPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Общие текста")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Личный кабинет", typeof(ClientCabinetCommonTexts))
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.ClientCabinetCommonTexts)
                    },
                    new AdminLocalizationPageStructureItem("Футер", typeof(FooterTexts))
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.FooterTexts)
                    },
                    new AdminLocalizationPageStructureItem("Хедер", typeof(HeaderTexts))
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.HeaderTexts)
                    },
                    new AdminLocalizationPageStructureItem("Ссылки", typeof(LinksLocalization))
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.LinksLocalization)
                    },
                }
            });
        }
        private void SetGeneralPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Комплаенс", typeof(ComplianceTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.ComplianceTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Мероприятия", typeof(EventTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.EventTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("СМИ о нас", typeof(MassMediaAboutUsTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.MassMediaAboutUsTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Аутстафф", typeof(OutstaffPageTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.OutstaffPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Партнеры", typeof(PartnersPageTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.PartnersPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Новости", typeof(PostsPageTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.PostsPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Отзывы", typeof(ReviewsPageTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.ReviewsPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Услуги", typeof(ServicePageTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.ServicePageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Карта сайта", typeof(SitemapPageTexts))
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.SitemapPageTexts)
            });
        }
        private void SetHRPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("HR (вакансии)")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Список вакансий", typeof(HRJobVacanciesListPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("HRTexts", languageId, HRTextsType.HRJobVacanciesListPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница вакансии", typeof(HRJobVacancyPageText))
                    {
                        CommonMethodName = QueryStringBuider("HRTexts", languageId, HRTextsType.HRJobVacancyPageText)
                    },
                }
            });
        }
        private void SetInvestPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Инвест")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Страница инвест проекта", typeof(InvestProjectPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("InvestTexts", languageId, InvestTextsType.InvestProjectPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Список инвест проектов", typeof(InvestProjectsListPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("InvestTexts", languageId, InvestTextsType.InvestProjectsListPageTexts)
                    },
                }
            });
        }
        private void SetPortfolioPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Портфолио")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Страница проекта", typeof(PortfolioItemPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("PortfolioTexts", languageId, PortfolioTextsType.PortfolioItemPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Список проектов", typeof(PortfolioListPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("PortfolioTexts", languageId, PortfolioTextsType.PortfolioListPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Статистика просмотров проектов", typeof(PortfolioStatsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("PortfolioTexts", languageId, PortfolioTextsType.PortfolioStatsPageTexts)
                    },
                }
            });
        }
        private void SetShopPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Магазин")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Корзина", typeof(ShopBasketPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopBasketPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Адрес доставки", typeof(ShopDeliveryAddressPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopDeliveryAddressPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница продукта", typeof(ShopItemPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopItemPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Список продуктов", typeof(ShopItemsPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopItemsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница заказ не оплачен", typeof(ShopOrderNotPaidPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopOrderNotPaidPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница заказ оплачен", typeof(ShopOrderPaidSuccessfullyPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopOrderPaidSuccessfullyPageTexts)
                    },
                }
            });
        }
        private void SetTeamPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Команда")
            {
                SubPages = new List<AdminLocalizationPageStructureItem>
                {
                    new AdminLocalizationPageStructureItem("Страница члена команды", typeof(TeamMemberPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("TeamTexts", languageId, TeamTextsType.TeamMemberPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Члены команды", typeof(TeamPageTexts))
                    {
                        CommonMethodName = QueryStringBuider("TeamTexts", languageId, TeamTextsType.TeamPageTexts)
                    },
                }
            });
        }




        private string QueryStringBuider(string methodName, int languageId, Enum textType)
        {
            return $"{methodName}?languageId={languageId}&type={Convert.ToInt32(textType)}";
        }
    }
}
