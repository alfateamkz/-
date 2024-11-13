using Alfateam.Sales.Models;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.Conversation;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.Models.Orders;
using Alfateam.Sales.Models.Plan;
using Alfateam.Sales.Models.Scripting;
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
        public DbSet<BPTemplatePlaceholder> BPTemplatePlaceholders { get; set; }
        public DbSet<CustomerConversation> CustomerConversations { get; set; }
        public DbSet<InvoicePaidInfo> InvoicePaidInfos { get; set; }
        public DbSet<InvoiceTemplatePlaceholder> InvoiceTemplatePlaceholders { get; set; }

        #endregion

        #region BusinessProposals
        public DbSet<BusinessProposal> BusinessProposals { get; set; }
        public DbSet<BusinessProposalTemplate> BusinessProposalTemplates { get; set; }
        #endregion

        #region Conversation
        public DbSet<CustomerMeetingAttachment> CustomerMeetingAttachments { get; set; }

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

        #endregion
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCompany> BusinessCompanies { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SalesKPI> SalesKPIs { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfos { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Invoices
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


        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
    }
}
