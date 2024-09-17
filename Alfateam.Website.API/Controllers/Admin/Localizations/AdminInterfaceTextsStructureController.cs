using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums.LocalizationTexts;
using Alfateam.Website.API.Enums.LocalizationTexts.ClientCabinet;
using Alfateam.Website.API.Enums.LocalizationTexts.StaticPages;
using Alfateam.Website.API.Models;
using Alfateam2._0.Models.Abstractions;
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
                    new AdminLocalizationPageStructureItem("Код отправлен на почту")
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthCodeSentPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Восстановление пароля")
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthRestorePageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Вход в аккаунт")
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCAuthTextsType.CCAuthSignInPageTexts)
                    },
                     new AdminLocalizationPageStructureItem("Регистрация")
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
                    new AdminLocalizationPageStructureItem("Страница счета")
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefAccountPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Главная страница")
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefMainPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Мои счета")
                    {
                        CommonMethodName = QueryStringBuider("CCAuthTexts", languageId, CCRefTextsType.CCRefMyAccountsPageTexts)
                    },
                     new AdminLocalizationPageStructureItem("Вывод средств")
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
                    new AdminLocalizationPageStructureItem("Информация")
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCInfoPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Мои заказы")
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCMyOrdersPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Мои проекты")
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCMyProjectsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Уведомления")
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCNotificationsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница заказа")
                    {
                        CommonMethodName = QueryStringBuider("ClientCabinetTexts", languageId, ClientCabinetTextsType.CCOrderPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница проекта")
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
                    new AdminLocalizationPageStructureItem("Качество и процесс работы")
                    {
                        CommonMethodName = QueryStringBuider("InnerLandingsTexts", languageId, InnerLandingsTextsType.ILQualityAndPipelinePageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Реферальная программа")
                    {
                        CommonMethodName = QueryStringBuider("InnerLandingsTexts", languageId, InnerLandingsTextsType.ILRefProgramPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Работай с нами")
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
                    new AdminLocalizationPageStructureItem("О нас")
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.AboutUsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Корпоративная этика")
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.CorporateCulturePageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Найти мой договор")
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.FindMyAgreementPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Противодействие мошенничеству")
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.FraudCounteractionPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Лендинг")
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.LandingTexts)
                    },
                    new AdminLocalizationPageStructureItem("Политика конфедициальности")
                    {
                        CommonMethodName = QueryStringBuider("StaticPagesTexts", languageId, StaticPagesTextsType.PrivacyPolicyPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Услуги")
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
                    new AdminLocalizationPageStructureItem("Личный кабинет")
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.ClientCabinetCommonTexts)
                    },
                    new AdminLocalizationPageStructureItem("Футер")
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.FooterTexts)
                    },
                    new AdminLocalizationPageStructureItem("Хедер")
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.HeaderTexts)
                    },
                    new AdminLocalizationPageStructureItem("Ссылки")
                    {
                        CommonMethodName = QueryStringBuider("CommonTexts", languageId, CommonTextsType.LinksLocalization)
                    },
                }
            });
        }
        private void SetGeneralPageItems(List<AdminLocalizationPageStructureItem> items, int languageId)
        {
            items.Add(new AdminLocalizationPageStructureItem("Комплаенс")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.ComplianceTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Мероприятия")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.EventTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("СМИ о нас")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.MassMediaAboutUsTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Аутстафф")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.OutstaffPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Партнеры")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.PartnersPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Новости")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.PostsPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Отзывы")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.ReviewsPageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Услуги")
            {
                CommonMethodName = QueryStringBuider("GeneralTexts", languageId, GeneralTextsType.ServicePageTexts)
            });
            items.Add(new AdminLocalizationPageStructureItem("Карта сайта")
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
                    new AdminLocalizationPageStructureItem("Список вакансий")
                    {
                        CommonMethodName = QueryStringBuider("HRTexts", languageId, HRTextsType.HRJobVacanciesListPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница вакансии")
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
                    new AdminLocalizationPageStructureItem("Страница инвест проекта")
                    {
                        CommonMethodName = QueryStringBuider("InvestTexts", languageId, InvestTextsType.InvestProjectPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Список инвест проектов")
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
                    new AdminLocalizationPageStructureItem("Страница проекта")
                    {
                        CommonMethodName = QueryStringBuider("PortfolioTexts", languageId, PortfolioTextsType.PortfolioItemPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Список проектов")
                    {
                        CommonMethodName = QueryStringBuider("PortfolioTexts", languageId, PortfolioTextsType.PortfolioListPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Статистика просмотров проектов")
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
                    new AdminLocalizationPageStructureItem("Корзина")
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopBasketPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Адрес доставки")
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopDeliveryAddressPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница продукта")
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopItemPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Список продуктов")
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopItemsPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница заказ не оплачен")
                    {
                        CommonMethodName = QueryStringBuider("ShopTexts", languageId, ShopTextsType.ShopOrderNotPaidPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Страница заказ оплачен")
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
                    new AdminLocalizationPageStructureItem("Страница члена команды")
                    {
                        CommonMethodName = QueryStringBuider("TeamTexts", languageId, TeamTextsType.TeamMemberPageTexts)
                    },
                    new AdminLocalizationPageStructureItem("Члены команды")
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
