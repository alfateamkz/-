using Alfateam.Sales.Models;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Conversation;
using Alfateam.Sales.Models.ExternalInteractions.SentForms;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields.Props;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Sales.Models.Integrations.API;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Sales.Models.Orders;
using Alfateam.Sales.Models.Plan;
using Alfateam.Sales.Models.Scripting;
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
        public DbSet<CustomerConversation> CustomerConversations { get; set; }
        public DbSet<InvoicePaidInfo> InvoicePaidInfos { get; set; }
        public DbSet<InvoiceTemplatePlaceholder> InvoiceTemplatePlaceholders { get; set; }

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
        public DbSet<SalesFunnelStageType> SalesFunnelStageTypes { get; set; }
        public DbSet<SalesFunnelTunnel> SalesFunnelTunnels { get; set; }

        #endregion

        #region General

        #region Security
        public DbSet<UserPermissions> UserPermissions { get; set; }
        public DbSet<HistoryAction> HistoryActions { get; set; }

        #endregion
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCompany> BusinessCompanies { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SalesKPI> SalesKPIs { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfos { get; set; }
        public DbSet<User> Users { get; set; }

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

        #region Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSaleInfo> OrderSaleInfos { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        #endregion

        #region Plan
        public DbSet<SalesPlan> SalesPlans { get; set; }
        public DbSet<SalesPlanItem> SalesPlanItems { get; set; }
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
    }
}
