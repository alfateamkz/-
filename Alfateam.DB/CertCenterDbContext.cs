using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.DocumentRecognizedInfo;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Documents;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.CertificationCenter.Models.RequestSuccessDocs;
using Alfateam.CertificationCenter.Models.Verification;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class CertCenterDbContext : DbContext
    {
        public CertCenterDbContext()
        {
            Database.EnsureCreated();
        }
        public CertCenterDbContext(DbContextOptions<CertCenterDbContext> options) : this()
        {
            Database.EnsureCreated();
        }

        #region Abstraction
        public DbSet<CancellationRequest> CancellationRequests { get; set; }
        public DbSet<IssueRequest> IssueRequests { get; set; }
        public DbSet<VerificationRequest> VerificationRequests { get; set; }

        #endregion

        #region DocumentRecognizedInfo
        public DbSet<CompanyDocumentRecognizedInfo> CompanyDocumentRecognizedInfo { get; set; }
        public DbSet<PersonalDocumentRecognizedInfo> PersonalDocumentRecognizedInfo { get; set; }

        #endregion

        #region General

        #region Biometric

        public DbSet<BiometricIdentificationAction> BiometricIdentificationActions { get; set; }
        public DbSet<BiometricIdentificationRequest> BiometricIdentificationRequests { get; set; }
        public DbSet<BiometricIdentificationRequestAction> BiometricIdentificationRequestActions { get; set; }
        public DbSet<SentBiometricIdentification> SentBiometricIdentifications { get; set; }

        #endregion

        #region Documents

        public DbSet<DocumentCountry> DocumentCountries { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentTypePage> DocumentTypePages { get; set; }
        public DbSet<SentDocument> SentDocuments { get; set; }

        #endregion

        public DbSet<CancellationRequestInfo> CancellationRequestInfo { get; set; }
        public DbSet<EDSSigned> EDSSigned { get; set; }
        public DbSet<IssueRequestInfo> IssueRequestInfo { get; set; }
        public DbSet<SentSignatureFromApp> SentSignaturesFromApp { get; set; }
        public DbSet<VerificationRequestInfo> VerificationRequestInfo { get; set; }

        #endregion

        #region RequestSuccessDocs

        public DbSet<DigitalPOAIssueRequestSuccessDocs> DigitalPOAIssueRequestSuccessDocs { get; set; }
        public DbSet<EDSIssueRequestSuccessDocs> EDSIssueRequestSuccessDocs { get; set; }
        public DbSet<PersonalVerificationRequestSuccessDocs> PersonalVerificationRequestSuccessDocs { get; set; }

        #endregion

        public DbSet<AlfateamEDS> AlfateamEDSs { get; set; }
        public DbSet<AlfateamDigitalPOA> AlfateamDigitalPOA { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }




        #region Init
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Abstract CancellationRequest
            modelBuilder.Entity<CancellationRequest>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DigitalPOACancellationRequest>();
            modelBuilder.Entity<EDSCancellationRequest>();

            //Abstract IssueRequest
            modelBuilder.Entity<IssueRequest>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DigitalPOAIssueRequest>();
            modelBuilder.Entity<EDSIssueRequest>();

            //Abstract VerificationRequest
            modelBuilder.Entity<VerificationRequest>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<PersonalVerificationRequest>();
        }


        #endregion

        #region Fill base Methods

        private void FillDefaultEntitiesIfNotAny()
        {
            FillDefaultDocumentTypesAndCountries();
            FillDefaultBiometryActions();
        }
        private void FillDefaultDocumentTypesAndCountries()
        {
            if (!DocumentTypes.Any())
            {
                var internationalPasport = new DocumentType
                {
                    Title = "Заграничный паспорт",
                    Pages = new List<DocumentTypePage>
                    {
                        new DocumentTypePage
                        {
                            Title = "Лицевая страница"
                        }
                    }
                };
                var internalPassport = new DocumentType
                {
                    Title = "Внутренний паспорт",
                    Pages = new List<DocumentTypePage>
                    {
                        new DocumentTypePage
                        {
                            Title = "Лицевая страница"
                        },
                          new DocumentTypePage
                        {
                            Title = "Страница с пропиской"
                        },
                    }
                };
                var idCard = new DocumentType
                {
                    Title = "Id карта\\удостоверение личности",
                    Pages = new List<DocumentTypePage>
                    {
                        new DocumentTypePage
                        {
                            Title = "Лицевая сторона"
                        },
                          new DocumentTypePage
                        {
                            Title = "Оборотная сторона"
                        },
                    }
                };


                DocumentTypes.Add(internationalPasport);
                DocumentTypes.Add(internalPassport);
                DocumentTypes.Add(idCard);


                DocumentCountries.Add(new DocumentCountry
                {
                    Title = "Казахстан",
                    CountryCode = "KZ",
                    DocumentTypes = new List<DocumentType> { idCard, internationalPasport }
                });
                DocumentCountries.Add(new DocumentCountry
                {
                    Title = "Россия",
                    CountryCode = "RU",
                    DocumentTypes = new List<DocumentType> { idCard, internationalPasport, internalPassport }
                });
                DocumentCountries.Add(new DocumentCountry
                {
                    Title = "Кыргызстан",
                    CountryCode = "KG",
                    DocumentTypes = new List<DocumentType> { idCard, internationalPasport }
                });
                DocumentCountries.Add(new DocumentCountry
                {
                    Title = "Узбекистан",
                    CountryCode = "UZ",
                    DocumentTypes = new List<DocumentType> { idCard, internationalPasport }
                });
                DocumentCountries.Add(new DocumentCountry
                {
                    Title = "Монголия",
                    CountryCode = "MN",
                    DocumentTypes = new List<DocumentType> { idCard, internationalPasport }
                });

                SaveChanges();
            }
        }

        private void FillDefaultBiometryActions()
        {
            if (!BiometricIdentificationActions.Any())
            {
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Улыбнитесь"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Моргните левым глазом"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Моргните правым глазом"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Вращайте головой по часовой стрелке"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Вращайте головой против часовой стрелке"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Наклоните голову влево"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Наклоните голову вправо"
                });
                BiometricIdentificationActions.Add(new BiometricIdentificationAction
                {
                    Title = "Кивните головой"
                });

                SaveChanges();
            }
        }

        #endregion
    }
}
