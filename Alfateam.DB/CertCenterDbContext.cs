using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
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
        public DbSet<AbsAttachedFile> AbsAttachedFiles { get; set; }
        public DbSet<CancellationRequest> CancellationRequests { get; set; }
        public DbSet<IssueRequest> IssueRequests { get; set; }

        #endregion

        #region General
        public DbSet<CancellationRequestInfo> CancellationRequestInfos { get; set; }
        public DbSet<EDSSigned> EDSSigned { get; set; }
        public DbSet<IssueRequestInfo> IssueRequestInfos { get; set; }
        #endregion


        public DbSet<AlfateamEDS> AlfateamEDSs { get; set; }
        public DbSet<AlfateamDigitalPOA> AlfateamDigitalPOA { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Abstract AbsAttachedFile
            modelBuilder.Entity<AbsAttachedFile>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AttachedImage>();
            modelBuilder.Entity<AttachedVideo>();

            //Abstract CancellationRequest
            modelBuilder.Entity<CancellationRequest>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DigitalPOACancellationRequest>();
            modelBuilder.Entity<EDSCancellationRequest>();

            //Abstract CancellationRequest
            modelBuilder.Entity<IssueRequest>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<DigitalPOAIssueRequest>();
            modelBuilder.Entity<EDSIssueRequest>();
        }
    }
}
