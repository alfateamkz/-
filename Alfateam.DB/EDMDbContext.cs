using Alfateam.DB.Helpers;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.EDM.Models.ApprovalRoutes.RouteStageExecutors;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Documents.Templates;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.EDM.Models.Documents.TypesMetadata;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.Security;
using Alfateam.EDM.Models.General.Subjects;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Payments.Ways;
using Alfateam.ID.Models.Security.Verifications;
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

            CreateDefaultBusiness();
            CreateDefaultDocumentTypes();
        }
        public EDMDbContext(DbContextOptions<EDMDbContext> options)
        {
            Database.EnsureCreated();

            CreateDefaultBusiness();
            CreateDefaultDocumentTypes();
        }

        #region Abstractions

        #region ApprovalRoutes
        public DbSet<AfterDocSigningAction> AfterDocSigningAction { get; set; }
        public DbSet<RouteStageExecutor> RouteStageExecutors { get; set; }

        #endregion
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<DocTypeMetadata> DocTypeMetadatas { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentSigningResult> DocumentSigningResults { get; set; }
        public DbSet<DocumentSigningSide> DocumentSigningSides { get; set; }
        public DbSet<EDMSubject> EDMSubjects { get; set; }
        public DbSet<Signature> Signatures { get; set; }

        #endregion

        #region ApprovalRoutes
        public DbSet<ApprovalRoute> ApprovalRoutes { get; set; }
        public DbSet<ApprovalRouteDocCondition> ApprovalRouteDocConditions { get; set; }
        public DbSet<ApprovalRouteStage> ApprovalRouteStages { get; set; }
        public DbSet<ApprovalRouteStageAction> ApprovalRouteStageActions { get; set; }
        #endregion

        #region Documents

        #region DocumentSigning
        public DbSet<DocumentApprovalMetadata> DocumentApprovalMetadatas { get; set; }
        public DbSet<DocumentApprovalResult> DocumentApprovalResults { get; set; }
        public DbSet<DocumentSigningMetadata> DocumentSigningMetadatas { get; set; }
        public DbSet<SignedDocumentRoamingInfo> SignedDocumentRoamingInfos { get; set; }
        #endregion

        #region Templates
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<DocumentTemplatePlaceholder> DocumentTemplatePlaceholders { get; set; }
        #endregion

        #region Types

        #region Items
        public DbSet<DocumentPositionItem> DocumentPositionItems { get; set; }
        public DbSet<DocumentPositionItemModifier> DocumentPositionItemModifiers { get; set; }
        public DbSet<PriceListItem> PriceListItems { get; set; }
        #endregion

        #endregion
        public DbSet<DocumentsParcel> DocumentsParcels { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentTypeSide> DocumentTypeSides { get; set; }
        #endregion

        #region General

        #region Security
        public DbSet<DocumentsAccess> DocumentsAccess { get; set; }
        //public DbSet<Session> Sessions { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }

        #endregion

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmailNotificationSettings> EmailNotificationSettings { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfos { get; set; }
        public DbSet<TrustedUserIPAddress> TrustedUserIPAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkWithCompanyDocuments> WorkWithCompanyDocuments { get; set; }


        #endregion

        public DbSet<BannedCounterparty> BannedCounterparties { get; set; }
        public DbSet<CounterpartyGroup> CounterpartyGroups { get; set; }
        public DbSet<EDMProvider> EDMProviders { get; set; }






        private void CreateDefaultBusiness()
        {
            if (!Businesses.Any())
            {
                var business = new Business()
                {
                    Domain = "alfateam",
                    SubscriptionInfo = new SubscriptionInfo
                    {
                        SubscriptionBefore = DateTime.MaxValue,
                        OutgoingDocumentsLeftCount = int.MaxValue,
                    },
                    OwnerAlfateamID = "artur-kachok-alfateam-hui"
                };

                var company = new Company()
                {
                    Department = new Department()
                    {
                        Title = "Головное подразделение",
                        Description = "Наше офис (туалетная комната)",
                        Address = "РК, г. Астана, ул. Акмешит, д.7, кв.43",
                        IsRoot = true,
                    },
                    Description = "Делаем сайты и прочую хуйню",
                    ActualAddress = "РК, г. Астана, ул. Акмешит, д.7, кв.43",
                    LegalAddress = "РК, г. Астана, ул. Александра Затаевича, д.10, кв.24",
                    CountryCode = "KZ",
                    BusinessNumber = "123456789012",
                    Title = "ТОО Альфатим ИТ(Alfateam)",
                };
                company.Users.Add(new User
                {
                    Department = company.Department,
                    DocumentsAccess = new DocumentsAccess()
                    {
                        Type = DocumentsAccessType.AllDepartments
                    },
                    NotificationSettings = new EmailNotificationSettings(),
                    Permissions = new UserPermissions(),
                    Position = "Президент",
                    Role = UserRole.Owner,
                    AlfateamID = "artur-kachok-alfateam-hui",
                });


                business.Subjects.Add(company);
                Businesses.Add(business);
                SaveChanges();
            }
        }

        private void CreateDefaultDocumentTypes()
        {
            if(!DocumentTypes.Any(o => o.IsDefaultType))
            {
                DocumentTypes.Add(new DocumentType
                {
                    Title = "Договор оказания услуг",
                    Description = "",
                    IsDefaultType = true,
                    Sides = new List<DocumentTypeSide>
                    {
                        new DocumentTypeSide
                        {
                            Title = "Заказчик",
                            IsSignatureRequired = true,
                        },
                         new DocumentTypeSide
                        {
                            Title = "Исполнитель",
                            IsSignatureRequired = true,
                        },
                    }
                });
                DocumentTypes.Add(new DocumentType
                {
                    Title = "Акт выполненных работ",
                    Description = "",
                    IsDefaultType = true,
                    Sides = new List<DocumentTypeSide>
                    {
                        new DocumentTypeSide
                        {
                            Title = "Заказчик",
                            IsSignatureRequired = true,
                        },
                         new DocumentTypeSide
                        {
                            Title = "Исполнитель",
                            IsSignatureRequired = true,
                        },
                    }
                });
                DocumentTypes.Add(new DocumentType
                {
                    Title = "Счет на оплату",
                    Description = "",
                    IsDefaultType = true,
                    Sides = new List<DocumentTypeSide>
                    {
                        new DocumentTypeSide
                        {
                            Title = "Заказчик",
                            IsSignatureRequired = false,
                        },
                         new DocumentTypeSide
                        {
                            Title = "Исполнитель",
                            IsSignatureRequired = true,
                        },
                    }
                });
            }
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.EDM, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ApprovalRoute>().HasOne(o => o.ForOutgoingDocCondition).WithOne(o => o.ApprovalRoute).HasForeignKey<ApprovalRouteDocCondition>(o => o.ApprovalRouteId);
            //modelBuilder.Entity<ApprovalRoute>().HasOne(o => o.ForInboxDocCondition).WithOne(o => o.ApprovalRoute).HasForeignKey<ApprovalRouteDocCondition>(o => o.ApprovalRouteId);


          

            modelBuilder.Entity<Company>().HasOne(o => o.WorksWithCounterpartiesDocuments);
            modelBuilder.Entity<Company>().HasOne(o => o.WorksWithCustomerDocuments);

            //Abstract AfterDocSigningAction
            modelBuilder.Entity<AfterDocSigningAction>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AfterDocSigningMoveToDepartment>();
            modelBuilder.Entity<AfterDocSigningNotifyUsers>();

            //Abstract RouteStageExecutor
            modelBuilder.Entity<RouteStageExecutor>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<RouteStageExecutorDepartment>();
            modelBuilder.Entity<RouteStageExecutorUsers>();

            //Abstract Document
            modelBuilder.Entity<Document>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<Document>().HasMany(o => o.DepartmentsReferences).WithMany(o => o.Documents);
            modelBuilder.Entity<DocumentWithFile>();
            modelBuilder.Entity<PriceListDocument>();
            modelBuilder.Entity<WithPositionItemsDocument>();
       

            //Abstract EDMSubject
            modelBuilder.Entity<EDMSubject>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<Company>();
            modelBuilder.Entity<Individual>();

            //Abstract DocumentSigningSide
            modelBuilder.Entity<DocumentSigningSide>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AlfateamEDMDocumentSigningSide>();
            modelBuilder.Entity<CompanyDocumentSigningSide>();
            modelBuilder.Entity<IndividualDocumentSigningSide>();

            //Abstract Counterparty
            modelBuilder.Entity<Counterparty>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<CompanyCounterparty>();
            modelBuilder.Entity<EDMCounterparty>();
            modelBuilder.Entity<IndividualCounterparty>();

            //Abstract Signature
            modelBuilder.Entity<Signature>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AlfateamEDMSignature>();
            modelBuilder.Entity<MarkedAsElectronicallySignature>();
            modelBuilder.Entity<ScanSignature>();
            modelBuilder.Entity<ScanSignatureWithoutDocFlow>();

            //Abstract Signature
            modelBuilder.Entity<DocumentSigningResult>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DocumentRejectedResult>();
            modelBuilder.Entity<DocumentSuccessfullySignedResult>();

            //Abstract DocTypeMetadata
            modelBuilder.Entity<DocTypeMetadata>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<ActDisagreementDocTypeMetadata>();
            modelBuilder.Entity<ActDocTypeMetadata>();
            modelBuilder.Entity<ActReconciliationDocTypeMetadata>();
            modelBuilder.Entity<AgreementDocTypeMetadata>();
            modelBuilder.Entity<AttorneyDocTypeMetadata>();
            modelBuilder.Entity<CertificateRegistryDocTypeMetadata>();
            modelBuilder.Entity<ClaimDocTypeMetadata>();
            modelBuilder.Entity<ConsignmentDocTypeMetadata>();
            modelBuilder.Entity<DetalizationDocTypeMetadata>();
            modelBuilder.Entity<InvoiceDocTypeMetadata>();
            modelBuilder.Entity<LetterDocTypeMetadata>();
            modelBuilder.Entity<NonFormalizedDocTypeMetadata>();
            modelBuilder.Entity<PriceListAgreementDocTypeMetadata>();
            modelBuilder.Entity<PriceListDocTypeMetadata>();
            modelBuilder.Entity<SupplementaryAgreementDocTypeMetadata>();
            modelBuilder.Entity<WaybillDocTypeMetadata>();
        }
    }
}
