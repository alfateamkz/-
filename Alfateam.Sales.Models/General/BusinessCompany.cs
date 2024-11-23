using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Sales.Models.Leads;
using Alfateam.Sales.Models.Orders;
using Alfateam.Sales.Models.Plan;
using Alfateam.Sales.Models.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class BusinessCompany : AbsModel
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string? LogoPath { get; set; }



        public Currency MainCurrency { get; set; }
        public int MainCurrencyId { get; set; }




        public List<User> Users { get; set; } = new List<User>();
        public Department Department { get; set; }



        public List<Lead> Leads { get; set; } = new List<Lead>();
        public List<Order> Orders { get; set; } = new List<Order>();



        public List<SalesPlanning> SalesPlannings { get; set; } = new List<SalesPlanning>();
        public List<SalesFunnel> SalesFunnels { get; set; } = new List<SalesFunnel>();
        public List<SalesScript> SalesScripts { get; set; } = new List<SalesScript>();




        public List<PersonContact> PersonContacts { get; set; } = new List<PersonContact>();
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<PersonContactCategory> PersonContactCategories { get; set; } = new List<PersonContactCategory>();
        public List<CompanyCategory> CompanyCategories { get; set; } = new List<CompanyCategory>();
        public List<CompanyFieldOfActivity> CompanyFieldsOfActivity { get; set; } = new List<CompanyFieldOfActivity>();




        public List<BusinessProposal> BusinessProposals { get; set; } = new List<BusinessProposal>();
        public List<BusinessProposalTemplate> BusinessProposalTemplates { get; set; } = new List<BusinessProposalTemplate>();
        public List<BusinessProposalsKanban> BusinessProposalKanbans { get; set; } = new List<BusinessProposalsKanban>();


        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<InvoiceTemplate> InvoiceTemplates { get; set; } = new List<InvoiceTemplate>();
        public List<InvoicesKanban> InvoicesKanbans { get; set; } = new List<InvoicesKanban>();






        public List<ExternalInteraction> ExternalInteractions { get; set; } = new List<ExternalInteraction>();
        public List<UserTask> UserTasks { get; set; } = new List<UserTask>();
        public List<HistoryAction> HistoryActions { get; set; } = new List<HistoryAction>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}
