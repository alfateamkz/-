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
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Documents.Formats;
using Alfateam.EDM.Models.Documents.Meta.Fields;
using Alfateam.EDM.Models.Documents.Meta.Structure;
using Alfateam.EDM.Models.Documents.Templates;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.PowersOfAttorney;
using Alfateam.EDM.Models.General.Security;
using Alfateam.EDM.Models.General.Subjects;
using Alfateam.EDM.Models.Integrations.API;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Payments.Ways;
using Alfateam.ID.Models.Security.Verifications;
using Alfateam.SharedModels;
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
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentApproveStrategy> DocumentApproveStrategies { get; set; }
        public DbSet<DocumentMetadataField> DocumentMetadataFields { get; set; }
        public DbSet<DocumentSigningResult> DocumentSigningResults { get; set; }
        public DbSet<DocumentSigningSide> DocumentSigningSides { get; set; }
        public DbSet<EDMSubject> EDMSubjects { get; set; }
        //public DbSet<EDMSubject> EDMSubjects { get; set; }
        public DbSet<PowerOfAttorney> PowersOfAttorney { get; set; }
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

        public DbSet<DocumentStorageFile> DocumentStorageFiles { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
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
        public DbSet<PowerOfAttorneyVerificationInfo> PowerOfAttorneyVerificationInfo { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfos { get; set; }
        public DbSet<TrustedUserIPAddress> TrustedUserIPAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkWithCompanyDocuments> WorkWithCompanyDocuments { get; set; }


        #endregion

        #region Integrations

        #region API
        public DbSet<AlfateamAPIKey> AlfateamAPIKeys { get; set; }
        public DbSet<AlfateamAPIRequestEntry> AlfateamAPIRequestEntries { get; set; }

        #endregion

        #endregion

        public DbSet<BannedCounterparty> BannedCounterparties { get; set; }
        public DbSet<CounterpartyGroup> CounterpartyGroups { get; set; }
        public DbSet<CounterpartyInvitation> CounterpartyInvitations { get; set; }
        public DbSet<EDMProvider> EDMProviders { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }





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
                //Типы для документа с файлом - для подписания с контрагентами
                DocumentTypes.Add(new DocumentType("Акт расхождений", 2, new DocTypeMetadataStructure
                {
                   Fields = new List<DocTypeMetadataStructureField>
                   {
                       new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                       new DocTypeMetadataStructureField("Сумма","Sum", DocTypeMetadataStructureFieldType.Double, true, true)
                   }
                }));
                DocumentTypes.Add(new DocumentType("Акт", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма без НДС","SumWithoutVAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("НДС","VAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("Причина","Reason", DocTypeMetadataStructureFieldType.Double, false, false),
                    }
                }));
                DocumentTypes.Add(new DocumentType("Акт сверки", 2, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Договор", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Тип договора","AgreementType", DocTypeMetadataStructureFieldType.Double, false, false),
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма без НДС","SumWithoutVAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("НДС","VAT", DocTypeMetadataStructureFieldType.Double, true, true),
                    }
                }));
                DocumentTypes.Add(new DocumentType("Доверенность", 1, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Реестр сертификатов", 1, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Претензия", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма","Sum", DocTypeMetadataStructureFieldType.Double, true, true)
                    }
                }));
                DocumentTypes.Add(new DocumentType("Накладная", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма без НДС","SumWithoutVAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("НДС","VAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("Причина","Reason", DocTypeMetadataStructureFieldType.Double, false, false),
                    }
                }));
                DocumentTypes.Add(new DocumentType("Детализация", 2, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Счет на оплату", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма без НДС","SumWithoutVAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("НДС","VAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("Причина","Reason", DocTypeMetadataStructureFieldType.Double, false, false),
                    }
                }));
                DocumentTypes.Add(new DocumentType("Письмо", 2, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Неформализованный документ", 1, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Протокол согласования цены", 1, new DocTypeMetadataStructure()));
                DocumentTypes.Add(new DocumentType("Ценовой лист", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("К договору - номер","ToAgreementNumber", DocTypeMetadataStructureFieldType.String, true, true),
                        new DocTypeMetadataStructureField("К договору - дата","ToAgreementDate", DocTypeMetadataStructureFieldType.Date, true, true),
                        new DocTypeMetadataStructureField("Действует с","PricesStartsFrom", DocTypeMetadataStructureFieldType.Date, true, true),
                        new DocTypeMetadataStructureField("Действует до","PricesActualBefore", DocTypeMetadataStructureFieldType.Date, true, true),
                    }
                }));
                DocumentTypes.Add(new DocumentType("Доп.соглашение к договору", 2, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Тип договора","AgreementType", DocTypeMetadataStructureFieldType.Double, false, false),
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма без НДС","SumWithoutVAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("НДС","VAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("К договору - номер","ToAgreementNumber", DocTypeMetadataStructureFieldType.String, true, true),
                        new DocTypeMetadataStructureField("К договору - дата","ToAgreementDate", DocTypeMetadataStructureFieldType.Date, true, true),
                    }
                }));
                DocumentTypes.Add(new DocumentType("Транспортная накладная", 3, new DocTypeMetadataStructure()));









                //Типы для документа с файлом - внутренние
                DocumentTypes.Add(new DocumentType("Накладная", 1, new DocTypeMetadataStructure
                {
                    Fields = new List<DocTypeMetadataStructureField>
                    {
                        new DocTypeMetadataStructureField("Валюта","CurrencyCode", DocTypeMetadataStructureFieldType.CurrencyCode, true, true),
                        new DocTypeMetadataStructureField("Сумма без НДС","SumWithoutVAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("НДС","VAT", DocTypeMetadataStructureFieldType.Double, true, true),
                        new DocTypeMetadataStructureField("Причина","Reason", DocTypeMetadataStructureFieldType.Double, false, false),
                    }
                }, true));








                //Служебные типы
                DocumentTypes.Add(new DocumentType("Пакет документов", 2, DocumentTypePurpose.ForDocumentParcel));
                DocumentTypes.Add(new DocumentType("Ценовой лист (цифровой)", 2, DocumentTypePurpose.ForPriceListDocument));
                DocumentTypes.Add(new DocumentType("Счет на оплату/Акт выполненных работ (цифровой)", 2, DocumentTypePurpose.ForWithPositionItemsDocument));
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
            modelBuilder.Entity<DocumentsParcel>();
            modelBuilder.Entity<DocumentWithFile>();
            modelBuilder.Entity<PriceListDocument>();
            modelBuilder.Entity<WithPositionItemsDocument>();


            //Abstract DocumentApproveStrategy
            modelBuilder.Entity<DocumentApproveStrategy>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DocumentApprovalDepartmentStrategy>();
            modelBuilder.Entity<DocumentApprovalRouteStrategy>();

            //Abstract DocumentMetadataField
            modelBuilder.Entity<DocumentMetadataField>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DocumentMetadataCurrencyCodeField>();
            modelBuilder.Entity<DocumentMetadataDateField>();
            modelBuilder.Entity<DocumentMetadataDoubleField>();
            modelBuilder.Entity<DocumentMetadataIntegerField>();
            modelBuilder.Entity<DocumentMetadataStringField>();
            modelBuilder.Entity<DocumentMetadataTaxSumInfoField>();


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
            modelBuilder.Entity<ScanSignature>();

            //Abstract DocumentSigningResult
            modelBuilder.Entity<DocumentSigningResult>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DocumentRejectedResult>();
            modelBuilder.Entity<DocumentSuccessfullySignedResult>();


            //Abstract PowerOfAttorney
            modelBuilder.Entity<PowerOfAttorney>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DigitalPowerOfAttorney>();
            modelBuilder.Entity<NotarizedPowerOfAttorney>();
        }
    }
}
