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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alfateam.Website.API.Controllers.Admin.Localizations
{
    public class AdminCrtUpdInterfaceTextsController : AbsAdminController
    {
        public AdminCrtUpdInterfaceTextsController(ControllerParams @params) : base(@params)
        {
        }

        #region ClientCabinet

        [HttpPost, Route("CrtUpdCCAuthTexts")]
        public async Task<LocalizableModel> CrtUpdCCAuthTexts(int languageId, CCAuthTextsType type, JObject body)
        {
            switch (type)
            {
                case CCAuthTextsType.CCAuthCodeSentPageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthCodeSentPageTexts, languageId, CreateLocalizationObjectFromJson<CCAuthCodeSentPageTexts>(body));
                case CCAuthTextsType.CCAuthRestorePageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthRestorePageTexts, languageId, CreateLocalizationObjectFromJson<CCAuthRestorePageTexts>(body));
                case CCAuthTextsType.CCAuthSignInPageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthSignInPageTexts, languageId, CreateLocalizationObjectFromJson<CCAuthSignInPageTexts>(body));
                case CCAuthTextsType.CCAuthSignUpPageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthSignUpPageTexts, languageId, CreateLocalizationObjectFromJson<CCAuthSignUpPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdCCRefTexts")]
        public async Task<LocalizableModel> CrtUpdCCRefTexts(int languageId, CCRefTextsType type, JObject body)
        {
            switch (type)
            {
                case CCRefTextsType.CCRefAccountPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefAccountPageTexts, languageId, CreateLocalizationObjectFromJson<CCRefAccountPageTexts>(body));
                case CCRefTextsType.CCRefMainPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefMainPageTexts, languageId, CreateLocalizationObjectFromJson<CCRefMainPageTexts>(body));
                case CCRefTextsType.CCRefMyAccountsPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefMyAccountsPageTexts, languageId, CreateLocalizationObjectFromJson<CCRefMyAccountsPageTexts>(body));
                case CCRefTextsType.CCRefWithdrawalPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefWithdrawalPageTexts, languageId, CreateLocalizationObjectFromJson<CCRefWithdrawalPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdClientCabinetTexts")]
        public async Task<LocalizableModel> CrtUpdClientCabinetTexts(int languageId, ClientCabinetTextsType type, JObject body)
        {
            switch (type)
            {
                case ClientCabinetTextsType.CCInfoPageTexts:
                    return CreateOrUpdateLocalization(DB.CCInfoPageTexts, languageId, CreateLocalizationObjectFromJson<CCInfoPageTexts>(body));
                case ClientCabinetTextsType.CCMyOrdersPageTexts:
                    return CreateOrUpdateLocalization(DB.CCMyOrdersPageTexts, languageId, CreateLocalizationObjectFromJson<CCMyOrdersPageTexts>(body));
                case ClientCabinetTextsType.CCMyProjectsPageTexts:
                    return CreateOrUpdateLocalization(DB.CCMyProjectsPageTexts, languageId, CreateLocalizationObjectFromJson<CCMyProjectsPageTexts>(body));
                case ClientCabinetTextsType.CCNotificationsPageTexts:
                    return CreateOrUpdateLocalization(DB.CCNotificationsPageTexts, languageId, CreateLocalizationObjectFromJson<CCNotificationsPageTexts>(body));
                case ClientCabinetTextsType.CCOrderPageTexts:
                    return CreateOrUpdateLocalization(DB.CCOrderPageTexts, languageId, CreateLocalizationObjectFromJson<CCOrderPageTexts>(body));
                case ClientCabinetTextsType.CCProjectPageTexts:
                    return CreateOrUpdateLocalization(DB.CCProjectPageTexts, languageId, CreateLocalizationObjectFromJson<CCProjectPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        #region StaticPages

        [HttpPost, Route("CrtUpdInnerLandingsTexts")]
        public async Task<LocalizableModel> CrtUpdInnerLandingsTexts(int languageId, InnerLandingsTextsType type, JObject body)
        {
            switch (type)
            {
                case InnerLandingsTextsType.ILQualityAndPipelinePageTexts:
                    return CreateOrUpdateLocalization(DB.ILQualityAndPipelinePageTexts, languageId, CreateLocalizationObjectFromJson<ILQualityAndPipelinePageTexts>(body));
                case InnerLandingsTextsType.ILRefProgramPageTexts:
                    return CreateOrUpdateLocalization(DB.ILRefProgramPageTexts, languageId, CreateLocalizationObjectFromJson<ILRefProgramPageTexts>(body));
                case InnerLandingsTextsType.ILWorkWithUsPageTexts:
                    return CreateOrUpdateLocalization(DB.ILWorkWithUsPageTexts, languageId, CreateLocalizationObjectFromJson<ILWorkWithUsPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdStaticPagesTexts")]
        public async Task<LocalizableModel> CrtUpdStaticPagesTexts(int languageId, StaticPagesTextsType type, JObject body)
        {
            switch (type)
            {
                case StaticPagesTextsType.AboutUsPageTexts:
                    return CreateOrUpdateLocalization(DB.AboutUsPageTexts, languageId, CreateLocalizationObjectFromJson<AboutUsPageTexts>(body));
                case StaticPagesTextsType.CorporateCulturePageTexts:
                    return CreateOrUpdateLocalization(DB.CorporateCulturePageTexts, languageId, CreateLocalizationObjectFromJson<CorporateCulturePageTexts>(body));
                case StaticPagesTextsType.FindMyAgreementPageTexts:
                    return CreateOrUpdateLocalization(DB.FindMyAgreementPageTexts, languageId, CreateLocalizationObjectFromJson<FindMyAgreementPageTexts>(body));
                case StaticPagesTextsType.FraudCounteractionPageTexts:
                    return CreateOrUpdateLocalization(DB.FraudCounteractionPageTexts, languageId, CreateLocalizationObjectFromJson<FraudCounteractionPageTexts>(body));
                case StaticPagesTextsType.LandingTexts:
                    return CreateOrUpdateLocalization(DB.LandingTexts, languageId, CreateLocalizationObjectFromJson<LandingTexts>(body));
                case StaticPagesTextsType.PrivacyPolicyPageTexts:
                    return CreateOrUpdateLocalization(DB.PrivacyPolicyPageTexts, languageId, CreateLocalizationObjectFromJson<PrivacyPolicyPageTexts>(body));
                case StaticPagesTextsType.ServicesListPageTexts:
                    return CreateOrUpdateLocalization(DB.ServicesListPageTexts, languageId,  CreateLocalizationObjectFromJson<ServicesListPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion


        [HttpPost, Route("CrtUpdCommonTexts")]
        public async Task<LocalizableModel> CrtUpdCommonTexts(int languageId, CommonTextsType type, JObject body)
        {
            switch (type)
            {
                case CommonTextsType.ClientCabinetCommonTexts:
                    return CreateOrUpdateLocalization(DB.ClientCabinetCommonTexts, languageId, CreateLocalizationObjectFromJson<ClientCabinetCommonTexts>(body));
                case CommonTextsType.FooterTexts:
                    return CreateOrUpdateLocalization(DB.FooterTexts, languageId, CreateLocalizationObjectFromJson<FooterTexts>(body));
                case CommonTextsType.HeaderTexts:
                    return CreateOrUpdateLocalization(DB.HeaderTexts, languageId, CreateLocalizationObjectFromJson<HeaderTexts>(body));
                case CommonTextsType.LinksLocalization:
                    return CreateOrUpdateLocalization(DB.LinksLocalization, languageId, CreateLocalizationObjectFromJson<LinksLocalization>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdGeneralTexts")]
        public async Task<LocalizableModel> CrtUpdGeneralTexts(int languageId, GeneralTextsType type, JObject body)
        {
            switch (type)
            {
                case GeneralTextsType.ComplianceTexts:
                    return CreateOrUpdateLocalization(DB.ComplianceTexts, languageId, CreateLocalizationObjectFromJson<ComplianceTexts>(body));
                case GeneralTextsType.EventTexts:
                    return CreateOrUpdateLocalization(DB.EventTexts, languageId, CreateLocalizationObjectFromJson<EventTexts>(body));
                case GeneralTextsType.MassMediaAboutUsTexts:
                    return CreateOrUpdateLocalization(DB.MassMediaAboutUsTexts, languageId, CreateLocalizationObjectFromJson<MassMediaAboutUsTexts>(body));
                case GeneralTextsType.OutstaffPageTexts:
                    return CreateOrUpdateLocalization(DB.OutstaffPageTexts, languageId, CreateLocalizationObjectFromJson<OutstaffPageTexts>(body));
                case GeneralTextsType.PartnersPageTexts:
                    return CreateOrUpdateLocalization(DB.PartnersPageTexts, languageId, CreateLocalizationObjectFromJson<PartnersPageTexts>(body));
                case GeneralTextsType.PostsPageTexts:
                    return CreateOrUpdateLocalization(DB.PostsPageTexts, languageId, CreateLocalizationObjectFromJson<PostsPageTexts>(body));
                case GeneralTextsType.ReviewsPageTexts:
                    return CreateOrUpdateLocalization(DB.ReviewsPageTexts, languageId, CreateLocalizationObjectFromJson<ReviewsPageTexts>(body));
                case GeneralTextsType.ServicePageTexts:
                    return CreateOrUpdateLocalization(DB.ServicePageTexts, languageId, CreateLocalizationObjectFromJson<ServicePageTexts>(body));
                case GeneralTextsType.SitemapPageTexts:
                    return CreateOrUpdateLocalization(DB.SitemapPageTexts, languageId, CreateLocalizationObjectFromJson<SitemapPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdHRTexts")]
        public async Task<LocalizableModel> CrtUpdHRTexts(int languageId, HRTextsType type, JObject body)
        {
            switch (type)
            {
                case HRTextsType.HRJobVacanciesListPageTexts:
                    return CreateOrUpdateLocalization(DB.HRJobVacanciesListPageTexts, languageId, CreateLocalizationObjectFromJson<HRJobVacanciesListPageTexts>(body));
                case HRTextsType.HRJobVacancyPageText:
                    return CreateOrUpdateLocalization(DB.HRJobVacancyPageText, languageId, CreateLocalizationObjectFromJson<HRJobVacancyPageText>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdInvestTexts")]
        public async Task<LocalizableModel> CrtUpdInvestTexts(int languageId, InvestTextsType type, JObject body)
        {
            switch (type)
            {
                case InvestTextsType.InvestProjectPageTexts:
                    return CreateOrUpdateLocalization(DB.InvestProjectPageTexts, languageId, CreateLocalizationObjectFromJson<InvestProjectPageTexts>(body));
                case InvestTextsType.InvestProjectsListPageTexts:
                    return CreateOrUpdateLocalization(DB.InvestProjectsListPageTexts, languageId, CreateLocalizationObjectFromJson<InvestProjectsListPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdPortfolioTexts")]
        public async Task<LocalizableModel> CrtUpdPortfolioTexts(int languageId, PortfolioTextsType type, JObject body)
        {
            switch (type)
            {
                case PortfolioTextsType.PortfolioItemPageTexts:
                    return CreateOrUpdateLocalization(DB.PortfolioItemPageTexts, languageId, CreateLocalizationObjectFromJson<PortfolioItemPageTexts>(body));
                case PortfolioTextsType.PortfolioListPageTexts:
                    return CreateOrUpdateLocalization(DB.PortfolioListPageTexts, languageId, CreateLocalizationObjectFromJson<PortfolioListPageTexts>(body));
                case PortfolioTextsType.PortfolioStatsPageTexts:
                    return CreateOrUpdateLocalization(DB.PortfolioStatsPageTexts, languageId, CreateLocalizationObjectFromJson<PortfolioStatsPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdShopTexts")]
        public async Task<LocalizableModel> CrtUpdShopTexts(int languageId, ShopTextsType type, JObject body)
        {
            switch (type)
            {
                case ShopTextsType.ShopBasketPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopBasketPageTexts, languageId, CreateLocalizationObjectFromJson<ShopBasketPageTexts>(body));
                case ShopTextsType.ShopDeliveryAddressPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopDeliveryAddressPageTexts, languageId, CreateLocalizationObjectFromJson<ShopDeliveryAddressPageTexts>(body));
                case ShopTextsType.ShopItemPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopItemPageTexts, languageId, CreateLocalizationObjectFromJson<ShopItemPageTexts>(body));
                case ShopTextsType.ShopItemsPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopItemsPageTexts, languageId, CreateLocalizationObjectFromJson<ShopItemsPageTexts>(body));
                case ShopTextsType.ShopOrderNotPaidPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopOrderNotPaidPageTexts, languageId, CreateLocalizationObjectFromJson<ShopOrderNotPaidPageTexts>(body));
                case ShopTextsType.ShopOrderPaidSuccessfullyPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopOrderPaidSuccessfullyPageTexts, languageId, CreateLocalizationObjectFromJson<ShopOrderPaidSuccessfullyPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdTeamTexts")]
        public async Task<LocalizableModel> CrtUpdTeamTexts(int languageId, TeamTextsType type, JObject body)
        {
            switch (type)
            {
                case TeamTextsType.TeamMemberPageTexts:
                    return CreateOrUpdateLocalization(DB.TeamMemberPageTexts, languageId, CreateLocalizationObjectFromJson<TeamMemberPageTexts>(body));
                case TeamTextsType.TeamPageTexts:
                    return CreateOrUpdateLocalization(DB.TeamPageTexts, languageId, CreateLocalizationObjectFromJson<TeamPageTexts>(body));
                default:
                    throw new NotImplementedException();
            }
        }










        private T CreateOrUpdateLocalization<T>(DbSet<T> dbSet, int languageId, T item) where T : LocalizableModel, new()
        {
            item.LanguageEntityId = languageId;
            dbSet.Update(item);
            DB.SaveChanges();

            return item;
        }

        private T CreateLocalizationObjectFromJson<T>(JObject objectFromJson) where T : LocalizableModel, new()
        {
            var model = new T();

            var values = objectFromJson.Values().ToList();
            foreach (var modelProp in model.GetType().GetProperties().Where(o => o.CanWrite))
            {
                JToken jsonProp = values.FirstOrDefault(o => o.Path == modelProp.Name);
                if(jsonProp != null)
                {
                    modelProp.SetValue(model, jsonProp.ToObject(modelProp.PropertyType));
                }
                else
                {
                    if(modelProp.PropertyType == typeof(string))
                    {
                        modelProp.SetValue(model, "");
                    }
                    else
                    {
                        modelProp.SetValue(model, default);
                    }  
                }
            }

            return model;
        }
    }
}
