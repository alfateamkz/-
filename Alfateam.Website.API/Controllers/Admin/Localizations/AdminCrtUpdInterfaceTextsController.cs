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

namespace Alfateam.Website.API.Controllers.Admin.Localizations
{
    public class AdminCrtUpdInterfaceTextsController : AbsAdminController
    {
        public AdminCrtUpdInterfaceTextsController(ControllerParams @params) : base(@params)
        {
        }

        #region ClientCabinet

        [HttpPost, Route("CrtUpdCCAuthTexts")]
        public async Task<LocalizableModel> CrtUpdCCAuthTexts(int languageId, CCAuthTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case CCAuthTextsType.CCAuthCodeSentPageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthCodeSentPageTexts, languageId, (CCAuthCodeSentPageTexts)model);
                case CCAuthTextsType.CCAuthRestorePageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthRestorePageTexts, languageId, (CCAuthRestorePageTexts)model);
                case CCAuthTextsType.CCAuthSignInPageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthSignInPageTexts, languageId, (CCAuthSignInPageTexts)model);
                case CCAuthTextsType.CCAuthSignUpPageTexts:
                    return CreateOrUpdateLocalization(DB.CCAuthSignUpPageTexts, languageId, (CCAuthSignUpPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdCCRefTexts")]
        public async Task<LocalizableModel> CrtUpdCCRefTexts(int languageId, CCRefTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case CCRefTextsType.CCRefAccountPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefAccountPageTexts, languageId, (CCRefAccountPageTexts)model);
                case CCRefTextsType.CCRefMainPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefMainPageTexts, languageId, (CCRefMainPageTexts)model);
                case CCRefTextsType.CCRefMyAccountsPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefMyAccountsPageTexts, languageId, (CCRefMyAccountsPageTexts)model);
                case CCRefTextsType.CCRefWithdrawalPageTexts:
                    return CreateOrUpdateLocalization(DB.CCRefWithdrawalPageTexts, languageId, (CCRefWithdrawalPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdClientCabinetTexts")]
        public async Task<LocalizableModel> CrtUpdClientCabinetTexts(int languageId, ClientCabinetTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case ClientCabinetTextsType.CCInfoPageTexts:
                    return CreateOrUpdateLocalization(DB.CCInfoPageTexts, languageId, (CCInfoPageTexts)model);
                case ClientCabinetTextsType.CCMyOrdersPageTexts:
                    return CreateOrUpdateLocalization(DB.CCMyOrdersPageTexts, languageId, (CCMyOrdersPageTexts)model);
                case ClientCabinetTextsType.CCMyProjectsPageTexts:
                    return CreateOrUpdateLocalization(DB.CCMyProjectsPageTexts, languageId, (CCMyProjectsPageTexts)model);
                case ClientCabinetTextsType.CCNotificationsPageTexts:
                    return CreateOrUpdateLocalization(DB.CCNotificationsPageTexts, languageId, (CCNotificationsPageTexts)model);
                case ClientCabinetTextsType.CCOrderPageTexts:
                    return CreateOrUpdateLocalization(DB.CCOrderPageTexts, languageId, (CCOrderPageTexts)model);
                case ClientCabinetTextsType.CCProjectPageTexts:
                    return CreateOrUpdateLocalization(DB.CCProjectPageTexts, languageId, (CCProjectPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        #region StaticPages

        [HttpPost, Route("CrtUpdInnerLandingsTexts")]
        public async Task<LocalizableModel> CrtUpdInnerLandingsTexts(int languageId, InnerLandingsTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case InnerLandingsTextsType.ILQualityAndPipelinePageTexts:
                    return CreateOrUpdateLocalization(DB.ILQualityAndPipelinePageTexts, languageId, (ILQualityAndPipelinePageTexts)model);
                case InnerLandingsTextsType.ILRefProgramPageTexts:
                    return CreateOrUpdateLocalization(DB.ILRefProgramPageTexts, languageId, (ILRefProgramPageTexts)model);
                case InnerLandingsTextsType.ILWorkWithUsPageTexts:
                    return CreateOrUpdateLocalization(DB.ILWorkWithUsPageTexts, languageId, (ILWorkWithUsPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdStaticPagesTexts")]
        public async Task<LocalizableModel> CrtUpdStaticPagesTexts(int languageId, StaticPagesTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case StaticPagesTextsType.AboutUsPageTexts:
                    return CreateOrUpdateLocalization(DB.AboutUsPageTexts, languageId, (AboutUsPageTexts)model);
                case StaticPagesTextsType.CorporateCulturePageTexts:
                    return CreateOrUpdateLocalization(DB.CorporateCulturePageTexts, languageId, (CorporateCulturePageTexts)model);
                case StaticPagesTextsType.FindMyAgreementPageTexts:
                    return CreateOrUpdateLocalization(DB.FindMyAgreementPageTexts, languageId, (FindMyAgreementPageTexts)model);
                case StaticPagesTextsType.FraudCounteractionPageTexts:
                    return CreateOrUpdateLocalization(DB.FraudCounteractionPageTexts, languageId, (FraudCounteractionPageTexts)model);
                case StaticPagesTextsType.LandingTexts:
                    return CreateOrUpdateLocalization(DB.LandingTexts, languageId, (LandingTexts)model);
                case StaticPagesTextsType.PrivacyPolicyPageTexts:
                    return CreateOrUpdateLocalization(DB.PrivacyPolicyPageTexts, languageId, (PrivacyPolicyPageTexts)model);
                case StaticPagesTextsType.ServicesListPageTexts:
                    return CreateOrUpdateLocalization(DB.ServicesListPageTexts, languageId, (ServicesListPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion


        [HttpPost, Route("CrtUpdCommonTexts")]
        public async Task<LocalizableModel> CrtUpdCommonTexts(int languageId, CommonTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case CommonTextsType.ClientCabinetCommonTexts:
                    return CreateOrUpdateLocalization(DB.ClientCabinetCommonTexts, languageId, (ClientCabinetCommonTexts)model);
                case CommonTextsType.FooterTexts:
                    return CreateOrUpdateLocalization(DB.FooterTexts, languageId, (FooterTexts)model);
                case CommonTextsType.HeaderTexts:
                    return CreateOrUpdateLocalization(DB.HeaderTexts, languageId, (HeaderTexts)model);
                case CommonTextsType.LinksLocalization:
                    return CreateOrUpdateLocalization(DB.LinksLocalization, languageId, (LinksLocalization)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdGeneralTexts")]
        public async Task<LocalizableModel> CrtUpdGeneralTexts(int languageId, GeneralTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case GeneralTextsType.ComplianceTexts:
                    return CreateOrUpdateLocalization(DB.ComplianceTexts, languageId, (ComplianceTexts)model);
                case GeneralTextsType.EventTexts:
                    return CreateOrUpdateLocalization(DB.EventTexts, languageId, (EventTexts)model);
                case GeneralTextsType.MassMediaAboutUsTexts:
                    return CreateOrUpdateLocalization(DB.MassMediaAboutUsTexts, languageId, (MassMediaAboutUsTexts)model);
                case GeneralTextsType.OutstaffPageTexts:
                    return CreateOrUpdateLocalization(DB.OutstaffPageTexts, languageId, (OutstaffPageTexts)model);
                case GeneralTextsType.PartnersPageTexts:
                    return CreateOrUpdateLocalization(DB.PartnersPageTexts, languageId, (PartnersPageTexts)model);
                case GeneralTextsType.PostsPageTexts:
                    return CreateOrUpdateLocalization(DB.PostsPageTexts, languageId, (PostsPageTexts)model);
                case GeneralTextsType.ReviewsPageTexts:
                    return CreateOrUpdateLocalization(DB.ReviewsPageTexts, languageId, (ReviewsPageTexts)model);
                case GeneralTextsType.ServicePageTexts:
                    return CreateOrUpdateLocalization(DB.ServicePageTexts, languageId, (ServicePageTexts)model);
                case GeneralTextsType.SitemapPageTexts:
                    return CreateOrUpdateLocalization(DB.SitemapPageTexts, languageId, (SitemapPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdHRTexts")]
        public async Task<LocalizableModel> CrtUpdHRTexts(int languageId, HRTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case HRTextsType.HRJobVacanciesListPageTexts:
                    return CreateOrUpdateLocalization(DB.HRJobVacanciesListPageTexts, languageId, (HRJobVacanciesListPageTexts)model);
                case HRTextsType.HRJobVacancyPageText:
                    return CreateOrUpdateLocalization(DB.HRJobVacancyPageText, languageId, (HRJobVacancyPageText)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdInvestTexts")]
        public async Task<LocalizableModel> CrtUpdInvestTexts(int languageId, InvestTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case InvestTextsType.InvestProjectPageTexts:
                    return CreateOrUpdateLocalization(DB.InvestProjectPageTexts, languageId, (InvestProjectPageTexts)model);
                case InvestTextsType.InvestProjectsListPageTexts:
                    return CreateOrUpdateLocalization(DB.InvestProjectsListPageTexts, languageId, (InvestProjectsListPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdPortfolioTexts")]
        public async Task<LocalizableModel> CrtUpdPortfolioTexts(int languageId, PortfolioTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case PortfolioTextsType.PortfolioItemPageTexts:
                    return CreateOrUpdateLocalization(DB.PortfolioItemPageTexts, languageId, (PortfolioItemPageTexts)model);
                case PortfolioTextsType.PortfolioListPageTexts:
                    return CreateOrUpdateLocalization(DB.PortfolioListPageTexts, languageId, (PortfolioListPageTexts)model);
                case PortfolioTextsType.PortfolioStatsPageTexts:
                    return CreateOrUpdateLocalization(DB.PortfolioStatsPageTexts, languageId, (PortfolioStatsPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdShopTexts")]
        public async Task<LocalizableModel> CrtUpdShopTexts(int languageId, ShopTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case ShopTextsType.ShopBasketPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopBasketPageTexts, languageId, (ShopBasketPageTexts)model);
                case ShopTextsType.ShopDeliveryAddressPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopDeliveryAddressPageTexts, languageId, (ShopDeliveryAddressPageTexts)model);
                case ShopTextsType.ShopItemPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopItemPageTexts, languageId, (ShopItemPageTexts)model);
                case ShopTextsType.ShopItemsPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopItemsPageTexts, languageId, (ShopItemsPageTexts)model);
                case ShopTextsType.ShopOrderNotPaidPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopOrderNotPaidPageTexts, languageId, (ShopOrderNotPaidPageTexts)model);
                case ShopTextsType.ShopOrderPaidSuccessfullyPageTexts:
                    return CreateOrUpdateLocalization(DB.ShopOrderPaidSuccessfullyPageTexts, languageId, (ShopOrderPaidSuccessfullyPageTexts)model);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost, Route("CrtUpdTeamTexts")]
        public async Task<LocalizableModel> CrtUpdTeamTexts(int languageId, TeamTextsType type, LocalizableModel model)
        {
            switch (type)
            {
                case TeamTextsType.TeamMemberPageTexts:
                    return CreateOrUpdateLocalization(DB.TeamMemberPageTexts, languageId, (TeamMemberPageTexts)model);
                case TeamTextsType.TeamPageTexts:
                    return CreateOrUpdateLocalization(DB.TeamPageTexts, languageId, (TeamPageTexts)model);
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
    }
}
