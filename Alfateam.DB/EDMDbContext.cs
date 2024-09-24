using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.Templates;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class EDMDbContext : DbContext
    {
        public EDMDbContext()
        {
            Database.EnsureCreated();
        }
        public EDMDbContext(DbContextOptions<EDMDbContext> options)
        {
            Database.EnsureCreated();
        }

        #region Abstractions

        #region ApprovalRoutes
        public DbSet<AfterDocSigningAction> AfterDocSigningAction { get; set; }
        public DbSet<RouteStageExecutor> RouteStageExecutors { get; set; }
       
        #endregion

        #endregion

        #region ApprovalRoutes
        public DbSet<ApprovalRoute> ApprovalRoutes { get; set; }
        public DbSet<ApprovalRouteDocCondition> ApprovalRouteDocConditions { get; set; }
        public DbSet<ApprovalRouteStage> ApprovalRouteStages { get; set; }
        public DbSet<ApprovalRouteStageAction> ApprovalRouteStageActions { get; set; }
        #endregion

        #region Documents

        #region DocumentSigning
        public DbSet<DocumentSigningSide> DocumentSigningSides { get; set; }
        public DbSet<DocumentSigningSideComment> DocumentSigningSideComments { get; set; }
        public DbSet<DocumentSigningSideScan> DocumentSigningSideScans { get; set; }
        public DbSet<SignedDocument> SignedDocuments { get; set; }
        public DbSet<SignedDocumentRoamingInfo> SignedDocumentRoamingInfos { get; set; }
        #endregion

        #region Templates
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<DocumentTemplatePlaceholder> DocumentTemplatePlaceholders { get; set; }
        #endregion

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentTypeSide> DocumentTypeSides { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        public DbSet<DocumentVersionSideFeedback> DocumentVersionSideFeedbacks { get; set; }
        #endregion

        #region General

        #region Security
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }

        #endregion

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<TrustedUserIPAddress> TrustedUserIPAddresses { get; set; }
        public DbSet<User> Users { get; set; }


        #endregion

        public DbSet<BannedCounterparty> BannedCounterparties { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<CounterpartyGroup> CounterpartyGroups { get; set; }
        public DbSet<EDMProvider> EDMProviders { get; set; }
    }
}
