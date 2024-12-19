using Alfateam.DB.Helpers;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using Alfateam.Sales.Models.Conversation;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.Models.ExternalInteractions;
using Alfateam.Sales.Models.ExternalInteractions.Inputs;
using Alfateam.Sales.Models.ExternalInteractions.SentForms;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields.Props;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.General.AcquiringSettings.Countries.Kazakhstan;
using Alfateam.Sales.Models.General.AcquiringSettings.Countries.Mongolia;
using Alfateam.Sales.Models.General.AcquiringSettings.Countries.Russia;
using Alfateam.Sales.Models.General.AcquiringSettings.Crypto;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Sales.Models.Integrations.API;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Sales.Models.Invoices.Placeholders;
using Alfateam.Sales.Models.Invoices.RejectedInfo;
using Alfateam.Sales.Models.Leads;
using Alfateam.Sales.Models.Leads.Kanban;
using Alfateam.Sales.Models.Orders;
using Alfateam.Sales.Models.Plan;
using Alfateam.Sales.Models.Plan.Types;
using Alfateam.Sales.Models.Plan.Types.Items;
using Alfateam.Sales.Models.Scripting;
using Alfateam.Sales.Models.Tasks;
using Alfateam.Sales.Models.Tasks.AsCompleted;
using Alfateam.Sales.Models.Tasks.CompletionCheck;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
            Database.EnsureCreated();
        }
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
        {
            Database.EnsureCreated();
        }


        #region Abstractions

        #region ExtInterations

        public DbSet<ExternalInteraction> ExternalInteractions { get; set; }
        public DbSet<SentWebsiteFormField> SentWebsiteFormFields { get; set; }
        public DbSet<WebsiteFormInput> WebsiteFormInputs { get; set; }
        #endregion

        #region Tasks
        public DbSet<MarkedAsCompleted> MarkedAsCompleted { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        #endregion

        public DbSet<BPTemplatePlaceholder> BPTemplatePlaceholders { get; set; }
        public DbSet<CompanyAcquiringSettings> CompanyAcquiringSettings { get; set; }
        public DbSet<CustomerConversation> CustomerConversations { get; set; }
        public DbSet<InvoicePaidInfo> InvoicePaidInfos { get; set; }
        public DbSet<InvoiceRejectedInfo> InvoiceRejectedInfos { get; set; }
        public DbSet<InvoiceTemplatePlaceholder> InvoiceTemplatePlaceholders { get; set; }
        public DbSet<SalesPlan> SalesPlans { get; set; }

        #endregion

        #region BusinessProposals

        #region Kanban
        public DbSet<BusinessProposalsKanbanData> BusinessProposalsKanbanData { get; set; }
        public DbSet<BusinessProposalsKanban> BusinessProposalsKanbans { get; set; }
        public DbSet<BusinessProposalsKanbanStage> BusinessProposalsKanbanStages { get; set; }

        #endregion

        public DbSet<BusinessProposal> BusinessProposals { get; set; }
        public DbSet<BusinessProposalTemplate> BusinessProposalTemplates { get; set; }
        #endregion

        #region Conversation
        public DbSet<CustomerMeetingAttachment> CustomerMeetingAttachments { get; set; }

        #endregion

        #region Customers

        #region Categories
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<PersonContactCategory> PersonContactCategories { get; set; }

        #endregion

        #region Other
        public DbSet<CompanyDetails> CompanyDetails { get; set; }
        public DbSet<CompanyFieldOfActivity> CompanyFieldsOfActivity { get; set; }

        #endregion

        public DbSet<Company> Companies { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
     
        #endregion

        #region ExternalInteractions

        #region SentForms

        #region CommunitationButtons
        public DbSet<CommunitationButtonsAction> CommunitationButtonsActions { get; set; }
        public DbSet<CommunitationButtonsActionsSession> CommunitationButtonsActionsSessions { get; set; }
        #endregion

        #region Fields

        #region Props
        public DbSet<FilesSentFormFieldFile> FilesSentFormFieldFiles { get; set; }
        #endregion

        #endregion

        public DbSet<SentWebsiteForm> SentWebsiteForms { get; set; }

        #endregion

        #endregion

        #region Funnel
        public DbSet<SalesFunnel> SalesFunnels { get; set; }
        public DbSet<SalesFunnelStage> SalesFunnelStages { get; set; }
        public DbSet<SalesFunnelTunnel> SalesFunnelTunnels { get; set; }

        #endregion

        #region General

        #region Security
        public DbSet<UserPermissions> UserPermissions { get; set; }
        public DbSet<HistoryAction> HistoryActions { get; set; }

        #endregion

        public DbSet<BankAccountInfo> BankAccountInfos { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCompany> BusinessCompanies { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyAndValue> CurrencyAndValues { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SalesKPI> SalesKPIs { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UTMMark> UTMMarks { get; set; }

        #endregion

        #region Integrations

        #region API
        public DbSet<AlfateamAPIKey> AlfateamAPIKeys { get; set; }
        public DbSet<AlfateamAPIRequestEntry> AlfateamAPIRequestEntries { get; set; }

        #endregion

        #endregion

        #region Invoices

        #region Kanban
        public DbSet<InvoiceKanbanData> InvoiceKanbanData { get; set; }
        public DbSet<InvoicesKanban> InvoicesKanbans { get; set; }
        public DbSet<InvoicesKanbanStage> InvoicesKanbanStages { get; set; }

        #endregion

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<InvoiceTemplate> InvoiceTemplates { get; set; }

        #endregion

        #region Leads

        #region Kanban

        public DbSet<LeadsKanban> LeadsKanbans { get; set; }
        public DbSet<LeadsKanbanData> LeadsKanbanData { get; set; }
        public DbSet<LeadsKanbanStage> LeadsKanbanStages { get; set; }

        #endregion

        public DbSet<Lead> Leads { get; set; }

        #endregion

        #region Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSaleInfo> OrderSaleInfos { get; set; }

        #endregion

        #region Plan

        #region Types

        #region Items

        public DbSet<ByFunnelsSalesPlanFunnel> ByFunnelsSalesPlanFunnels { get; set; }
        public DbSet<ByManagersSalesPlanManager> ByManagersSalesPlanManagers { get; set; }
        #endregion

        #endregion

        public DbSet<SalesPlanning> SalesPlannings { get; set; }

        #endregion

        #region Scripting
        public DbSet<SalesScript> SalesScripts { get; set; }
        public DbSet<SalesScriptBlock> SalesScriptBlocks { get; set; }

        #endregion

        #region Tasks

        #region CompletionCheck
        public DbSet<TaskCompletionCheckResult> TaskCompletionCheckResults { get; set; }

        #endregion

        #endregion







        #region Initial methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.BuildConnectionString("alfateam_crm_sales"), new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            MakeAbstractExternalInteractionModelsHierarchy(modelBuilder);
            MakeAbstractTasksModelsHierarchy(modelBuilder);

            MakeAbstractModelsHierarchy(modelBuilder);


            //Туннели продаж
            modelBuilder.Entity<SalesFunnelStage>().HasOne(o => o.Tunnel).WithOne(o => o.FromFunnelStage);
            modelBuilder.Entity<SalesFunnelTunnel>().HasOne(o => o.ToFunnelStage);
        }


        protected void MakeAbstractExternalInteractionModelsHierarchy(ModelBuilder modelBuilder)
        {
            //Abstract ExternalInteraction
            modelBuilder.Entity<ExternalInteraction>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<CommunitationButtonsExtInteration>();
            modelBuilder.Entity<WebsiteFormExtInteration>();

            //Abstract SentWebsiteFormField
            modelBuilder.Entity<SentWebsiteFormField>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<FilesSentFormField>();
            modelBuilder.Entity<SimpleSentFormField>();

            //Abstract WebsiteFormInput
            modelBuilder.Entity<WebsiteFormInput>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<CheckBoxWebsiteFormInput>();
            modelBuilder.Entity<NumberWebsiteFormInput>();
            modelBuilder.Entity<RadioWebsiteFormInput>();
            modelBuilder.Entity<RangeWebsiteFormInput>();
            modelBuilder.Entity<TextWebsiteFormInput>();
            modelBuilder.Entity<FileWebsiteFormInput>();
        }
        protected void MakeAbstractTasksModelsHierarchy(ModelBuilder modelBuilder)
        {
            //Abstract MarkedAsCompleted
            modelBuilder.Entity<MarkedAsCompleted>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<SimpleMarkedAsCompleted>();
            modelBuilder.Entity<WithAmountMarkedAsCompleted>();

            //Abstract UserTask
            modelBuilder.Entity<UserTask>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<SimpleUserTask>();
            modelBuilder.Entity<WithAmountUserTask>();
        }
        protected void MakeAbstractModelsHierarchy(ModelBuilder modelBuilder)
        {
            //Abstract BPTemplatePlaceholder
            modelBuilder.Entity<BPTemplatePlaceholder>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<BPCustomerTemplatePlaceholder>();
            modelBuilder.Entity<BPManualTemplatePlaceholder>();

            //Abstract CompanyAcquiringSettings
            modelBuilder.Entity<CompanyAcquiringSettings>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<KaspiAcquiringSettings>();
            modelBuilder.Entity<Kassa24AcquiringSettings>();

            modelBuilder.Entity<KhaanBankAcquiringSettings>();
            modelBuilder.Entity<QPayAcquiringSettings>();

            modelBuilder.Entity<SberbankAcquiringSettings>();
            modelBuilder.Entity<TBankAcquiringSettings>();
            modelBuilder.Entity<YookassaAcquiringSettings>();

            modelBuilder.Entity<PassimPayAcquiringSettings>();


            //Abstract CustomerConversation
            modelBuilder.Entity<CustomerConversation>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<CustomerCall>();
            modelBuilder.Entity<CustomerConference>();
            modelBuilder.Entity<CustomerMeeting>();

            //Abstract InvoicePaidInfo
            modelBuilder.Entity<InvoicePaidInfo>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<InvoiceAcquiringPaidInfo>();
            modelBuilder.Entity<InvoiceCryptoPaidInfo>();
            modelBuilder.Entity<InvoiceManualPaidInfo>();

            //Abstract InvoiceRejectedInfo
            modelBuilder.Entity<InvoiceRejectedInfo>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<ByCustomerInvoiceRejectedInfo>();
            modelBuilder.Entity<ByManagerInvoiceRejectedInfo>();

            //Abstract InvoiceTemplatePlaceholder
            modelBuilder.Entity<InvoiceTemplatePlaceholder>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<InvoiceCustomerTemplatePlaceholder>();
            modelBuilder.Entity<InvoiceItemTemplatePlaceholder>();
            modelBuilder.Entity<InvoiceManualTemplatePlaceholder>();

            //Abstract SalesPlan
            modelBuilder.Entity<SalesPlan>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<ByFunnelsSalesPlan>();
            modelBuilder.Entity<ByManagersSalesPlan>();
            modelBuilder.Entity<ForAllCompanySalesPlan>();
        }


        #endregion

    }
}
