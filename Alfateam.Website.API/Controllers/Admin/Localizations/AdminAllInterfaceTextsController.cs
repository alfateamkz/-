using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums.LocalizationTexts;
using Alfateam.Website.API.Enums.LocalizationTexts.ClientCabinet;
using Alfateam.Website.API.Enums.LocalizationTexts.StaticPages;
using Alfateam.Website.API.Models;
using Alfateam2._0.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin.Localizations
{
    public class AdminAllInterfaceTextsController : AbsAdminController
    {
        public AdminAllInterfaceTextsController(ControllerParams @params) : base(@params)
        {
        }

        #region ClientCabinet

        [HttpGet, Route("GetCCAuthTexts")]
        public async Task<LocalizableModel> GetCCAuthTexts(int languageId, CCAuthTextsType type)
        {
            switch (type)
            {
                case CCAuthTextsType.CCAuthCodeSentPageTexts:
                    return GetOrCreateLocalization(DB.CCAuthCodeSentPageTexts, languageId);
                case CCAuthTextsType.CCAuthRestorePageTexts:
                    return GetOrCreateLocalization(DB.CCAuthRestorePageTexts, languageId);
                case CCAuthTextsType.CCAuthSignInPageTexts:
                    return GetOrCreateLocalization(DB.CCAuthSignInPageTexts, languageId);
                case CCAuthTextsType.CCAuthSignUpPageTexts:
                    return GetOrCreateLocalization(DB.CCAuthSignUpPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("CCRefAuthTexts")]
        public async Task<LocalizableModel> CCRefAuthTexts(int languageId, CCRefTextsType type)
        {
            switch (type)
            {
                case CCRefTextsType.CCRefAccountPageTexts:
                    return GetOrCreateLocalization(DB.CCRefAccountPageTexts, languageId);
                case CCRefTextsType.CCRefMainPageTexts:
                    return GetOrCreateLocalization(DB.CCRefMainPageTexts, languageId);
                case CCRefTextsType.CCRefMyAccountsPageTexts:
                    return GetOrCreateLocalization(DB.CCRefMyAccountsPageTexts, languageId);
                case CCRefTextsType.CCRefWithdrawalPageTexts:
                    return GetOrCreateLocalization(DB.CCRefWithdrawalPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetClientCabinetTexts")]
        public async Task<LocalizableModel> GetClientCabinetTexts(int languageId, ClientCabinetTextsType type)
        {
            switch (type)
            {
                case ClientCabinetTextsType.CCInfoPageTexts:
                    return GetOrCreateLocalization(DB.CCInfoPageTexts, languageId);
                case ClientCabinetTextsType.CCMyOrdersPageTexts:
                    return GetOrCreateLocalization(DB.CCMyOrdersPageTexts, languageId);
                case ClientCabinetTextsType.CCMyProjectsPageTexts:
                    return GetOrCreateLocalization(DB.CCMyProjectsPageTexts, languageId);
                case ClientCabinetTextsType.CCNotificationsPageTexts:
                    return GetOrCreateLocalization(DB.CCNotificationsPageTexts, languageId);
                case ClientCabinetTextsType.CCOrderPageTexts:
                    return GetOrCreateLocalization(DB.CCOrderPageTexts, languageId);
                case ClientCabinetTextsType.CCProjectPageTexts:
                    return GetOrCreateLocalization(DB.CCProjectPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        #region StaticPages

        [HttpGet, Route("GetInnerLandingsTexts")]
        public async Task<LocalizableModel> GetInnerLandingsTexts(int languageId, InnerLandingsTextsType type)
        {
            switch (type)
            {
                case InnerLandingsTextsType.ILQualityAndPipelinePageTexts:
                    return GetOrCreateLocalization(DB.ILQualityAndPipelinePageTexts, languageId);
                case InnerLandingsTextsType.ILRefProgramPageTexts:
                    return GetOrCreateLocalization(DB.ILRefProgramPageTexts, languageId);
                case InnerLandingsTextsType.ILWorkWithUsPageTexts:
                    return GetOrCreateLocalization(DB.ILWorkWithUsPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetStaticPagesTexts")]
        public async Task<LocalizableModel> GetStaticPagesTexts(int languageId, StaticPagesTextsType type)
        {
            switch (type)
            {
                case StaticPagesTextsType.AboutUsPageTexts:
                    return GetOrCreateLocalization(DB.AboutUsPageTexts, languageId);
                case StaticPagesTextsType.CorporateCulturePageTexts:
                    return GetOrCreateLocalization(DB.CorporateCulturePageTexts, languageId);
                case StaticPagesTextsType.FindMyAgreementPageTexts:
                    return GetOrCreateLocalization(DB.FindMyAgreementPageTexts, languageId);
                case StaticPagesTextsType.FraudCounteractionPageTexts:
                    return GetOrCreateLocalization(DB.FraudCounteractionPageTexts, languageId);
                case StaticPagesTextsType.LandingTexts:
                    return GetOrCreateLocalization(DB.LandingTexts, languageId);
                case StaticPagesTextsType.PrivacyPolicyPageTexts:
                    return GetOrCreateLocalization(DB.PrivacyPolicyPageTexts, languageId);
                case StaticPagesTextsType.ServicesListPageTexts:
                    return GetOrCreateLocalization(DB.ServicesListPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }


        #endregion

        [HttpGet, Route("GetCommonTexts")]
        public async Task<LocalizableModel> GetCommonTexts(int languageId, CommonTextsType type)
        {
            switch (type)
            {
                case CommonTextsType.ClientCabinetCommonTexts:
                    return GetOrCreateLocalization(DB.ClientCabinetCommonTexts, languageId);
                case CommonTextsType.FooterTexts:
                    return GetOrCreateLocalization(DB.FooterTexts, languageId);
                case CommonTextsType.HeaderTexts:
                    return GetOrCreateLocalization(DB.HeaderTexts, languageId);
                case CommonTextsType.LinksLocalization:
                    return GetOrCreateLocalization(DB.LinksLocalization, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetGeneralTexts")]
        public async Task<LocalizableModel> GetGeneralTexts(int languageId, GeneralTextsType type)
        {
            switch (type)
            {
                case GeneralTextsType.ComplianceTexts:
                    return GetOrCreateLocalization(DB.ComplianceTexts, languageId);
                case GeneralTextsType.EventTexts:
                    return GetOrCreateLocalization(DB.EventTexts, languageId);
                case GeneralTextsType.MassMediaAboutUsTexts:
                    return GetOrCreateLocalization(DB.MassMediaAboutUsTexts, languageId);
                case GeneralTextsType.OutstaffPageTexts:
                    return GetOrCreateLocalization(DB.OutstaffPageTexts, languageId);
                case GeneralTextsType.PartnersPageTexts:
                    return GetOrCreateLocalization(DB.PartnersPageTexts, languageId);
                case GeneralTextsType.PostsPageTexts:
                    return GetOrCreateLocalization(DB.PostsPageTexts, languageId);
                case GeneralTextsType.ReviewsPageTexts:
                    return GetOrCreateLocalization(DB.ReviewsPageTexts, languageId);
                case GeneralTextsType.ServicePageTexts:
                    return GetOrCreateLocalization(DB.ServicePageTexts, languageId);
                case GeneralTextsType.SitemapPageTexts:
                    return GetOrCreateLocalization(DB.SitemapPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetHRTexts")]
        public async Task<LocalizableModel> GetHRTexts(int languageId, HRTextsType type)
        {
            switch (type)
            {
                case HRTextsType.HRJobVacanciesListPageTexts:
                    return GetOrCreateLocalization(DB.HRJobVacanciesListPageTexts, languageId);
                case HRTextsType.HRJobVacancyPageText:
                    return GetOrCreateLocalization(DB.HRJobVacancyPageText, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetInvestTexts")]
        public async Task<LocalizableModel> GetInvestTexts(int languageId, InvestTextsType type)
        {
            switch (type)
            {
                case InvestTextsType.InvestProjectPageTexts:
                    return GetOrCreateLocalization(DB.InvestProjectsListPageTexts, languageId);
                case InvestTextsType.InvestProjectsListPageTexts:
                    return GetOrCreateLocalization(DB.InvestProjectPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetPortfolioTexts")]
        public async Task<LocalizableModel> GetPortfolioTexts(int languageId, PortfolioTextsType type)
        {
            switch (type)
            {
                case PortfolioTextsType.PortfolioItemPageTexts:
                    return GetOrCreateLocalization(DB.PortfolioItemPageTexts, languageId);
                case PortfolioTextsType.PortfolioListPageTexts:
                    return GetOrCreateLocalization(DB.PortfolioListPageTexts, languageId);
                case PortfolioTextsType.PortfolioStatsPageTexts:
                    return GetOrCreateLocalization(DB.PortfolioStatsPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetShopTexts")]
        public async Task<LocalizableModel> GetShopTexts(int languageId, ShopTextsType type)
        {
            switch (type)
            {
                case ShopTextsType.ShopBasketPageTexts:
                    return GetOrCreateLocalization(DB.ShopBasketPageTexts, languageId);
                case ShopTextsType.ShopDeliveryAddressPageTexts:
                    return GetOrCreateLocalization(DB.ShopDeliveryAddressPageTexts, languageId);
                case ShopTextsType.ShopItemPageTexts:
                    return GetOrCreateLocalization(DB.ShopItemPageTexts, languageId);
                case ShopTextsType.ShopItemsPageTexts:
                    return GetOrCreateLocalization(DB.ShopItemsPageTexts, languageId);
                case ShopTextsType.ShopOrderNotPaidPageTexts:
                    return GetOrCreateLocalization(DB.ShopOrderNotPaidPageTexts, languageId);
                case ShopTextsType.ShopOrderPaidSuccessfullyPageTexts:
                    return GetOrCreateLocalization(DB.ShopOrderPaidSuccessfullyPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpGet, Route("GetTeamTexts")]
        public async Task<LocalizableModel> GetTeamTexts(int languageId, TeamTextsType type)
        {
            switch (type)
            {
                case TeamTextsType.TeamMemberPageTexts:
                    return GetOrCreateLocalization(DB.TeamMemberPageTexts, languageId);
                case TeamTextsType.TeamPageTexts:
                    return GetOrCreateLocalization(DB.TeamPageTexts, languageId);
                default:
                    throw new NotImplementedException();
            }
        }







        private T GetOrCreateLocalization<T>(DbSet<T> dbSet, int languageId) where T : LocalizableModel, new()
        {
            var localization = dbSet.FirstOrDefault(o => o.LanguageEntityId == languageId);
            if(localization == null)
            {
                localization = new T();
                localization.LanguageEntityId = languageId;

                dbSet.Add(localization);
                DB.SaveChanges();
            }

            return localization;
        }
    }
}
