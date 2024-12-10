using Alfateam.Marketing.Models;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using Alfateam.Marketing.Models.Abstractions.SEO;
using Alfateam.Marketing.Models.Ads;
using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Marketing.Models.Filters;
using Alfateam.Marketing.Models.Filters.Items;
using Alfateam.Marketing.Models.Filters.Items.Customers;
using Alfateam.Marketing.Models.Filters.Items.Leads;
using Alfateam.Marketing.Models.Filters.Items.Orders;
using Alfateam.Marketing.Models.General;
using Alfateam.Marketing.Models.General.SEO;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Alfateam.Marketing.Models.Integrations.API;
using Alfateam.Marketing.Models.Lettering.Items;
using Alfateam.Marketing.Models.Referral.Items;
using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Marketing.Models.SalesGenerators.Items;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;
using Alfateam.Marketing.Models.Segments;
using Alfateam.Marketing.Models.Templates;
using Alfateam.Marketing.Models.Websites;
using Alfateam.Marketing.Models.Websites.SEO;
using Alfateam.Marketing.Models.Websites.SEO.Reports.SitemapAudit;
using Alfateam.Marketing.Models.Websites.SEO.Reports.WebsiteSEOAudit;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser;
using Alfateam.Marketing.Models.Websites.SEO.SearchQueryParser.Results;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts.Props;
using Alfateam.Marketing.Models.Websites.Stats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class MarketingDbContext : DbContext
    {
        public MarketingDbContext()
        {
            Database.EnsureCreated();
        }
        public MarketingDbContext(DbContextOptions<MarketingDbContext> options)
        {
            Database.EnsureCreated();
        }

        #region Abstractions

        #region MailingAccounts
        public DbSet<MailingAccount> MailingAccounts { get; set; }

        #endregion

        #region SEO
        public DbSet<URLRule> URLRules { get; set; }

        #endregion

        public DbSet<AdsServiceAccount> AdsServiceAccounts { get; set; }
        public DbSet<AutopostingAccount> AutopostingAccounts { get; set; }
        public DbSet<ExternalInteraction> ExternalInteractions { get; set; }
        public DbSet<LetteringCampaign> LetteringCampaigns { get; set; }
        public DbSet<ReferralAccountTransaction> ReferralAccountTransactions { get; set; }
        public DbSet<ReferralProgram> ReferralPrograms { get; set; }
        public DbSet<SalesGenerator> SalesGenerators { get; set; }
        public DbSet<SalesGeneratorStartOptions> SalesGeneratorStartOptions { get; set; }

        #endregion

        #region Ads
        public DbSet<AdsTask> AdsTasks { get; set; }

        #endregion

        #region Autoposting
        public DbSet<ContentPlan> ContentPlans { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAttachment> PostAttachments { get; set; }

        #endregion

        #region Filters

        #region Items

        #region Customers
        public DbSet<CustomerSourceItem> CustomerSourceItems { get; set; }

        #endregion

        #region Leads

        public DbSet<LeadKanbanStatusItem> LeadKanbanStatusItems { get; set; }
        public DbSet<LeadSourceItem> LeadSourceItems { get; set; }
        public DbSet<LeadStatusItem> LeadStatusItems { get; set; }
        #endregion

        #region Orders
        public DbSet<OrderStatusItem> OrderStatusItems { get; set; }
        public DbSet<SalesFunnelItem> SalesFunnelItems { get; set; }
        public DbSet<SalesFunnelStageItem> SalesFunnelStageItems { get; set; }

        #endregion

        public DbSet<FilterContactTypeItem> FilterContactTypeItem { get; set; }

        #endregion

        public DbSet<CustomersFilter> CustomersFilters { get; set; }
        public DbSet<LeadsFilter> LeadsFilters { get; set; }
        #endregion

        #region General

        #region SEO

        #region UserAgents
        public DbSet<UserAgentCategory> UserAgentCategories { get; set; }
        public DbSet<UserAgentTemplate> UserAgentTemplates { get; set; }

        #endregion

        public DbSet<LanguageDictionary> LanguageDictionaries { get; set; }

        #endregion

        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCompany> BusinessCompanies { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfo { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Integrations

        #region API
        public DbSet<AlfateamAPIKey> AlfateamAPIKeys { get; set; }
        public DbSet<AlfateamAPIRequestEntry> AlfateamAPIRequestEntries { get; set; }

        #endregion

        #endregion

        #region Lettering

        #region Items
        public DbSet<LetteringSentResult> LetteringSentResults { get; set; }

        #endregion

        #endregion

        #region Referral

        #region Items

        public DbSet<MLMNetworkReferralProgramLevel> MLMNetworkReferralProgramLevels { get; set; }
        public DbSet<MultiLevelReferralProgramLevel> MultiLevelReferralProgramLevels { get; set; }

        #endregion

        #region Main
        public DbSet<ReferralAccount> ReferralAccounts { get; set; }
        public DbSet<ReferralBanInfo> ReferralBanInfo { get; set; }
        public DbSet<ReferralUser> ReferralUsers { get; set; }

        #endregion

        #endregion

        #region SalesGenerator

        #region Items
        public DbSet<SGCreateOrderFromOldOrder> SGCreateOrderFromOldOrders { get; set; }
        public DbSet<SGResponsibleCRMUserItem> SGResponsibleCRMUserItems { get; set; }

        #endregion

        #region StartOptions

        #region Items

        public DbSet<StartEveryDayDayItem> StartEveryDayDayItems { get; set; }
        public DbSet<StartEveryDayDayOfWeekItem> StartEveryDayDayOfWeekItems { get; set; }
        public DbSet<StartEveryDayMonthItem> StartEveryDayMonthItems { get; set; }

        #endregion

        #endregion


        #endregion

        #region Segments
        public DbSet<Segment> Segments { get; set; }

        #endregion

        #region Templates
        public DbSet<Template> Templates { get; set; }

        #endregion

        #region Websites

        #region SEO

        #region Reports

        #region SitemapAudit
        public DbSet<SitemapAuditReport> SitemapAuditReports { get; set; }
        public DbSet<SitemapAuditReportError> SitemapAuditReportErrors { get; set; }

        #endregion

        #region WebsiteSEOAudit
        public DbSet<WebsiteSEOAuditReport> WebsiteSEOAuditReports { get; set; }
        public DbSet<WebsiteSEOAuditSkippedURL> WebsiteSEOAuditSkippedURLs { get; set; }
        public DbSet<WebsiteSEOAuditURL> WebsiteSEOAuditURLs { get; set; }
        public DbSet<WebsiteSEOAuditURLError> WebsiteSEOAuditURLErrors { get; set; }
        public DbSet<WebsiteSEOAuditURLResponse> WebsiteSEOAuditURLResponses { get; set; }

        #endregion


        #endregion

        #region SearchQueryParser

        #region Results
        public DbSet<SearchQueryParserResult> SearchQueryParserResults { get; set; }
        public DbSet<SearchQueryParserResultByEngine> SearchQueryParserResultByEngines { get; set; }
        public DbSet<SearchQueryParserResultPosition> SearchQueryParserResultPositions { get; set; }

        #endregion

        public DbSet<SearchQueryParserEngine> SearchQueryParserEngines { get; set; }
        public DbSet<SearchQueryParserQuery> SearchQueryParserQueries { get; set; }
        public DbSet<SearchQueryParserReport> SearchQueryParserReports { get; set; }

        #endregion

        #region SettingsItems

        public DbSet<AdvancedScanSettings> AdvancedScanSettings { get; set; }
        public DbSet<CommonScanSettings> CommonScanSettings { get; set; }
        public DbSet<HTTPHeader> HTTPHeaders { get; set; }
        public DbSet<OrthographySettings> OrthographySettings { get; set; }
        public DbSet<Proxy> Proxies { get; set; }
        public DbSet<RestrictionsSettings> RestrictionsSettings { get; set; }
        public DbSet<URLRules> SEOURLRules { get; set; }
        public DbSet<UserAgentSettings> UserAgentSettings { get; set; }
        public DbSet<VirtualRobotsTxt> VirtualRobotsTxts { get; set; }
        public DbSet<WebsiteBaseAuthentication> WebsiteBaseAuthenticationss { get; set; }

        #endregion

        #region SiteInfoParser

        #region Parts

        #region Props

        public DbSet<SchemaMarkupValidatorMicromarkupItem> SchemaMarkupValidatorMicromarkupItems { get; set; }

        #endregion

        public DbSet<SiteInfoParserBingSERP> SiteInfoParserBingSERPs { get; set; }
        public DbSet<SiteInfoParserDNS> SiteInfoParserDNSs { get; set; }
        public DbSet<SiteInfoParserGoogleSERP> SiteInfoParserGoogleSERPs { get; set; }
        public DbSet<SiteInfoParserSchemaMarkupValidator> SiteInfoParserSchemaMarkupValidators { get; set; }
        public DbSet<SiteInfoParserTraffic> SiteInfoParserTraffics { get; set; }
        public DbSet<SiteInfoParserWaybackMachine> SiteInfoParserWaybackMachines { get; set; }
        public DbSet<SiteInfoParserWhois> SiteInfoParserWhois { get; set; }
        public DbSet<SiteInfoParserYahooSERP> SiteInfoParserYahooSERPs { get; set; }

        #endregion

        public DbSet<SiteInfoParserFoundLink> SiteInfoParserFoundLinks { get; set; }
        public DbSet<SiteInfoParserReport> SiteInfoParserReports { get; set; }
        public DbSet<SiteInfoParserURLResponse> SiteInfoParserURLResponses { get; set; }

        #endregion

        public DbSet<SEOToolSettings> SEOToolSettings { get; set; }

        #endregion

        #region Stats
        public DbSet<WebsiteOnlineInfo> WebsiteOnlineInfo { get; set; }

        #endregion

        public DbSet<Alfateam.Marketing.Models.Websites.Website> Websites { get; set; }
        public DbSet<WebsiteGroup> WebsiteGroups { get; set; }

        #endregion

        public DbSet<BlacklistItem> BlacklistItems { get; set; }
        public DbSet<MarketingContact> MarketingContacts { get; set; }
    }

}
