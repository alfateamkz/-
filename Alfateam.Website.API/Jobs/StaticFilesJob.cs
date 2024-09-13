using Alfateam.DB;
using Alfateam.Website.API.Helpers;
using Alfateam2._0.Models.Localization.Texts.Grouping;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Jobs
{
    public class StaticFilesJob
    {
        public async Task Start()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    using(WebsiteDBContext db = new WebsiteDBContext())
                    {
                        foreach (var language in db.Languages.Where(o => !o.IsDeleted))
                        {
                            var websiteLocalization = GetWebsiteLocalizationWithIncludes(db, language.Id);
                            StaticFilesHelper.CreateStaticLocalizationsFile(websiteLocalization);
                        }
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }
            });
        }



        #region GetWebsiteLocalizationWithIncludes

        private WebsiteLocalizationTexts GetWebsiteLocalizationWithIncludes(WebsiteDBContext db, int languageId)
        {
            var localization = db.WebsiteLocalizationTexts.Include(o => o.ComplianceTexts)
                                                          .Include(o => o.EventTexts)
                                                          .Include(o => o.MassMediaAboutUsTexts)
                                                          .Include(o => o.OutstaffPageTexts)
                                                          .Include(o => o.PartnersPageTexts)
                                                          .Include(o => o.PostsPageTexts)
                                                          .Include(o => o.ReviewsPageTexts)
                                                          .Include(o => o.ServicePageTexts)
                                                          .Include(o => o.SitemapPageTexts)
                                                          .FirstOrDefault(o => o.LanguageEntityId == languageId);

            IncludeCCWebsiteTexts(db, localization);
            IncludeStaticPagesTexts(db, localization);

            IncludeHRTexts(db, localization);
            IncludeInvestTexts(db, localization);
            IncludePortfolioTexts(db, localization);
            IncludeTeamTexts(db, localization);
            IncludeShopTexts(db, localization);

            IncludeCommonTexts(db, localization);


            return localization;
        }


        private void IncludeCCWebsiteTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.CCWebsiteLocalizationTexts = db.CCWebsiteLocalizationTexts.Include(o => o.CCAuthLocalizationTexts).ThenInclude(o => o.CCAuthCodeSentPageTexts)
                                                                            .Include(o => o.CCAuthLocalizationTexts).ThenInclude(o => o.CCAuthRestorePageTexts)
                                                                            .Include(o => o.CCAuthLocalizationTexts).ThenInclude(o => o.CCAuthSignInPageTexts)
                                                                            .Include(o => o.CCAuthLocalizationTexts).ThenInclude(o => o.CCAuthSignUpPageTexts)


                                                                            .Include(o => o.CCRefLocalizationTexts).ThenInclude(o => o.CCRefAccountPageTexts)
                                                                            .Include(o => o.CCRefLocalizationTexts).ThenInclude(o => o.CCRefMainPageTexts)
                                                                            .Include(o => o.CCRefLocalizationTexts).ThenInclude(o => o.CCRefMyAccountsPageTexts)
                                                                            .Include(o => o.CCRefLocalizationTexts).ThenInclude(o => o.CCRefWithdrawalPageTexts)

                                                                            .Include(o => o.CCInfoPageTexts)
                                                                            .Include(o => o.CCMyOrdersPageTexts)
                                                                            .Include(o => o.CCMyProjectsPageTexts)
                                                                            .Include(o => o.CCNotificationsPageTexts)
                                                                            .Include(o => o.CCOrderPageTexts)
                                                                            .Include(o => o.CCProjectPageTexts)
                                                                            .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);
        }
        private void IncludeStaticPagesTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.StaticPagesLocalizationTexts = db.StaticPagesLocalizationTexts.Include(o => o.InnerLandingsLocalizationTexts).ThenInclude(o => o.ILQualityAndPipelinePageTexts)
                                                                                .Include(o => o.InnerLandingsLocalizationTexts).ThenInclude(o => o.ILRefProgramPageTexts)
                                                                                .Include(o => o.InnerLandingsLocalizationTexts).ThenInclude(o => o.ILWorkWithUsPageTexts)
                                                                                .Include(o => o.AboutUsPageTexts)
                                                                                .Include(o => o.CorporateCulturePageTexts)
                                                                                .Include(o => o.FindMyAgreementPageTexts)
                                                                                .Include(o => o.FraudCounteractionPageTexts)
                                                                                .Include(o => o.LandingTexts)
                                                                                .Include(o => o.PrivacyPolicyPageTexts)
                                                                                .Include(o => o.ServicesListPageTexts)
                                                                                .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);
        }





        private void IncludeHRTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.HRLocalizationTexts = db.HRLocalizationTexts.Include(o => o.HRJobVacanciesListPageTexts)
                                                              .Include(o => o.HRJobVacancyPageText)
                                                              .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);
        }
        private void IncludeInvestTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.InvestLocalizationTexts = db.InvestLocalizationTexts.Include(o => o.InvestProjectPageTexts)
                                                                      .Include(o => o.InvestProjectsListPageTexts)
                                                                      .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);
        }
        private void IncludePortfolioTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.PortfolioLocalizationTexts = db.PortfolioLocalizationTexts.Include(o => o.PortfolioItemPageTexts)
                                                                            .Include(o => o.PortfolioListPageTexts)
                                                                            .Include(o => o.PortfolioStatsPageTexts)
                                                                            .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);
        }
        private void IncludeTeamTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.TeamLocalizationTexts = db.TeamLocalizationTexts.Include(o => o.TeamMemberPageTexts)
                                                                  .Include(o => o.TeamPageTexts)
                                                                  .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);
        }
        private void IncludeShopTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.ShopLocalizationTexts = db.ShopLocalizationTexts.Include(o => o.ShopBasketPageTexts)
                                                                  .Include(o => o.ShopDeliveryAddressPageTexts)
                                                                  .Include(o => o.ShopItemPageTexts)
                                                                  .Include(o => o.ShopItemsPageTexts)
                                                                  .Include(o => o.ShopOrderNotPaidPageTexts)
                                                                  .Include(o => o.ShopOrderPaidSuccessfullyPageTexts)
                                                                  .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);

        }

      



        private void IncludeCommonTexts(WebsiteDBContext db, WebsiteLocalizationTexts texts)
        {
            texts.CommonTexts = db.CommonTexts.Include(o => o.Header)
                                              .Include(o => o.Footer)
                                              .Include(o => o.Links)
                                              .Include(o => o.ClientCabinet)
                                              .FirstOrDefault(o => o.WebsiteLocalizationTextsId == texts.Id);

        }

        #endregion
    }
}
